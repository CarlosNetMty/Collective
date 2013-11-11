using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Size : IPersistibleObject, ICatalogObject
    {
        #region Properties
        public int SizeId { get; set; }
        public string Description { get; set; }
        #endregion

        #region Navigation Properties
        public virtual List<Item> Items { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj)
        {
            Size instance = obj as Size;
            instance.Description = Description;
        }
        public int GetUniqueIdentifier() { return SizeId; }
        public string GetDescription() { return Description; }
        #endregion
    }
}