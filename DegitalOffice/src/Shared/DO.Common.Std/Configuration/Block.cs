using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DO.Common.Std.Configuration
{
    [DataContract]
    public class Block
    {
        [DataMember(Name = "id")]
        public string Identifier { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "start")]
        public string Start { get; set; }
        [DataMember(Name = "end")]
        public string End { get; set; }
        [DataMember(Name = "fields")]
        public IList<Field> Fields { get; set; }
        [DataMember(Name = "default")]
        public string Default { get; set; }
        [DataMember(Name = "ignorable")]
        public bool Ignorable { get; set; }
    }
}
