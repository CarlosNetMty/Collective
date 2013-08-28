using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collective.Web;
using Collective.Model;

namespace Collective.Web.Controllers
{
    public class AdminController : Controller
    {
        #region Constructors
        public IRepository Repository { get; set; }
        public AdminController(IRepository repository) 
        {
            Repository = repository;
        }
        #endregion

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
        public JsonResult ProductionDetail() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    Detail = new List<object>() 
                    {
                        new { Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large" },
                        new { Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large" },
                        new { Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large" },
                        new { Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large" },
                        new { Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large" },
                    },
                    UserId = 10001,
                    UserName = "John Doe",
                    Date = DateTime.Now.AddDays(-20),
                    StatusId = 1,
                    Status = "Open",
                    AvailableStatus = new List<object>() 
                    {
                        new { Id = 1, Name = "Open" },
                        new { Id = 2, Name = "In Progress" },
                        new { Id = 3, Name = "Closed" }
                    }
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
        public JsonResult CredentialDetail(int id)
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new List<object>()
                {
                    new {
                        Stock = new List<object>() 
                        { 
                            new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large"  },
                            new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large"  },
                            new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large"  },
                            new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large"  },
                            new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), UserId = 101, UserName = "John Doe", Status = "Open", Amount = 9999.99, Quantity = 1, Frame = "Classic", Size = "Large"  }                        
                        },
                        UserName = "John Doe",
                        FirstName = "Jorge",
                        LastName = "Does",
                        MemberSince = DateTime.Now.AddYears(-1),
                        Active = true
                    }
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
        public JsonResult StockDetail()
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    AvailableArtists = new List<object> 
                    {
                        new { Id = 1, Name = "John Doe" },
                        new { Id = 2, Name = "John Doe" },
                        new { Id = 3, Name = "John Doe" },
                        new { Id = 4, Name = "John Doe" },
                        new { Id = 5, Name = "John Doe" }
                    },
                    ArtistId = 5,
                    Price = 12345.67,
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
                    AvailableTags = new List<object>() 
                    { 
                        new { Id = 1, Name = "Architecture" },
                        new { Id = 2, Name = "Contemporary" },
                        new { Id = 3, Name = "Landscape" },
                        new { Id = 4, Name = "Portrait" },
                    },
                    Tags = new[] { 1, 2, 3 },
                    AvailableSizes = new List<object>() 
                    { 
                        new { Id = 1, Name = "Architecture" },
                        new { Id = 2, Name = "Contemporary" },
                        new { Id = 3, Name = "Landscape" },
                        new { Id = 4, Name = "Portrait" },
                    },
                    Sizes = new[] { 1, 2, 3 },
                    AvailableFrames = new List<object>() 
                    { 
                        new { Id = 1, Name = "Architecture" },
                        new { Id = 2, Name = "Contemporary" },
                        new { Id = 3, Name = "Landscape" },
                        new { Id = 4, Name = "Portrait" },
                    },
                    Frames = new[] { 1, 2, 3 },
                }
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Contributors() 
        {
            IEnumerable<object> result = Enumerable.Empty<object>();

            Repository.GetAll((IQueryable<Artist> response) => {
                var data = (from item in response
                            select new { 
                                Id = item.ArtistId,
                                Name = item.Name,
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult ContributorDetail(int id) 
        {
            Artist instance = default(Artist);
            object result = new object();

            Repository.GetAll((IQueryable<Artist> response) =>
            {
                instance = (from item in response
                            where item.ArtistId == id
                            select item)
                            .FirstOrDefault();

                var data = new
                {
                    Name = instance.Name,
                    SpanishBio = "Esta es una biografia prueba",
                    EnglishBio = "This ia a test bio",
                    Stock = instance.Items.Select((Item item) => {
                        return new { 
                            Id = item.ItemId,
                            ArtistName = instance.Name,
                            Description = item.Description,
                            Price = 12345.69
                        };
                    }).ToList()
                };

                result = (object)data;
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
