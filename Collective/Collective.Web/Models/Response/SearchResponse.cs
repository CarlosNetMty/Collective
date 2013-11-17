using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class SearchResponse
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Sizes { get; set; }

        public string Filters { get; set; }
    }
}