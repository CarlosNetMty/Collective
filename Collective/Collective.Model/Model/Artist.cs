using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Collective.Model
{
    public class Artist : IPersistibleObject, ICatalogObject
    {
        #region Properties
        public int ArtistId { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string SpanishBio { get; set; }
        public string EnglishBio { get; set; }
        #endregion

        #region Navigation Properties
        public virtual List<Item> Items { get; set; }
        #endregion

        #region Constructor
        public Artist() { }
        public Artist(int id) { ArtistId = id; }
        #endregion

        #region Methods

        public void Clone(IPersistibleObject obj, IRepository repository, Context context) 
        {
            Artist instance = obj as Artist;
            instance.Name = Name;
            instance.SpanishBio = SpanishBio;
            instance.EnglishBio = EnglishBio;
        }

        public int GetUniqueIdentifier() { return ArtistId; }
        public string GetDescription() { return Name; }

        #endregion
    }
}