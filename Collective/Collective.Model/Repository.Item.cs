﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository<Item>
    {
        #region Public
        public Item Update(Item dataObject)
        {
            Func<Context, Item, Item> contextCallback = ((IRepository<Item>)this).Update;
            return RunOrExecute<Item>(contextCallback, dataObject);
            //return RunOrExecute<Artist>(((Context db, Artist dataObject) => { return db.Artists.Add(dataObject); }));
        }
        public void GetAll(Action<IQueryable<Item>> callback)
        {
            Func<Context, IQueryable<Item>> contextCallback = ((IRepository<Item>)this).GetAll;
            RunOrExecute<Item>(CACHE_KEY_GETALL_ARTISTS, contextCallback, callback);
        }
        #endregion

        #region IRepository<Artist> Implementation
        IQueryable<Item> IRepository<Item>.GetAll(Context db)
        {
            return from data in db.Items select data;
        }
        Item IRepository<Item>.Update(Context db, Item dataObject)
        {
            return db.Items.Add(dataObject);
        }
        #endregion
    }
}
