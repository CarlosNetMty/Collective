using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Item : IPersistibleObject, IMetaDefinable
    {
        #region Properties
        public int ItemId { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishingDate { get; set; }
        public bool UseAsBackground { get; set; }
        public decimal? Price { get; set; }
        public string Code { get; set; }
        public MetaInfo Meta { get; set; }
        public ItemDescription Spanish { get; set; }
        public ItemDescription English { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Artist Artist { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Size> AvailableSizes { get; set; }
        public virtual List<Frame> AvailableFrames { get; set; }
        #endregion

        #region Methods
        public void Clone(IPersistibleObject obj)
        {
            Item instance = obj as Item;
            instance.PhotoUrl = PhotoUrl;
            instance.UseAsBackground= UseAsBackground;
            instance.Price = Price;
            instance.Code = Code;
            instance.Meta.Description = Meta.Description;
            instance.Meta.Tags = Meta.Tags;
            instance.Meta.Title = Meta.Title;
            instance.Spanish.Description = Spanish.Description;
            instance.Spanish.Name = Spanish.Name;
            instance.English.Description = English.Description;
            instance.English.Name = English.Name;
        }
        #endregion
    }

    public class ItemDescription 
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}