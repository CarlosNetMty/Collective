﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Collective.DataTransferObjects
{
    [DataContract]
    public class Artist
    {
        [DataMember]
        public int ArtistId { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}