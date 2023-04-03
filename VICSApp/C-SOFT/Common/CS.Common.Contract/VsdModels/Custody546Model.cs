using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class Custody546Model 
    {
        [ProtoMember(1)]
        public long OutReferenceNumber { get; set; }
        [ProtoMember(2)]
        public string IntReferenceNumber { get; set; }
        [ProtoMember(3)]
        public string LinkMessageId { get; set; }
        [ProtoMember(4)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(5)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(6)]
        public string Code { get; set; }
        [ProtoMember(7)]
        public string IsinCode { get; set; }
        [ProtoMember(8)] 
        public string Notes { get; set; } 
        [ProtoMember(9)]
        public UnitType UnitType { get; set; }
        [ProtoMember(10)]
        public long Quantity { get; set; }
        [ProtoMember(11)]
        public string CustomerNumber { get; set; } 
        [ProtoMember(12)]
        public SettlementType SettlementType { get; set; }
        [ProtoMember(13)]
        public string SettlementCondition { get; set; }
    }
}