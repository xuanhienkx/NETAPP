using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class Country
    {
        [ProtoMember(1)]
        public string Code { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
