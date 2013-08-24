using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collective.Web;

namespace Collective.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Views & Partials
        public ActionResult Index(string id) 
        {
            string viewName = string.IsNullOrEmpty(id) ? "Index" : "IndexDetail";
            return View(viewName, (object)id); 
        }
        public ActionResult Users(int? id) 
        {
            string viewName = !id.HasValue ? "Users" : "UsersDetail";
            return View(viewName, id); 
        }
        public ActionResult Products(int? id) 
        {
            string viewName = !id.HasValue ? "Products" : "ProductsDetail";
            return View(viewName, id); 
        }
        public ActionResult Artists(int? id) 
        {
            string viewName = !id.HasValue ? "Artists" : "ArtistsDetail";
            return View(viewName, id); 
        }
        public ActionResult Cover() { return View(); }
        public ActionResult Content() { return View(); }

        
        public ActionResult Logout() 
        {
            //Session.Abandon();
            return Redirect("~/");
        }

        public PartialViewResult Sidebar() { return PartialView(); }
        public PartialViewResult Header() { return PartialView(); }
        public PartialViewResult Footer() { return PartialView(); }
        #endregion

        #region Data
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Production() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new List<object>() 
                { 
                    new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                    new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Credentials() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new List<object>() 
                { 
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" },
                    new { Id = 10001, UserName = "John Doe", Email = "test@testServer.com", Status = "Open" }
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Stock() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new List<object>()
                {
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 },
                    new { Id = 10001, ArtistName = "John Doe", Description = "Infinity", Price = 9999.99 }
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Contributors() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new List<object>() 
                { 
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                    new { Id = 10001, Name = "Joh Doe", Bio = "Lorem ipsum est ..." },
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        public JsonResult ContributorDetail(int id) 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    Sales = new List<object>() 
                    { 
                        new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                        new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                        new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                        new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  },
                        new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99  }                        
                    },
                    UserName = "John Doe",
                    MemberSince = DateTime.Now.AddYears(-1),
                    Active = true
                },
            };
        }
        #endregion
    }
}
