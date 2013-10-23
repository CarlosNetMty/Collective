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

        public JsonResult StaticContent() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                { 
                    About = Model.Resources.AboutUS.GetResource(),
                    Conditions = Model.Resources.TermsAndConditions.GetResource()
                }
            };
        }
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
            IEnumerable<object> result = Enumerable.Empty<object>();

            Repository.GetAll((IQueryable<User> response) =>
            {
                var data = (from item in response
                            select new
                            {
                                Id = item.UserID,
                                UserName = item.Name,
                                Email = item.Email,
                                Status = item.IsActive ? "Active" : "Inactive" 
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
        public JsonResult CredentialDetail(int id)
        {
            User instance = default(User);
            object result = new object();

            Repository.GetAll((IQueryable<User> response) =>
            {
                instance = (from item in response
                            where item.UserID == id
                            select item)
                            .FirstOrDefault();

                var data = new
                {
                    UserID = instance.UserID,
                    Active = instance.IsActive,
                    IsAdministrator = instance.IsAdministrator,
                    Name = instance.Name,
                    Email = instance.Email,
                    History = new List<object>()
                    {
                        new { Id = 10001, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), Status = "Open", Amount = 9999.99, Frame = "Classic", Size = "Large"  },
                        new { Id = 10002, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), Status = "Open", Amount = 9999.99, Frame = "Classic", Size = "Large"  },
                        new { Id = 10003, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), Status = "Open", Amount = 9999.99, Frame = "Classic", Size = "Large"  },
                        new { Id = 10004, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), Status = "Open", Amount = 9999.99, Frame = "Classic", Size = "Large"  },
                        new { Id = 10005, Date = DateTime.Now.AddDays(-5).ToString("MMMM dd, yyyy"), Status = "Open", Amount = 9999.99, Frame = "Classic", Size = "Large"  }
                    }
                };

                result = (object)data;
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
        public JsonResult Stock() 
        {
            IEnumerable<object> result = Enumerable.Empty<object>();

            Repository.GetAll((IQueryable<Item> response) =>
            {
                var data = (from item in response
                            select new
                            {
                                Id = item.ItemId,
                                ArtistName = item.Artist.Name,
                                Description = item.Description,
                                Price = item.Price
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
        public JsonResult StockDetail(int id)
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
                    Price = instance.Price,
                    PhotoURL = instance.PhotoUrl,
                    UseAsCover = instance.UseAsBackground,
                    Spanish = new
                    {
                        Name = "Panorama",
                        Description = "Esta es una prueba de un paisaje"
                    },
                    English = new
                    {
                        Name = "Landscape",
                        Description = "This is a landscape test"
                    }
                };

                result = (object)data;
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
                    SpanishBio = instance.SpanishBio,
                    EnglishBio = instance.EnglishBio,
                    Stock = instance.Items.Select((Item item) => {
                        return new { 
                            Id = item.ItemId,
                            ArtistName = instance.Name,
                            Description = item.Description,
                            Price = item.Price
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

        #region Save & Update

        [HttpPost]
        public JsonResult SaveContact(Artist artist) 
        {
            Repository.Update(artist);
            
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new 
                { 
                    Result = 1
                }
            };
        }

        [HttpPost]
        public JsonResult RemoveBackground(int id) 
        {

            Item element = default(Item);
            Repository.GetAll((IQueryable<Item> response) =>
            {
                element = (from item in response
                            where item.ItemId == id
                            select item).FirstOrDefault();
            });

            element.UseAsBackground = false;
            Repository.Update(element);

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { Success = true }
            };
        }

        #endregion
    }

    public static class Extensions
    {
        public static List<object> LoadFrom(this List<object> collection, IRepository<Artist> repository, bool appendDefault = true)
        {
            if(appendDefault) collection.Add(new { Id = -1, Name = "*" });
            Action<IQueryable<Artist>> callback = (IQueryable<Artist> data) =>
            {
                foreach (var item in data)
                    collection.Add(new { Id = item.ArtistId, Name = item.Name });
            };

            ((IRepository)repository).GetAll(callback);
            return collection;
        }

        public static List<object> LoadFrom(this List<object> collection, IRepository<Frame> repository, bool appendDefault = true)
        {
            if (appendDefault) collection.Add(new { Id = -1, Name = "*" });
            Action<IQueryable<Frame>> callback = (IQueryable<Frame> data) =>
            {
                foreach (var item in data)
                    collection.Add(new { Id = item.FrameId, Name = item.Description });
            };

            ((IRepository)repository).GetAll(callback);
            return collection;
        }

        public static List<object> LoadFrom(this List<object> collection, IRepository<Tag> repository, bool appendDefault = true)
        {
            if (appendDefault) collection.Add(new { Id = -1, Name = "*" });
            Action<IQueryable<Tag>> callback = (IQueryable<Tag> data) =>
            {
                foreach (var item in data)
                    collection.Add(new { Id = item.TagId, Name = item.Name });
            };

            ((IRepository)repository).GetAll(callback);
            return collection;
        }

        public static List<object> LoadFrom(this List<object> collection, IRepository<Size> repository, bool appendDefault = true)
        {
            if (appendDefault) collection.Add(new { Id = -1, Name = "*" });
            Action<IQueryable<Size>> callback = (IQueryable<Size> data) =>
            {
                foreach (var item in data)
                    collection.Add(new { Id = item.SizeId, Name = item.Description });
            };

            ((IRepository)repository).GetAll(callback);
            return collection;
        }

        public static string AsString(this DateTime value)
        {
            return value.ToString("MMMM dd, yyyy");
        }
    }
}
