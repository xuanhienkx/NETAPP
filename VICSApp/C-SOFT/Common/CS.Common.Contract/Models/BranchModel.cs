using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class BranchModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string BranchCode { get; set; }
        [ProtoMember(3)]
        public string BranchName { get; set; }
        [ProtoMember(4)]
        public string Address { get; set; }
        [ProtoMember(5)]
        public string Tel { get; set; }
        [ProtoMember(6)]
        public string Fax { get; set; }
        [ProtoMember(7)]
        public BranchModel Parent { get; set; }
        [ProtoMember(8)]
        public int CustomerAccountFrom { get; set; }
        [ProtoMember(9)]
        public int CustomerAccountTo { get; set; }
        [ProtoMember(10)]
        public int CustomerAccountCurrent { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(BranchCode), "BranchModel_BranchCode_Validation", () => !string.IsNullOrEmpty(BranchCode));
            rules.Add(nameof(BranchName), "BranchModel_BranchName_Validation", () => !string.IsNullOrEmpty(BranchName));
            rules.Add(nameof(Address), "BranchModel_Address_Validation", () => !string.IsNullOrEmpty(Address));
        }
    }
}