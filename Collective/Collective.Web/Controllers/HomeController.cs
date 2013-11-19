using AutoMapper;
using Collective.Model;
using Collective.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        public const string USER_SESSION_KEY = "appCurrentUser";

        public IRepository Repository { get; set; }
        public HomeController(IRepository repository) 
        {
            Repository = repository;
        }
        #endregion

        #region Constants
        public const int RESOURCE_ABOUT_US_ID = 1;
        public const int RESOURCE_TERMS_ID = 2;
        #endregion

        #region Views & Partials
        public ActionResult Index() 
        {
            IMetaDefinable instance = Configuration();
            return View(instance); 
        }
        public ActionResult Detail(int id) 
        {
            IMetaDefinable instance = Item(id);
            return View(instance); 
        }
        public ActionResult Gallery() { return View(); }
        public PartialViewResult Header() { return PartialView(); }
        public PartialViewResult Footer() { return PartialView(); }
        public PartialViewResult Login() { return PartialView(); }
        public PartialViewResult Register() { return PartialView(); }

        public ActionResult About() { return View((object)Model.Extensions.GetResource(RESOURCE_ABOUT_US_ID)); }
        public ActionResult Conditions() { return View((object)Model.Extensions.GetResource(RESOURCE_TERMS_ID)); }

        public ActionResult Contact() { return View(); }
        #endregion

        #region Data
        #region Meta Information
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMetaDefinable Item(int id)
        {
            return Repository.Get<Item>(id);
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMetaDefinable Configuration()
        {
            return Repository.Get<Setting>(1);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult CurrentUser()
        {
            User currentUser = Session[USER_SESSION_KEY] as User;

            if (currentUser != null) 
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = Mapper.Map<User, UserResponse>(currentUser)
                };
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = UserResponse.Empty()
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Cover() 
        {
            IEnumerable<CoverResponse> result = Enumerable.Empty<CoverResponse>();

            Repository.GetAll((IQueryable<Item> response) => {
                var data = (from item in response
                            where item.UseAsBackground
                            select item).ToList();

                result = data.Select(item => Mapper.Map<Item, CoverResponse>(item));
            });

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Product(int id) 
        {
            Item instance = Repository.Get<Item>(id);
            object result = new object();
            
            if (instance != null)
            {
                var data = new ProductResponse
                {
                    ItemId = instance.ItemId,
                    Meta = instance.Meta,
                    
                    Tags = instance.Tags.Select(item => item.TagId).ToList(),
                    Frames = instance.AvailableFrames.Select(item => item.FrameId).ToList(),
                    Sizes = instance.AvailableSizes.Select(item => item.SizeId).ToList(),
                                        
                    AvailableArtists = new List<Option>().LoadFrom<Artist>(Repository, false),
                    AvailableTags = Extensions.LoadFrom(instance.Tags, false),
                    AvailableFrames = Extensions.LoadFrom(instance.AvailableFrames, false),
                    AvailableSizes = Extensions.LoadFrom(instance.AvailableSizes, false),
                    
                    ArtistId = instance.Artist.ArtistId,
                    ArtistName = instance.Artist.Name,

                    Price = instance.Price,
                    Code = instance.Code,
                    PhotoUrl = instance.PhotoUrl,

                    Spanish = instance.Spanish,
                    English = instance.English,
                    Related = new List<string>()
                };

                result = (object)data;
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public JsonResult Products(string search)
        {
            List<SearchResponse> result = Enumerable.Empty<SearchResponse>().ToList();
            
            if (string.IsNullOrEmpty(search)) 
                search = string.Empty;

            Repository.GetAll((IQueryable<Item> response) =>
            {
                var data = (from item in response
                            where (item.Artist.Name == search || search == "") ||
                                (item.English.Name == search || search == "") ||
                                (item.Spanish.Name == search || search == "")
                            select item).ToList();

                result = data.Select(item => Mapper.Map<Item, SearchResponse>(item)).ToList();

                foreach (var item in result)
                    item.Filters = string.Format("{0} {1} {2}",
                                item.Artist.Replace(" ", ""),
                                string.Join(" ", (List<string>)item.Tags),
                                string.Join(" ", (List<string>)item.Sizes)
                            );
            });

            var responseData = new SearchContextResponse
            {
                Artists = new List<Option>().LoadFrom<Artist>(Repository),
                Themes = new List<Option>().LoadFrom<Tag>(Repository),
                Formats = new List<Option>().LoadFrom<Size>(Repository),
                Items = result
            };

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = responseData
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload() 
        {
            return Extensions.Execute(() => {

                HttpFileCollectionBase uploaded = HttpContext.Request.Files;

                if (uploaded.Count > 0)
                {
                    HttpPostedFileBase postedFile = uploaded.Get(0);
                    return postedFile.SaveAs();
                }

                throw new ArgumentNullException();
            });
        }
        
        #endregion

        #region Request LogIn
        [HttpPost]
        public JsonResult LogIn(string email, string password) 
        {
            User currentUser = default(User);
            bool hasParameters = !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);
            LogInResponseType responseType = hasParameters ? LogInResponseType.UserDoesNotExist : LogInResponseType.NoDataProvided;

            Repository.GetAll((IQueryable<User> response) => {
                var user = response
                    .Where(item => email.Equals(item.Email, StringComparison.InvariantCultureIgnoreCase))
                    .SingleOrDefault();

                if (user != null && user.UserID > 0) 
                {
                    if (!password.Equals(user.Password, StringComparison.CurrentCulture))
                        responseType = LogInResponseType.NoPasswordMatch;

                    if (responseType == LogInResponseType.UserDoesNotExist && !user.IsActive)
                        responseType = LogInResponseType.UserIsNotActive;

                    responseType = LogInResponseType.Authenticated;
                    currentUser = user;

                    SetUserAsCurrent(currentUser);
                }
            });

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    IsAuthenticated = responseType == LogInResponseType.Authenticated,
                    ResponseCode = (int)responseType,
                    User = currentUser
                }
            };
        }

        [HttpPost]
        public JsonResult LogOut(string email, string password) 
        {
            return Extensions.Execute(() => { Session.Abandon(); });
        }

        enum LogInResponseType 
        {
            UserDoesNotExist,
            NoPasswordMatch,
            UserIsNotActive,
            NoDataProvided,
            Authenticated
        }
        #endregion

        #region Request Register
        [HttpPost]
        public JsonResult Register(string name, string password, string email) 
        {

            User newUser = new User 
            { 
                Name = name,
                Password = password,
                Email = email,
                IsActive = true,
                IsAdministrator = false
            };

            Repository.Update(newUser);
            SetUserAsCurrent(newUser);

            return LogIn(newUser.Email, newUser.Password);
        }
        #endregion

        #region Contact

        [HttpPost]
        public JsonResult SendMessage(string name, string email, string phone, string message) 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = true
            };
        }

        #endregion

        #region Utileries

        void SetUserAsCurrent(User user) 
        {
            string userType = user.IsAdministrator ? "Administrator" : "User";
            IIdentity identity = new GenericIdentity(user.Name, userType);
            HttpContext.User = new GenericPrincipal(identity, new string[] { userType });

            Session.RemoveAll();
            Session.Add(USER_SESSION_KEY, user);
        }

        #endregion
    }
}
