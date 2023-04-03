using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AccountTransactionModel : DataContract, IResource<Guid>
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public long AcountBalanceId { get; set; }
        [ProtoMember(3)]
        public decimal Amount { get; set; }
        [ProtoMember(4)]
        public Guid? ApproveById { get; set; }
        [ProtoMember(5)]
        public Guid? CreatedById { get; set; }
        [ProtoMember(6)]
        public string Description { get; set; }
        [ProtoMember(7)]
        public long? SourceId { get; set; }
        [ProtoMember(8)]
        public AccountTransactionStatus Status { get; set; }
        [ProtoMember(9)]
        public DateTime TransactionDate { get; set; }
        [ProtoMember(10)]
        public string ReferenceCode { get; set; }

        public virtual AccountBalanceModel AcountBalance { get; set; }
        public virtual SourceModel Source { get; set; }
        public virtual IUserLogin ApproveBy { get; set; }
        public virtual IUserLogin CreatedBy { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Description), "AccountTransactionModel_Description_Validation", () => string.IsNullOrEmpty(Description) && Description.Length <= 256);
            rules.Add(nameof(ReferenceCode), "AccountTransactionModel_ReferenceCode_Validation", () => string.IsNullOrEmpty(ReferenceCode) && ReferenceCode.Length <= 20);
        }
    }
}