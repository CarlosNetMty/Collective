using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository
    {
        #region public
        public T Get<T>(int id) where T : IPersistibleObject 
        {
            T contextResponse = default(T);

            RunOrExecute((Context db) => 
            {
                contextResponse = ((IRepository<T>)this).Get(db, id);
            });

            return contextResponse;
        }
        #endregion
        #region internal
        void RunOrExecute(Action<Context> callback) 
        {
            using (Context db = new Context()) { callback.Invoke(db); }
        }
        void RunOrExecute<T>(Func<Context, IQueryable<T>> contextCallback, Action<IQueryable<T>> callback) where T : IPersistibleObject 
        {
            IQueryable<T> contextResponse = Enumerable.Empty<T>().AsQueryable();
            RunOrExecute((Context db) => 
            {
                contextResponse = contextCallback.Invoke(db);
                callback.Invoke(contextResponse);
            });
        }
        T RunOrExecute<T>(Func<Context, T, T> contextCallback, T dataObject) where T : IPersistibleObject
        {
            T contextResponse = default(T);
            RunOrExecute((Context db) =>
            {
                contextResponse = contextCallback.Invoke(db, dataObject);
                db.SaveChanges();                
            });
            return contextResponse;
        }
        T Update<T>(Context db, int id, DbSet<T> collection, T dataObject) where T : class, IPersistibleObject
        {
            if (id.HasValue())
            {   
                T instance = dataObject;
                T current = ((IRepository<T>)this).Get(db, id);

                if (current != null) 
                {
                    dataObject.Clone(current);
                    instance = current;
                }

                return instance;
            }
            else 
            {
                return collection.Add(dataObject);
            }
        }
        #endregion

    }
}
