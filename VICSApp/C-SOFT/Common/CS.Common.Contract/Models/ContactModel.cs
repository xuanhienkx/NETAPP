using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class ContactModel : DataContract, ICommonResource<long>
    {
        public ContactModel() { }
        public ContactModel(ContactType type)
        {
            Type = type;
        }

        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public Guid CustomerId { get; set; }
        [ProtoMember(3)]
        public string Detail { get; set; }
        [ProtoMember(4)]
        public bool IsDefault { get; set; }
        [ProtoMember(6)]
        public ContactType Type { get; set; }

        protected override void SetupRules(RuleCollection rules)
        {
            rules.Add(nameof(Detail), "ContactModel_Detail_Validation", () => !string.IsNullOrEmpty(Detail));
        }
    }
}