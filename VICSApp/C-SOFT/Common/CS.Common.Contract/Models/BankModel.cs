using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class BankModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string BankCode { get; set; }
        [ProtoMember(3)]
        public string FullName { get; set; }
        /// <summary>
        /// Code of  PledgeReleasing
        /// Mã nhận phong toả giải toả 
        /// </summary>
        [ProtoMember(4)]
        public string BankPlRlCode { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(BankCode), "BankModel_BankCode_Validation", () => string.IsNullOrEmpty(BankCode));
            rules.Add(nameof(FullName), "BankModel_FullName_Validation", () => string.IsNullOrEmpty(FullName));
            rules.Add(nameof(BankPlRlCode), "BankModel_BankPlRlCode_Validation", () => string.IsNullOrEmpty(BankPlRlCode));
        }
    }
}
