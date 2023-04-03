using System;
using System.Collections.Generic;
using ProtoBuf;

namespace CS.Common.Contract.Models
{
    [ProtoContract]
    public class AccountBalanceModel: DataContract, IReversionResource<long>
    {
        [ProtoMember(1)]
        public long Id { get; set; }
        [ProtoMember(2)]
        public long AccountId { get; set; }
        [ProtoMember(3)]
        public Guid CustomerAccountId { get; set; }
        [ProtoMember(4)]
        public decimal Available { get; set; }
        [ProtoMember(5)]
        public decimal Balance { get; set; }
        [ProtoMember(6)]
        public decimal? Block { get; set; }
        [ProtoMember(7)]
        public DateTime LastBalancedDate { get; set; }
        [ProtoMember(8)]
        public int Version { get; set; }

        public virtual AccountModel Account { get; set; }
        public virtual CustomerAccountModel CustomerAccount { get; set; }
        public virtual IList<AccountBlockTransactionModel> AccountBlockTransactions { get; set; }
        public virtual IList<AccountTransactionModel> AccountTransactions { get; set; }
    }
}