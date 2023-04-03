using System;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AccountBlockTransactionModel : DataContract, IResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public long AccountBlanceId { get; set; }
        [ProtoMember(3)]
        public decimal Amount { get; set; }
        [ProtoMember(4)]
        public DateTime CreatedDate { get; set; }
        [ProtoMember(5)]
        public string Note { get; set; }
        [ProtoMember(6)]
        public string ReferenceCode { get; set; }
        
        public virtual AccountBalanceModel AccountBlance { get; set; }
    }
}