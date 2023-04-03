using ProtoBuf;
using System.Collections.Generic;

namespace CS.Common.Contract
{
    [ProtoContract]
    public class ListPaged<T>
    {
        [ProtoMember(1)]
        public int Total { get; set; }
        [ProtoMember(2)]
        public IList<T> List { get; set; }
    }
}
