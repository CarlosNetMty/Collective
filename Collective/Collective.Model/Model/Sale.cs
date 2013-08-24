using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public class Sale : IPersistibleObject
    {
        #region Properties
        [Key] public Guid SaleId { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Navigation Properties
        public virtual User Client { get; set; }
        public virtual List<SaleDetail> Details { get; set; }
        #endregion
    }
}
