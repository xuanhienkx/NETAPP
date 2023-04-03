using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class CustomerAccountModel : DataContract, ICommonResource<Guid>
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string Code { get; set; }
        [ProtoMember(3)]
        public Guid CustomerId { get; set; }
        [ProtoMember(4)]
        public DateTime CreateDate { get; set; }
        [ProtoMember(5)]
        public Guid CreatedByBrockerId { get; set; }
        [ProtoMember(6)]
        public string ContractNumber { get; set; }
        [ProtoMember(7)]
        public DateTime? ExpiredDate { get; set; }
        [ProtoMember(8)]
        public bool IsActive { get; set; }
        [ProtoMember(9)]
        public BusinessType Type { get; set; }
        
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Code), "CustomerAccountModel_Code_Validation", () => !string.IsNullOrEmpty(Code));
        }
    }
}
