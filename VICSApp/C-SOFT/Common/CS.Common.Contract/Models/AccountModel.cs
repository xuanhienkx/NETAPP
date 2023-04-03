using System.Collections.Generic;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AccountModel : DataContract, IReversionResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public long AssetId { get; set; }
        [ProtoMember(3)]
        public AssetType Type { get; set; }
        [ProtoMember(4)]
        public AccountStatus Status { get; set; }
        [ProtoMember(5)]
        public string Name { get; set; }
        [ProtoMember(6)]
        public string Code { get; set; }
        [ProtoMember(7)]
        public int Version { get; set; }

        public virtual AssetModel Asset { get; set; }
        public virtual List<AccountBalanceModel> AccountBalances { get; set; }
        public virtual List<SettlementModel> Settlements { get; set; }
        
        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Code), "AccountModel_Code_Validation", () => string.IsNullOrEmpty(Code) && Code.Length <= 50);
            rules.Add(nameof(Name), "AccountModel_Name_Validation", () => string.IsNullOrEmpty(Name) && Name.Length <= 256);
        }
    }
}