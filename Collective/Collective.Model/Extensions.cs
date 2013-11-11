using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public static class Extensions
    {
        #region Resources
        public static string GetResource(this Resources resource)
        {
            return GetResource((int)resource);
        }
        public static string GetResource(int resource) 
        {
            using (Context db = new Context())
            {
                Resource element = db
                    .Resources
                    .Where(item => item.ResourceId == resource)
                    .FirstOrDefault();

                if (element != null && element.ResourceId > 0)
                    return element.Value;
            }

            return string.Empty;
        }
        #endregion
        #region General
        public static bool HasValue(this int currentValue) 
        {
            return currentValue > 0;
        }
        #endregion
    }

    public enum Resources
    {
        AboutUS = 1,
        TermsAndConditions = 2
    }
}
