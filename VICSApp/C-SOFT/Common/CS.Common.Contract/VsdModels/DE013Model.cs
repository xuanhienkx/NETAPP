using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    public class DE013Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public long ParValue { get; set; }
        [ProtoMember(2)]
        public string StockCode { get; set; }
        [ProtoMember(3)]
        public string AccountType { get; set; }
        [ProtoMember(4)]
        public long Quantiry { get; set; }
        [ProtoMember(5)]
        public long PauseTradeQuantity { get; set; }
        [ProtoMember(6)]
        public long ReleasingQuantirty { get; set; }
        [ProtoMember(7)]
        public long PendWithdrawQuantity { get; set; }
        [ProtoMember(8)]
        public long PendPaymentQuantity { get; set; }
        [ProtoMember(9)]
        public long FreelyStockQuantity { get; set; }
        [ProtoMember(10)]
        public long RestrictedStockQuantity { get; set; }
        [ProtoMember(11)]
        public long PlegingQuantity { get; set; }
        [ProtoMember(12)]
        public long PendLoansQuantity { get; set; }
        [ProtoMember(13)]
        public long AssuranceQuantity { get; set; }
        /// <summary>
        /// Số lượng CK ký quỹ tại TVBT
        /// </summary>
        [ProtoMember(14)]
        public long EscrowQuantity { get; set; }
        [ProtoMember(15)]
        public long Total { get; set; }
        public string Membercode { get; set; }
        public string MemberName { get; set; }
    }

    public class DE164Model : ICsvDataReport
    {
        public string Membercode { get; set; }
        public string MemberName { get; set; }
    }
    public class DE165Model : ICsvDataReport
    {
        public string Membercode { get; set; }
        public string MemberName { get; set; }
        public string PinNumber { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string CardIdentity { get; set; } 
        public string StockCode { get; set; }
        public string SecuriryName { get; set; }
        public string CardDate { get; set; }
        public string Nationality { get; set; }
        public string AccountNumer { get; set; }
        public string BankGL { get; set; }
        public string AccountType { get; set; }
        public string Quantity { get; set; }
        public string Notes { get; set; }

    }
}