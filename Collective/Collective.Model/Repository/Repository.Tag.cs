using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<Tag>
    {
        #region Public
        public Tag Update(Tag dataObject)
        {
            Func<Context, Tag, Tag> contextCallback = ((IRepository<Tag>)this).Update;
            return RunOrExecute<Tag>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Tag>> callback)
        {
            Func<Context, IQueryable<Tag>> contextCallback = ((IRepository<Tag>)this).GetAll;
            RunOrExecute<Tag>(contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<Tag> IRepository<Tag>.GetAll(Context db)
        {
            return from data in db.Tags select data;
        }
        Tag IRepository<Tag>.Get(Context db, int id)
        {
            return (from data in db.Tags where data.TagId == id select data).FirstOrDefault();
        }
        Tag IRepository<Tag>.Update(Context db, Tag dataObject)
        {
            return Update<Tag>(db, dataObject.TagId, db.Tags, dataObject);
            //return db.Tags.Add(dataObject);
        }
        #endregion
    }
}
