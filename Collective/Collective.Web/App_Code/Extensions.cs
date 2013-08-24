using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web
{
    public static class Extensions
    {
        public static string AsString(this DateTime value)
        {
            return value.ToString("MMMM dd, yyyy");
        }
    }
}