using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Artist : IPersistibleObject
    {
        #region Properties
        public int ArtistId { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public virtual List<Item> Items { get; set; }
        #endregion
    }
}