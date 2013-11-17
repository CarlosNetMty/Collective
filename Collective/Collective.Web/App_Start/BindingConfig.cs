using Collective.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web
{
    public class BindingConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        public static void RegisterBindings(ModelBinderDictionary current) 
        {
           
            current.Add(typeof(ProductRequest), new ProductRequestBinder());
        }
    }
}