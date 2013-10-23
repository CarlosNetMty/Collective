using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<User>
    {
        #region Public
        public User Update(User dataObject)
        {
            Func<Context, User, User> contextCallback = ((IRepository<User>)this).Update;
            return RunOrExecute<User>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<User>> callback)
        {
            Func<Context, IQueryable<User>> contextCallback = ((IRepository<User>)this).GetAll;
            RunOrExecute<User>(CACHE_KEY_GETALL_USERS, contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<User> IRepository<User>.GetAll(Context db)
        {
            return from data in db.Users select data;
        }
        User IRepository<User>.Get(Context db, int id)
        {
            return (from data in db.Users where data.UserID == id select data).FirstOrDefault();
        }
        User IRepository<User>.Update(Context db, User dataObject)
        {
            return db.Users.Add(dataObject);
        }
        #endregion
    }
}