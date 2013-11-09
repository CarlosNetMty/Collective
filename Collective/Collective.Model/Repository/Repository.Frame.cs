using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<Frame>
    {
        #region Public
        public Frame Update(Frame dataObject)
        {
            Func<Context, Frame, Frame> contextCallback = ((IRepository<Frame>)this).Update;
            return RunOrExecute<Frame>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Frame>> callback)
        {
            Func<Context, IQueryable<Frame>> contextCallback = ((IRepository<Frame>)this).GetAll;
            RunOrExecute<Frame>(CACHE_KEY_GETALL_FRAMES, contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<Frame> IRepository<Frame>.GetAll(Context db)
        {
            return from data in db.Frames select data;
        }
        Frame IRepository<Frame>.Get(Context db, int id)
        {
            return (from data in db.Frames where data.FrameId == id select data).FirstOrDefault();
        }
        Frame IRepository<Frame>.Update(Context db, Frame dataObject)
        {
            return Update<Frame>(db, dataObject.FrameId, db.Frames, dataObject);
            //return db.Frames.Add(dataObject);
        }
        #endregion
    }
}