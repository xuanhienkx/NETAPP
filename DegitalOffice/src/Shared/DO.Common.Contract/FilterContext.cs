using ProtoBuf;
using System.Collections.Generic;

namespace DO.Common.Contract
{

    public enum SortType
    {
        Descrease,
        Increase
    }

    [ProtoContract]
    public class FilterContext
    {
        [ProtoMember(1)]
        public IDictionary<string, string> Filters { get; set; }
        [ProtoMember(2)]
        public string OrderBy { get; set; }
        [ProtoMember(3)]
        public SortType SortOrder { get; set; }
        [ProtoMember(4)]
        public int Size { get; set; }
        [ProtoMember(5)]
        public int PageIndex { get; set; }
    }
}
