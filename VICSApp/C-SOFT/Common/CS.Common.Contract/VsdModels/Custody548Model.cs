using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class Custody548Model 
    {
        [ProtoMember(1)]
        public DateTime? CreatedDate { get; set; }
        [ProtoMember(2)]
        public string LinkMessageId { get; set; }

        [ProtoMember(3)]
        public long OutReferenceNumber { get; set; }
        [ProtoMember(4)]
        public string Status { get; set; }
        [ProtoMember(5)]
        public string ReasionCode { get; set; }
        [ProtoMember(6)]
        public string ErrorMessage { get; set; }

        [ProtoMember(7)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(8)]
        public string Code { get; set; }

        [ProtoMember(9)]
        public UnitType UnitType { get; set; }
        [ProtoMember(10)]
        public long Quantity { get; set; }
        [ProtoMember(12)]
        public string CustomerNumber { get; set; }
        [ProtoMember(13)]
        public string VsdBicode { get; set; }
        [ProtoMember(14)]
        public string Notes { get; set; }
        [ProtoMember(15)]
        public SettlementType SettlementType { get; set; }
        [ProtoMember(16)]
        public string ReceiveIndicator { get; set; }
        [ProtoMember(17)]
        public string PaymentIndicator { get; set; }
        [ProtoMember(18)]
        public string SettlementCondition { get; set; }
        [ProtoMember(19)]
        public string IsinCode { get; set; }
        [ProtoMember(20)]
        public string Currency { get; set; }
        [ProtoMember(21)]
        public decimal Amount { get; set; }
    }
}