using System;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public class ClearingCompleteConfirmationModel
    {
        [ProtoMember(1)]
        public DateTime? TradingDate { get; set; }
        [ProtoMember(2)]
        public string Prerio { get; set; }
        [ProtoMember(3)]
        public string Content { get; set; }
    }
}
