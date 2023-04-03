using System;
using CS.Common.Contract.Enums;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class SettlementModel: DataContract, IResource<Guid>
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public int? AccountId { get; set; }
        [ProtoMember(3)]
        public int? BusinessId { get; set; }
        [ProtoMember(4)]
        public SettlementType Type { get; set; }
        [ProtoMember(5)]
        public string XmlSetting { get; set; }
        
        public virtual AccountModel Account { get; set; } 
        public virtual BusinessUnitModel BusinessUnit { get; set; }
    }
}