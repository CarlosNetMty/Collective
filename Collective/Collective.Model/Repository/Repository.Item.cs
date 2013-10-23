using System;
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
            RunOrExecute<Item>(string.Empty, contextCallback, callback);
        }
        #endregion

        #region IRepository<Item> Implementation
        IQueryable<Item> IRepository<Item>.GetAll(Context db)
        {
            return from data in db.Items select data;
        }
        Item IRepository<Item>.Get(Context db, int id) 
        { 
            return (from data in db.Items where data.ItemId == id select data).FirstOrDefault();
        }
        Item IRepository<Item>.Update(Context db, Item dataObject)
        {
            return db.Items.Add(dataObject);
        }
        #endregion
    }
}
