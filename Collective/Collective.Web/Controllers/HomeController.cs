using Collective.Model;
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

        #region Views & Partials
        public ActionResult Index() { return View(); }
        public ActionResult Gallery() { return View(); }
        public ActionResult Detail() { return View(); }
        public PartialViewResult Header() { return PartialView(); }
        public PartialViewResult Footer() { return PartialView(); }
        public PartialViewResult Login() { return PartialView(); }
        public PartialViewResult Register() { return PartialView(); }

        public ActionResult About() {
            return View((object)Resources.AboutUS.Get());
        }

        public ActionResult Contact() { return View(); }
        #endregion

        #region Data
        public JsonResult CurrentUser()
        {
            User currentUser = Session[USER_SESSION_KEY] as User;

            if (currentUser != null) 
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        IsLoggedIn = true,
                        Name = currentUser.Name,
                        Email = currentUser.Email,
                        IsAdministrator = currentUser.IsAdministrator,
                        IsActive = currentUser.IsActive,
                        UserID = currentUser.UserID
                    }
                };
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new 
                {
                    IsLoggedIn = false,
                }
            };
        }
        public JsonResult Cover() 
        {
            IEnumerable<object> result = Enumerable.Empty<object>();

            Repository.GetAll((IQueryable<Item> response) => {
                var data = (from item in response
                            where item.UseAsBackground
                            select new { 
                                Name = item.Description,
                                PhotoUrl = item.PhotoUrl
                            }).ToList();

                result = data.OfType<object>();
            });

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
        public JsonResult Product(int id) 
        {
            Item instance = default(Item);
            object result = new object();

            Repository.GetAll((IQueryable<Item> response) =>
            {
                instance = (from item in response
                            where item.ItemId == id
                            select item)
                            .FirstOrDefault();

                var data = new
                {
                    AvailableArtists = new List<object>().LoadFrom((IRepository<Artist>)Repository, false),
                    AvailableTags = new List<object>().LoadFrom((IRepository<Tag>)Repository, false),
                    Tags = instance.Tags.Select(item => item.TagId).ToList(),
                    AvailableFrames = new List<object>().LoadFrom((IRepository<Frame>)Repository, false),
                    Frames = instance.AvailableFrames.Select(item => item.FrameId).ToList(),
                    AvailableSizes = new List<object>().LoadFrom((IRepository<Size>)Repository, false),
                    Sizes = instance.AvailableSizes.Select(item => item.SizeId).ToList(),
                    ArtistId = instance.Artist.ArtistId,
                    ArtistName = instance.Artist.Name,
                    Price = instance.Price,
                    Code = instance.Code,
                    PhotoUrl = instance.PhotoUrl,
                    Spanish = new
                    {
                        Name = "Panorama",
                        Description = "Esta es una prueba de un paisaje"
                    },
                    English = new
                    {
                        Name = "Landscape",
                        Description = "This is a landscape test"
                    },
                    Related = new List<string>()
                };

                result = (object)data;
            });

            ((List<string>)((dynamic)result).Related).Add("/Photos/nydialilian01-home.jpg");
            ((List<string>)((dynamic)result).Related).Add("/Photos/nydialilian01-home.jpg");
            ((List<string>)((dynamic)result).Related).Add("/Photos/nydialilian01-home.jpg");
            ((List<string>)((dynamic)result).Related).Add("/Photos/nydialilian01-home.jpg");

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
        public JsonResult Products(string search)
        {
            IEnumerable<object> result = Enumerable.Empty<object>();
            if (string.IsNullOrEmpty(search)) search = string.Empty;
            Repository.GetAll((IQueryable<Item> response) =>
            {
                var data = (from item in response
                            where (item.Artist.Name == search || search == "") || (item.Description == search || search == "")
                            select new
                            {
                                Id = item.ItemId,
                                Artist = item.Artist.Name,
                                Name = item.Description,
                                Photo = item.PhotoUrl,
                                Tags = item.Tags.Select(tag => tag.Name),
                                Sizes = item.AvailableSizes.Select(size => size.Description)
                            }).ToList();

                result = data.OfType<object>();
            });

            var responseData = new
            {
                Artists = new List<object>().LoadFrom((IRepository<Artist>)Repository),
                Themes = new List<object>().LoadFrom((IRepository<Tag>)Repository),
                Formats = new List<object>().LoadFrom((IRepository<Size>)Repository),
                Items = result.OfType<dynamic>().Select(item => {
                    return new
                    {
                        Id = item.Id,
                        Artist = item.Artist,
                        Name = item.Name,
                        Photo = item.Photo,
                        Filters = string.Format("{0} {1} {2}", item.Artist.Replace(" ", ""),
                            string.Join(" ", (List<string>)item.Tags),
                            string.Join(" ", (List<string>)item.Sizes)
                        )
                    };
                })
            };

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = responseData
            };
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
