using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collective.Web;
using Collective.Model;
using Collective.Web.Models;
using AutoMapper;

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
            return View("Index".ViewName(id), (object)id); 
        }
        public ActionResult Users(int? id) 
        {
            return View("Users".ViewName(id), id); 
        }
        public ActionResult Products(int? id) 
        {
            return View("Products".ViewName(id), id); 
        }
        public ActionResult Artists(int? id) 
        {
            return View("Artists".ViewName(id), id); 
        }
        public ActionResult Cover() { return View(); }
        public ActionResult Content() { return View(); }
        public ActionResult Setting() { return View(); }
                
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
        public JsonResult Configuration() 
        {
            Setting instance = Repository.Get<Setting>(1);
            object result = new object();

            if (instance != null)
            {
                var data = new SettingResponse
                {
                    SettingId = instance.SettingId,
                    Meta = instance.Meta
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
        /// <returns></returns>
        public JsonResult StaticContent() 
        {
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new StaticContentResponse
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
                    ItemId = 10001,
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
            IEnumerable<CredentialResponse> result = Enumerable.Empty<CredentialResponse>();

            Repository.GetAll((IQueryable<User> response) =>
            {
                var data = (from item in response
                            select item).ToList();

                result = data.Select(item => Mapper.Map<User, CredentialResponse>(item));
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
            User instance = Repository.Get<User>(id);
            object result = new object();

            if (instance != null)
            {
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
                                Description = item.English.Name,
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
            Item instance = Repository.Get<Item>(id);
            object result = new object();

            if (instance != null)
            {
                var data = new
                {
                    ItemId = instance.ItemId,
                    Meta = instance.Meta,
                    AvailableArtists = new List<Option>().LoadFrom<Artist>(Repository, false),
                    AvailableTags = new List<Option>().LoadFrom<Tag>(Repository, false),
                    Tags = instance.Tags.Select(item => item.TagId).ToList(),
                    AvailableFrames = new List<Option>().LoadFrom<Frame>(Repository, false),
                    Frames = instance.AvailableFrames.Select(item => item.FrameId).ToList(),
                    AvailableSizes = new List<Option>().LoadFrom<Size>(Repository, false),
                    Sizes = instance.AvailableSizes.Select(item => item.SizeId).ToList(),
                    ArtistId = instance.Artist.ArtistId,
                    Code = instance.Code,
                    Price = instance.Price,
                    PhotoURL = instance.PhotoUrl,
                    UseAsCover = instance.UseAsBackground,
                    Spanish = instance.Spanish,
                    English = instance.English
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
            Artist instance = Repository.Get<Artist>(id);
            object result = new object();

            if (instance != null)
            {
                var data = new
                {
                    ArtistId = instance.ArtistId,
                    Name = instance.Name,
                    SpanishBio = instance.SpanishBio,
                    EnglishBio = instance.EnglishBio,
                    Stock = instance.Items.Select((Item item) =>
                    {
                        return new
                        {
                            Id = item.ItemId,
                            ArtistName = instance.Name,
                            Description = item.English.Name,
                            Price = item.Price
                        };
                    }).ToList()
                };

                result = (object)data;
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
        #endregion

        #region Save & Update

        [HttpPost]
        public JsonResult SaveContact(Artist dataObject) 
        {
            return Extensions.Execute(() => 
            { 
                Repository.Update(dataObject); 
            });
        }

        [HttpPost]
        public JsonResult SaveProduct(Item dataObject) 
        {
            return Extensions.Execute(() =>
            {
                dataObject.Meta.Title = HttpContext.Request.Form["Meta[Title]"];
                dataObject.Meta.Description = HttpContext.Request.Form["Meta[Description]"];
                dataObject.Meta.Tags = HttpContext.Request.Form["Meta[Tags]"];
                //TODO: Add ModelBinder
                dataObject.Spanish.Name = HttpContext.Request.Form["Spanish[Name]"];
                dataObject.Spanish.Description = HttpContext.Request.Form["Spanish[Description]"];

                dataObject.English.Name = HttpContext.Request.Form["English[Name]"];
                dataObject.English.Description = HttpContext.Request.Form["English[Description]"];

                Repository.Update(dataObject);
            });         
        }

        [HttpPost]
        public JsonResult SaveSetting(Setting dataObject) 
        {
            return Extensions.Execute(() =>
            {
                dataObject.Meta.Title = HttpContext.Request.Form["Meta[Title]"];
                dataObject.Meta.Description = HttpContext.Request.Form["Meta[Description]"];
                dataObject.Meta.Tags = HttpContext.Request.Form["Meta[Tags]"];
                //TODO: Add ModelBinder

                Repository.Update(dataObject);
            });
        }

        [HttpPost]
        public JsonResult RemoveBackground(int id) 
        {
            return Extensions.Execute(() => 
            {
                Item element = Repository.Get<Item>(id);
                element.UseAsBackground = false;

                Repository.Update(element); 
            });
        }

        #endregion
    }
}
