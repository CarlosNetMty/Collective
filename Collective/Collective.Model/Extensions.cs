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
        public static void Store<T>(this ObjectCache objectCache, string key, Func<Context, IQueryable<T>> contextCallback, Action<IQueryable<T>> callback) 
        {
            IQueryable<T> contextResponse = Enumerable.Empty<T>().AsQueryable();
            using (Context db = new Context())
            {
                contextResponse = contextCallback.Invoke(db);

                objectCache.Add(new CacheItem(key, contextResponse.ToList().AsQueryable()),
                    new CacheItemPolicy()
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(2)
                    });

                callback.Invoke(contextResponse);
            }
        }

        public static T Store<T>(Func<Context, T, T> contextCallback, T dataObject)
        {
            T contextResponse = default(T);
            using (Context db = new Context())
            {
                contextResponse = contextCallback.Invoke(db, dataObject);
                db.SaveChanges();
            }

            return contextResponse;
        }

        public static string Get(this Resources resource)
        {
            using (Context db = new Context())
            {
                Resource element = db
                .Resources
                .FirstOrDefault(item => item.ResourceId == (int)resource);

                if (element != null && element.ResourceId > 0)
                    return element.Value;
            }
            return string.Empty;
        }
    }

    public enum Resources
    {
        AboutUS = 1,
        TermsAndConditions = 2
    }
}
