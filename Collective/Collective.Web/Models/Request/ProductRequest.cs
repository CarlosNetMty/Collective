using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class ProductRequest
    {
        public int ItemId { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PublishingDate { get; set; }
        public bool UseAsBackground { get; set; }
        public decimal? Price { get; set; }
        public string Code { get; set; }
        public MetaInfo Meta { get; set; }
        public ItemDescription Spanish { get; set; }
        public ItemDescription English { get; set; }

        public int ArtistId { get; set; }
        public string SelectedTags { get; set; }
        public string SelectedSizes { get; set; }
        public string SelectedFrames { get; set; }
    }
}