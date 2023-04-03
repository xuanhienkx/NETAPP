using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DSoft.MarketParser.Common
{
    [DataContract]
    public class MarketSetting
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "nameLength")]
        public int NameLength { get; set; } = 0;

        [DataMember(Name = "dateFormat")]
        [DefaultValue("dd/MM/yyyy")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DateFormat { get; set; }
        [DataMember(Name = "fileMap")]
        public string FileMapName { get; set; }

        [DataMember(Name = "messages")]
        public IList<BlockMessage> Messages { get; set; }

        [DataMember(Name = "tag")]
        [DefaultValue(0)]
        public int Tag { get; set; }
        public int DateFormatLength => DateFormat.Length;
        public int MapSize => DateFormatLength + NameLength;
    }
}
