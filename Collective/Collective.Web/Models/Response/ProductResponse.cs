using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class ProductResponse
    {
        public int ItemId { get; set; }
        public MetaInfo Meta { get; set; }

        public IEnumerable<int> Tags { get; set; }
        public IEnumerable<int> Frames { get; set; }
        public IEnumerable<int> Sizes { get; set; }

        public List<Option> AvailableArtists { get; set; }
        public List<Option> AvailableTags { get; set; }
        public List<Option> AvailableFrames { get; set; }
        public List<Option> AvailableSizes { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public decimal? Price { get; set; }
        public string Code { get; set; }
        public string PhotoUrl { get; set; }

        public ItemDescription Spanish { get; set; }
        public ItemDescription English { get; set; }
        public List<string> Related { get; set; }
    }
}