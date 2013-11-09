using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public class Resource : IPersistibleObject
    {
        #region Properties
        public int ResourceId { get; set; }
        public string Value { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj)
        {
            Resource instance = obj as Resource;
            instance.Value = Value;
        }
        #endregion
    }
}
