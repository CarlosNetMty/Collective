using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Item : IPersistibleObject
    {
        #region Properties
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishingDate { get; set; }
        public bool UseAsBackground { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Artist Artist { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Size> AvailableSizes { get; set; }
        public virtual List<Frame> AvailableFrames { get; set; }
        #endregion
    }
}