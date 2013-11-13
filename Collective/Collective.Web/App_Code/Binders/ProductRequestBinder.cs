using Collective.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRequestBinder : DefaultModelBinder, IModelBinder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            ProductRequest resultObject = base.CreateModel(controllerContext, bindingContext, modelType) as ProductRequest;

            NameValueCollection form = controllerContext.HttpContext.Request.Form;
            
            if (resultObject.Meta == null) 
                resultObject.Meta = new Model.MetaInfo();
            
            resultObject.Meta.Title = form["Meta[Title]"];
            resultObject.Meta.Description = form["Meta[Description]"];
            resultObject.Meta.Tags = form["Meta[Tags]"];

            if (resultObject.Spanish == null)
                resultObject.Spanish = new Model.ItemDescription();

            resultObject.Spanish.Name = form["Spanish[Name]"];
            resultObject.Spanish.Description = form["Spanish[Description]"];

            if (resultObject.English == null)
                resultObject.English = new Model.ItemDescription();

            resultObject.English.Name = form["English[Name]"];
            resultObject.English.Description = form["English[Description]"];

            return resultObject;
        }
    }
}