using DSoft.Common.Shared.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DSoft.MarketParser.Common
{
    [DataContract]
    public class BlockMessage
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "updateType")]
        [DefaultValue(PrsUpdateType.AddMore)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public PrsUpdateType UpdateType { get; set; }
        [DataMember(Name = "patternFormat")]
        public string PatternFormat { get; set; }

        [DataMember(Name = "parts")]
        public IList<Part> Parts { get; set; }        
        public int PartSize => Parts.Sum(x => x.Length);
    }   
}
