using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Constructors
        public IRepository Repository { get; set; }
        public HomeController(IRepository repository) 
        {
            Repository = repository;
        }
        #endregion

        #region Views & Partials
        public ActionResult Index() { return View(); }
        public ActionResult Gallery() { return View(); }
        public PartialViewResult Header() { return PartialView(); }
        public PartialViewResult Footer() { return PartialView(); }
        #endregion

        #region Data
        public JsonResult CurrentUser()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new 
                {
                    IsLogged = true,
                    FirstName = "Carlos",
                    LastName = "Martinez",
                    IsAdministrator = true
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

        #region Actions

        public JsonResult LogIn(string userName, string password) 
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    IsAuthenticated = true,
                    User = new 
                    {
                        IsLogged = true,
                        FirstName = "Carlos",
                        LastName = "Martinez",
                        IsAdministrator = true
                    }
                }
            };
        }

        #endregion

    }
}
