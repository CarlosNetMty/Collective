using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void Clone(IPersistibleObject obj, IRepository repository, Context context)
        {
            Item instance = obj as Item;

            instance.ItemId = ItemId;
            instance.Price = Price;
            instance.Code = Code;

            instance.PhotoUrl = PhotoUrl;
            instance.Meta.Tags = Meta.Tags;
            instance.Meta.Title = Meta.Title;
            instance.UseAsBackground= UseAsBackground;
            instance.Meta.Description = Meta.Description;

            instance.Spanish.Description = Spanish.Description;
            instance.English.Description = English.Description;
            instance.Spanish.Name = Spanish.Name;
            instance.English.Name = English.Name;

            instance.Artist = repository.Get<Artist>(context, Artist.ArtistId);

            instance.AvailableFrames.Load(repository, context, AvailableFrames);
            instance.AvailableSizes.Load(repository, context, AvailableSizes);
            instance.Tags.Load(repository, context, Tags);

        }
        #endregion 
    }

    public class ItemDescription 
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}