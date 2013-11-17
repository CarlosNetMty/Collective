using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collective.Web.Models
{
    public class ActionResponse
    {
        public enum ActionResponseType 
        { 
            Failed,
            Succeed 
        }

        public ActionResponseType Result { protected get; set; }
        public string Message { protected get; set; }
        public object Data { protected get; set; }

        public JsonResult ToJSON() 
        {
            return new JsonResult 
            { 
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = this
            };
        }

        public JsonResult ToJSON(object data)
        {
            Data = data;
            return ToJSON();
        }

        ActionResponse(ActionResponseType type) 
        {
            Result = type;
            switch(type)
            {
                case ActionResponseType.Succeed:
                    Message = "Succeed"; break;
                case ActionResponseType.Failed :
                    Message = "Failed"; break;
                default :
                    Message = "Not defined"; break;
            }
        }

        public static ActionResponse Succeed 
        {
            get  { return new ActionResponse(ActionResponseType.Succeed); }
        }

        public static ActionResponse Failed
        {
            get  { return new ActionResponse(ActionResponseType.Failed); }
        }
    }
}