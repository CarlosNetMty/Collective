using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collective.Web.Models
{
    public class SearchContextResponse
    {
        public List<Option> Artists { get; set; }
        public List<Option> Themes { get; set; }
        public List<Option> Formats { get; set; }
        public List<SearchResponse> Items { get; set; }
    }
}