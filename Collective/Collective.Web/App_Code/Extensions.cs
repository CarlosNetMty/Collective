﻿using Collective.Model;
using Collective.Web.Models;
using System;
using System.Collections.Generic;
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

        public static string ViewName(this string name, int? id) 
        {
            return !id.HasValue ? name : string.Format("{0}Detail", name);
        }

        public static string ViewName(this string name, string id)
        {
            return string.IsNullOrEmpty(id) ? name : string.Format("{0}Detail", name);
        }

        #endregion
        #region Data

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