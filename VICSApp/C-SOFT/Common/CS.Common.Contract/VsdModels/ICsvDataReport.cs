using System;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    public interface ICsvDataReport
    {
        string Membercode { get; set; }
        string MemberName { get; set; }
    }
    [ProtoContract]
    public class DE083Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public long PinNumber { get; set; }
        [ProtoMember(2)]
        public string ShortName { get; set; }
        [ProtoMember(3)]
        public string FullName { get; set; }
        [ProtoMember(4)]
        public string CardIdentity { get; set; }
        [ProtoMember(6)]
        public string StockCode { get; set; }
        [ProtoMember(7)]
        public string StockName { get; set; }
        [ProtoMember(8)]
        public DateTime CardIssuedDate { get; set; }
        [ProtoMember(9)]
        public string Nationality { get; set; }
        [ProtoMember(10)]
        public string CustomerNumber { get; set; }
        [ProtoMember(12)]
        public string StockBangGl { get; set; }
        [ProtoMember(13)]
        public string AccountType { get; set; }
        [ProtoMember(14)]
        public long Quantity { get; set; }
        [ProtoMember(15)]
        public string Notes { get; set; }
        public string Membercode { get; set; }
        public string MemberName { get; set; }
    }

    [ProtoContract]
    public class DE084Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public long ParValue { get; set; }
        [ProtoMember(2)]
        public string StockCode { get; set; }
        [ProtoMember(3)]
        public string AccountType { get; set; }
        [ProtoMember(4)]
        public long TradeQuantiry { get; set; }
        [ProtoMember(5)]
        public long PauseTradeQuantity { get; set; }
        [ProtoMember(6)]
        public long ReleasingQuantirty { get; set; }
        [ProtoMember(7)]
        public long PendWithdrawQuantity { get; set; }
        [ProtoMember(8)]
        public long PendPaymentQuantity { get; set; }
        /// <summary>
        /// SL CK chờ GD Tự do chuyển nhượng
        /// </summary>
        [ProtoMember(9)]
        public long FreelyStockQuantity { get; set; }
        /// <summary>
        /// SL CK Chờ GD HCCN
        /// </summary>
        [ProtoMember(10)]
        public long RestrictedStockQuantity { get; set; }
        /// <summary>
        /// SL CK tạm giữ
        /// </summary>
        [ProtoMember(11)]
        public long PlegingQuantity { get; set; }
        /// <summary>
        /// Số lượng CK chờ cho vay
        /// </summary>
        [ProtoMember(12)]
        public long PendLoansQuantity { get; set; }
        /// <summary>
        /// Số lượng CK ký quỹ đảm bảo khoản vay
        /// </summary>
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
}