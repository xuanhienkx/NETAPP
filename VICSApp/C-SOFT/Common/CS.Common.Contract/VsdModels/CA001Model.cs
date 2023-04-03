using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.VsdModels
{
    [ProtoContract]
    [Serializable]
    [ProtoInclude(100, typeof(CA001Model))]
    public abstract class BaseResponReport : ICsvDataReport
    {
        [ProtoMember(1)]
        public string MemberName { get; set; }
        [ProtoMember(2)]
        public string Membercode { get; set; }
        [ProtoMember(3)]
        public string CustomerNumber { get; set; }
        [ProtoMember(4)]
        public string CustomerName { get; set; }
        [ProtoMember(5)]
        public string CardIdentity { get; set; }
        [ProtoMember(6)]
        public DateTime? CardIssuedDate { get; set; }
        [ProtoMember(7)]
        public string Address { get; set; }
        [ProtoMember(8)]
        public string AccountType { get; set; }
        [ProtoMember(9)]
        public string BusinessType { get; set; }
        [ProtoMember(10)]
        public string Nationality { get; set; }
        [ProtoMember(11)]
        public CustomerType CustomerType { get; set; }
        [ProtoMember(12)]
        public string StockCode { get; set; }
        [ProtoMember(13)]
        public string Notes { get; set; }
        [ProtoMember(14)]
        public string DocumentRef { get; set; }
        [ProtoMember(15)]
        public long HoldQuantity { get; set; }
    }
    /// <summary>
    ///CA001- Danh sách người sở hữu chứng khoán lưu ký nhận phân bổ quyền bỏ phiếu
    /// </summary>
    [ProtoContract]
    [Serializable]
    public class CA001Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long DepositQuantity { get; set; }
        [ProtoMember(2)]
        public long TotalQuantity { get; set; }
        [ProtoMember(3)]
        public long VoteQuantity { get; set; }

    }
    /// <summary>
    /// CA005- Danh sách người sở hữu chứng khoán lưu ký nhận phân bổ quyền mua
    /// </summary>
    [ProtoContract]
    [Serializable]
    public class CA005Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long DepositQuantity { get; set; }
        [ProtoMember(2)]
        public long TotalQuantity { get; set; }
        [ProtoMember(3)]
        public long AllocationRightsQuantity { get; set; }
    }
    /// <summary>
    /// CA009- Danh sách người sở hữu chứng khoán lưu ký nhận cổ tức bằng tiền
    /// </summary>
    [ProtoContract]
    [Serializable]
    public class CA009Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long ValueBeforeTaxes { get; set; }
        [ProtoMember(2)]
        public long DepositQuantity { get; set; }
        [ProtoMember(3)]
        public long TotalQuantity { get; set; }
        [ProtoMember(4)]
        public long VoteQuantity { get; set; }
        [ProtoMember(5)]
        public long Tax { get; set; }
        [ProtoMember(6)]
        public long Amount { get; set; }
    }
    /// <summary>
    /// CA012- Danh sách người sở hữu chứng khoán lưu ký nhận cổ phiếu thưởng
    /// </summary>
    [ProtoContract]
    [Serializable]
    public class CA012Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long ActualQuantity { get; set; }
        [ProtoMember(2)]
        public long TotalQuantity { get; set; }
        [ProtoMember(3)]
        public long ResidualQuantity { get; set; }
        [ProtoMember(4)]
        public long ParValue { get; set; }
        [ProtoMember(5)]
        public long DepositQuantity { get; set; }
    }/// <summary>
     /// CA014- Danh sách người sở hữu chứng khoán lưu ký nhận cổ tức bằng cổ phiếu
     /// </summary>
    [ProtoContract]
    [Serializable]
    public class CA014Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long ActualQuantity { get; set; }
        [ProtoMember(2)]
        public long TotalQuantity { get; set; }
        [ProtoMember(3)]
        public long ResidualQuantity { get; set; }
        [ProtoMember(4)]
        public long ParValue { get; set; }
        [ProtoMember(5)]
        public long DepositQuantity { get; set; }
    }
    [ProtoContract]
    [Serializable]
    public class CA031Model : BaseResponReport
    {
        [ProtoMember(1)]
        public long ActualQuantity { get; set; }
        [ProtoMember(2)]
        public long RightIssuQuantity { get; set; }
        [ProtoMember(3)]
        public long RegisterQuantity { get; set; }
    }
    [ProtoContract]
    [Serializable]
    public class CA069Model : ICsvDataReport
    {
        [ProtoMember(1)]
        public string Membercode { get; set; }
        [ProtoMember(2)]
        public string MemberName { get; set; }
        [ProtoMember(4)]
        public string Status { get; set; }
        [ProtoMember(5)]
        public DateTime? ConfirmDate { get; set; }
        [ProtoMember(7)]
        public string ReportName { get; set; }
        [ProtoMember(8)]
        public string ReportCode { get; set; }
        [ProtoMember(9)]
        public long ConfirmStatus { get; set; }
        [ProtoMember(10)]
        public string StockCode { get; set; }
        [ProtoMember(11)]
        public string RightName { get; set; }
        [ProtoMember(12)]
        public string RightCode { get; set; }
        [ProtoMember(13)]
        public string Desctiption { get; set; }
        [ProtoMember(14)]
        public string ConfirmApproval { get; set; }
        [ProtoMember(15)]
        public string ConfirmDisapproval { get; set; }
        [ProtoMember(16)]
        public string NotConfirm { get; set; }
        [ProtoMember(18)]
        public string Total { get; set; }
        [ProtoMember(19)]
        public string Summary { get; set; }
        [ProtoMember(20)]
        public string Code { get; set; }
    }

    [ProtoContract]
    [Serializable]
    public class CA070Model : ICsvDataReport
    {
        [ProtoMember(1)]public string Membercode { get; set; }
        [ProtoMember(2)] public string MemberName { get; set; }
        [ProtoMember(3)] public string StockCode { get; set; }
        [ProtoMember(4)] public string StockName { get; set; }
        [ProtoMember(5)] public string CustomerNumber { get; set; }
        [ProtoMember(6)] public string CustomerName { get; set; }
        [ProtoMember(7)] public string Address { get; set; }
        [ProtoMember(8)] public string CardIdentity { get; set; }
        [ProtoMember(9)] public DateTime? CardIssuedDate { get; set; }
        [ProtoMember(10)] public string SharesType { get; set; }
        [ProtoMember(11)] public long OrderQuantity { get; set; }
        [ProtoMember(12)] public long OrderValue { get; set; }
    }
}
