﻿using Collective.Model;
using Collective.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web
{
    public static class Extensions
    {
        #region General

        public static string AsString(this DateTime value)
        {
            return value.ToString("MMMM dd, yyyy");
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static byte[] StreamToByteArray(Stream stream)
        {
            if (stream is MemoryStream)
            {
                return ((MemoryStream)stream).ToArray();
            }
            else
            {
                // Jon Skeet's accepted answer 
                return ReadFully(stream);
            }
        }

        public static string SaveAs(this HttpPostedFileBase file) 
        {
            DateTime date = DateTime.Now;
            //string fileName = string.Format("{0}{1}{2}{3}{4}{5}.jpg", 
            //    date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);

            string fileName = HttpContext.Current.Request.Form["fileName"];

            string path = HttpContext.Current.Server.MapPath("~/Photos");

            //file.SaveAs(string.Format("{0}\\{1}", path, fileName));
            File.WriteAllBytes(string.Format("{0}\\{1}", path, fileName), ReadFully(file.InputStream));

            return fileName;
        }

        public static JsonResult Execute(Action callback) 
        {
            try
            {
                callback.Invoke();
                return Models.ActionResponse.Succeed.ToJSON();
            }
            catch (Exception ex)
            {
                return Models.ActionResponse.Failed.ToJSON();
                throw ex;
            }; 
        }

        public static JsonResult Execute(Func<object> callback)
        {
            try
            {
                Object data = callback.Invoke();
                return Models.ActionResponse.Succeed.ToJSON(data);
            }
            catch (Exception ex)
            {
                return Models.ActionResponse.Failed.ToJSON();
                throw ex;
            };
        }

        public static string ViewName(this string name, int? id) 
        {
            return !id.HasValue ? name : string.Format("Detail/{0}", name);
        }

        public static string ViewName(this string name, string id)
        {
            return string.IsNullOrEmpty(id) ? name : string.Format("Detail/{0}", name);
        }

        #endregion
        #region Data

        public static List<Option> LoadFrom<T>(this List<T> source, bool appendEmpty = true) where T : ICatalogObject
        {
            List<Option> collection = new List<Option>();

            if (appendEmpty)
                collection.Add(new Option { Id = -1, Name = "*" });

            source.ToList().ForEach((item) => {
                collection.Add(new Option
                        {
                            Id = item.GetUniqueIdentifier(),
                            Name = item.GetDescription()
                        });
            });

            return collection;
        }

        public static List<Option> LoadFrom<T>(this List<Option> collection, 
            IRepository repository, bool appendEmpty = true) where T : ICatalogObject
        {
            if (appendEmpty) 
                collection.Add(new Option{ Id = -1, Name = "*" });

            Action<IQueryable<T>> callback = (IQueryable<T> data) => 
            {
                foreach (var item in data)
                    collection.Add(new Option
                        { 
                            Id = item.GetUniqueIdentifier(), 
                            Name = item.GetDescription() 
                        });
            };

            repository.GetAll((dynamic)callback);
            return collection;
        }

        public static void LoadFrom(this Item item, ProductRequest request) 
        {
            if (string.IsNullOrEmpty(request.SelectedFrames)) request.SelectedFrames = string.Empty;
            if (string.IsNullOrEmpty(request.SelectedSizes)) request.SelectedSizes = string.Empty;
            if (string.IsNullOrEmpty(request.SelectedTags)) request.SelectedTags = string.Empty;

            item.AvailableFrames = request
                .SelectedFrames.Split(',')
                .Select(subItem => new Frame { FrameId = int.Parse(subItem) })
                .ToList();

            item.AvailableSizes = request
                .SelectedSizes.Split(',')
                .Select(subItem => new Size { SizeId = int.Parse(subItem) })
                .ToList();

            item.Tags = request
                .SelectedTags.Split(',')
                .Select(subItem => new Tag { TagId = int.Parse(subItem)})
                .ToList();

        }

        #endregion
    }
}