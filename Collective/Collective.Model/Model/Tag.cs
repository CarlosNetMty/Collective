using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{ 
    public class Tag : IPersistibleObject, ICatalogObject
    {
        #region Properties
        public int TagId { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public virtual List<Item> Items { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj)
        {
            Tag instance = obj as Tag;
            instance.Name = Name;
        }
        public int GetUniqueIdentifier() { return TagId; }
        public string GetDescription() { return Name; }
        #endregion
    }
}