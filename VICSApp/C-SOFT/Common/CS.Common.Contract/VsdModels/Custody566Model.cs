using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    public class Custody566Model : Custody565Model
    {
        [ProtoMember(1)]
        public string OutReferenceNumber { get; set; }
        [ProtoMember(2)]
        public DateTime? SettlementDate { get; set; }
        [ProtoMember(3)]
        public string LinkedMessageId { get; set; }
        [ProtoMember(4)]
        public string BalanceElig { get; set; }
        [ProtoMember(5)]
        public long Amount { get; set; }
        [ProtoMember(6)]
        public CrdbType Debit { get; set; }
        [ProtoMember(7)]
        public string IsinCodeDebit { get; set; }
        [ProtoMember(8)]
        public string CodeDebit { get; set; }
        [ProtoMember(9)]
        public UnitType UnitTypeDebit { get; set; }
        [ProtoMember(10)]
        public long QuantityDebit { get; set; }
        [ProtoMember(11)]
        public DateTime? DateAccountingDebit { get; set; }
        [ProtoMember(12)]
        public CrdbType Credit { get; set; }
        [ProtoMember(13)]
        public string IsinCodeCredit { get; set; }
        [ProtoMember(14)]
        public string CodeCredit { get; set; }
        [ProtoMember(15)]
        public UnitType UnitTypeCredit { get; set; }
        [ProtoMember(16)]
        public long QuantityCredit { get; set; }
        [ProtoMember(17)]
        public DateTime? DateAccountingCredit { get; set; }
        [ProtoMember(18)]
        public string Notes { get; set; } 

    }
}