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
    }
}
