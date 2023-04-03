using System.Collections.Generic;
using System.Runtime.Serialization;
using CS.Common.Std.Configuration;

namespace CS.SwiftParser.Configuration
{
    [DataContract]
    public class MessageKey
    {
        [DataMember(Name = "messageId")]
        public string MessageId { get; set; }
        [DataMember(Name = "keys")]
        public IList<FieldKey> FieldKeys { get; set; }
    }
}
