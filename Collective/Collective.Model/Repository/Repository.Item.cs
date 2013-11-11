using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Collective.Model
{
    public partial class Repository : IRepository<Item>
    {
        #region Public
        public Item Update(Item dataObject)
        {
            Func<Context, Item, Item> contextCallback = ((IRepository<Item>)this).Update;
            return RunOrExecute<Item>(contextCallback, dataObject);
        }
        public void GetAll(Action<IQueryable<Item>> callback)
        {
            Func<Context, IQueryable<Item>> contextCallback = ((IRepository<Item>)this).GetAll;
            RunOrExecute<Item>(contextCallback, callback);
        }
        #endregion

        #region IRepository<Item> Implementation
        IQueryable<Item> IRepository<Item>.GetAll(Context db)
        {
            return (from data in db.Items select data)
                //Explicit property load/include
                .Include(item => item.Artist)
                .Include(item => item.AvailableSizes)
                .Include(item => item.AvailableFrames)
                .Include(item => item.Tags);
        }
        Item IRepository<Item>.Get(Context db, int id) 
        {
            return (from data in db.Items where data.ItemId == id select data)
                //Explicit property load/include
                .Include(item => item.Artist)
                .Include(item => item.AvailableFrames)
                .Include(item => item.AvailableSizes)
                .Include(item => item.Tags)
                //Select first or default
                .FirstOrDefault();
        }
        Item IRepository<Item>.Update(Context db, Item dataObject)
        {
            return Update<Item>(db, dataObject.ItemId, db.Items, dataObject);
        }
        #endregion
    }
}
