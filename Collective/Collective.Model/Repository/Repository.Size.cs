﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<Size>
    {
        #region Public
        public Size Update(Size dataObject)
        {
            Func<Context, Size, Size> contextCallback = ((IRepository<Size>)this).Update;
            return RunOrExecute<Size>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Size>> callback)
        {
            Func<Context, IQueryable<Size>> contextCallback = ((IRepository<Size>)this).GetAll;
            RunOrExecute<Size>(contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<Size> IRepository<Size>.GetAll(Context db)
        {
            return from data in db.Sizes select data;
        }
        Size IRepository<Size>.Get(Context db, int id)
        {
            return (from data in db.Sizes where data.SizeId == id select data).FirstOrDefault();
        }
        Size IRepository<Size>.Update(Context db, Size dataObject)
        {
            return Update<Size>(db, dataObject.SizeId, db.Sizes, dataObject);
        }
        #endregion
    }
}
