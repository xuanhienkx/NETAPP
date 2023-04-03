using DO.Common.Std.Configuration;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DO.MarketParser.Configuration
{

    [DataContract]
    public class PrsSetting
    {
        [DataMember(Name = "nameLength")]
        public int NameLength { get; set; }

        [DataMember(Name = "dateFormat")]
        [DefaultValue("dd/MM/yyyy")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DateFormat { get; set; }
        [DataMember(Name = "fileMap")]
        public string FileMapName { get; set; }

        [DataMember(Name = "messages")]
        public IList<PrsMessage> Messages { get; set; }

        public int DateFormatLength => DateFormat.Length;
        public int MapSize => DateFormatLength + NameLength;
    }
    [DataContract]
    public class PrsMessage
    {
        [DataMember(Name = "messageName")]
        public string MessageName { get; set; }

        [DataMember(Name = "updateType")]
        [DefaultValue(PrsUpdateType.AddMore)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public PrsUpdateType UpdateType { get; set; }

        [DataMember(Name = "parts")]
        public IList<PrsPart> Parts { get; set; }

        public int PartSize => Parts.Sum(x => x.Length);
    }
}