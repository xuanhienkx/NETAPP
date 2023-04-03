using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    public interface IVsdMessageResponse
    { 
    }
    [ProtoContract]
    public class Custody544Model : IVsdMessageResponse
    {
        public Custody544Model()
        {
            SettlementDate = DateTime.Now;
            SubType = AssetSubType.CommonStock;
        }
        [ProtoMember(1)]
        public string OutReferenceNumber { get; set; }
        [ProtoMember(2)]
        public string LinkMessageId { get; set; }
        [ProtoMember(3)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(4)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(5)]
        public string Code { get; set; }
        [ProtoMember(6)]
        public string IsinCode { get; set; }
        [ProtoMember(7)]
        public ActivityType ActivityType { get; set; }
        [ProtoMember(8)]
        public AssetSubType SubType { get; set; }
        [ProtoMember(9)]
        public string Notes { get; set; }
        [ProtoMember(10)]
        public UnitType UnitType { get; set; }
        [ProtoMember(11)]
        public long Quantity { get; set; }
        [ProtoMember(12)]
        public string CustomerNumber { get; set; }
        [ProtoMember(13)]
        public string SettlementCondition { get; set; }
        [ProtoMember(14)]
        public SettlementType SettlementType { get; set; }
    }
}