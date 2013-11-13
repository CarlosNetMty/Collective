using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public class SaleDetail : IPersistibleObject
    {
        #region Properties
        [Key] public long SaleDetailId { get; set; }
        public int Quantity { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Sale Sale { get; set; }
        public virtual Item Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Frame Frame { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj, IRepository repository, Context context)
        {
            SaleDetail instance = obj as SaleDetail;
            instance.Quantity = Quantity;
        }
        #endregion
    }
}
