using System;
using System.Collections.Generic;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class GroupModel : DataContract, ICommonResource<Guid>
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string Name { get => Get<string>(); set => Set(value); }
        [ProtoMember(3)]
        public GroupModel Parent { get => Get<GroupModel>(); set => Set(value); }
        [ProtoMember(4)]
        public BranchModel Branch { get => Get<BranchModel>(); set => Set(value); }
        [ProtoMember(5)]
        public IList<GroupMemberModel> Members  { get; set; }

    protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Name), "BrokerGroupModel_GroupName_Validation", () => !string.IsNullOrEmpty(Name));
            rules.Add(nameof(Branch), "BrokerGroupModel_Branch_Validation", () => Branch != null && Branch.Id > 0);
            rules.Add(nameof(Branch), "BrokerGroupModel_Branch_SameAsParentValidation", () => Parent == null || Parent.Branch == null || Branch == null || Branch.Id == Parent.Branch.Id);
            rules.Add(nameof(Parent), "BrokerGroupModel_Parent_Validation", () => Parent == null || Parent.Branch == null || Branch == null || Branch.Id == Parent.Branch.Id);
        }
    }
}