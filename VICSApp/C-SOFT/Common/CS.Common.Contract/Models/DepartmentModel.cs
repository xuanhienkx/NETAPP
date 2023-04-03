using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class DepartmentModel : DataContract, ICommonResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public BranchModel Branch { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Name), "DepartmentModel_Name_Validation", () => !string.IsNullOrEmpty(Name));
            rules.Add(nameof(Branch), "DepartmentModel_Branch_Validation", () => Branch != null && Branch.Id > 0);
        }
    }
}