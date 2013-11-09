using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public partial class Repository : IRepository<Setting>
    {
        #region Public
        public Setting Update(Setting dataObject)
        {
            Func<Context, Setting, Setting> contextCallback = ((IRepository<Setting>)this).Update;
            return RunOrExecute<Setting>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Setting>> callback)
        {
            Func<Context, IQueryable<Setting>> contextCallback = ((IRepository<Setting>)this).GetAll;
            RunOrExecute<Setting>(CACHE_KEY_GETALL_SETTINGS, contextCallback, callback);
        }
        #endregion

        #region IRepository<Setting> Implementation
        IQueryable<Setting> IRepository<Setting>.GetAll(Context db)
        {
            return from data in db.Settings select data;
        }
        Setting IRepository<Setting>.Get(Context db, int id)
        {
            return (from data in db.Settings where data.SettingId == id select data).FirstOrDefault();
        }
        Setting IRepository<Setting>.Update(Context db, Setting dataObject)
        {
            return db.Settings.Add(dataObject);
        }
        #endregion
    }
}
