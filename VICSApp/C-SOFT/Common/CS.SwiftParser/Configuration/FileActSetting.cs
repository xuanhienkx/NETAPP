using CS.Common.Std.Configuration;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CS.SwiftParser.Configuration
{
    [DataContract]
    public struct FileActSetting
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "csvFields")]
        public IList<Part> Fields { get; set; }
        [DataMember(Name = "parameters")]
        public IList<Part> Parameter { get; set; }
    }
}
