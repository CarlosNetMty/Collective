using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Collective.DataTransferObjects
{
    [DataContract]
    public class Tag
    {
        [DataMember]
        public int TagId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}