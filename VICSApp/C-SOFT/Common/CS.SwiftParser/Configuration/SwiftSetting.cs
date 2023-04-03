using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CS.SwiftParser.Configuration
{
    [DataContract]
    public class SwiftSetting
    {
        [DataMember(Name="block_start")]
        public char BlockStart { get; set; }
        [DataMember(Name = "block_end")]
        public char BlockEnd { get; set; }
        [DataMember(Name = "block_delimiter")]
        public char BlockDelimiter { get; set; }
        [DataMember(Name = "messages")]
        public IList<Message> Messages { get; set; }
        [DataMember(Name = "responseMessageKeys")]
        public IList<MessageKey> ResponseMessageKeys { get; set; }
        [DataMember(Name = "businessUnits")]
        public IList<BusinessUnit> BusinessUnits{ get; set; }
    }
}
