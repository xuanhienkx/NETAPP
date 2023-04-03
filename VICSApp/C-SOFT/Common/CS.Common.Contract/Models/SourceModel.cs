using System.Collections.Generic;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class SourceModel : DataContract, IResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public AssetType Type { get; set; }
        [ProtoMember(4)]
        public string Description { get; set; }

        public virtual IList<AccountTransactionModel> AccountTransactions { get; set; }
        
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Name), "SourceModel_Name_Validation", () => !string.IsNullOrEmpty(Name));
        }
    }
}