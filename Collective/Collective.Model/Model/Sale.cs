using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public class Sale : IPersistibleObject
    {
        #region Properties
        public Guid SaleId { get; set; }
        public DateTime Date { get; set; }

        public User Client { get; set; }
        #endregion
    }
}
