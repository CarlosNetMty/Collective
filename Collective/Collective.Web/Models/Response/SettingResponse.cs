using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class SettingResponse
    {
        public int SettingId { get; set; }
        public MetaInfo Meta { get; set; }
    }
}