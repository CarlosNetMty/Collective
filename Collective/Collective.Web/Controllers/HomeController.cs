using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Views & Partials
        public ActionResult Index() { return View(); }
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

            new Repository(MemoryCache.Default).GetAll((IQueryable<Item> response) => {
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
        #endregion
    }
}
