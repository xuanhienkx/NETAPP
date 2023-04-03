using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CS.Common.Std.Configuration
{

    [DataContract]
    public struct Part
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "type")]
        [DefaultValue(CSValueType.String)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public CSValueType Type { get; set; }
        [DataMember(Name = "format")]
        public string Format { get; set; }
        [DataMember(Name = "length")]
        public int Length { get; set; }
        [DataMember(Name = "line")]
        [DefaultValue(1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Line { get; set; }
        [DataMember(Name = "default")]
        public string Default { get; set; }
        [DataMember(Name = "optional")]
        public bool IsOptional { get; set; }
        [DataMember(Name = "start")]
        public string Start { get; set; }
        [DataMember(Name = "end")]
        public string End { get; set; }
    }
}
