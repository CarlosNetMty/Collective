using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<Artist>
    {
        #region Public
        public Artist Update(Artist dataObject)
        {
            Func<Context, Artist, Artist> contextCallback = ((IRepository<Artist>)this).Update;
            return RunOrExecute<Artist>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Artist>> callback)
        {
            Func<Context, IQueryable<Artist>> contextCallback = ((IRepository<Artist>)this).GetAll;
            RunOrExecute<Artist>(CACHE_KEY_GETALL_ARTISTS, contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<Artist> IRepository<Artist>.GetAll(Context db)
        {
            return from data in db.Artists select data;
        }
        Artist IRepository<Artist>.Get(Context db, int id)
        {
            return (from data in db.Artists where data.ArtistId == id select data).FirstOrDefault();
        }
        Artist IRepository<Artist>.Update(Context db, Artist dataObject)
        {
            Artist instance = dataObject;
            Artist current = ((IRepository<Artist>)this).Get(db, dataObject.ArtistId);

            if (current != null) 
            {
                dataObject.Clone(current);
                instance = current;
            }

            return Update<Artist>(db, dataObject.ArtistId, db.Artists, instance);
            //return db.Artists.Add(dataObject);
        }
        #endregion
    }
}
