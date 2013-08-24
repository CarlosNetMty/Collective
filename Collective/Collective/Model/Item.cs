using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Collective.DataTransferObjects
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int ItemID { get; set; }
        [DataMember]
        public int ArtistID { get; set; }
        [DataMember]
        public string ArtistName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }
        [DataMember]
        public DateTime PublishingDate { get; set; }
    }
}