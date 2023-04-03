using System.Collections.Generic;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class BusinessUnitModel : DataContract, IResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public byte? Type { get; set; }
        
        public virtual ICollection<SettlementModel> Settlements { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Name), "BusinessUnitModel_Name_Validation", () => !string.IsNullOrEmpty(Name));
        }
    }
}