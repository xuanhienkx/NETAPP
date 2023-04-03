using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CS.SwiftParser.Configuration
{
    [DataContract]
    public struct BusinessUnit
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "businessId")]
        public string Id { get; set; }
        [DataMember(Name = "messages")]
        public IList<Message> Messages { get; set; }
        [DataMember(Name = "note")]
        public string Note { get; set; }
    }
}
