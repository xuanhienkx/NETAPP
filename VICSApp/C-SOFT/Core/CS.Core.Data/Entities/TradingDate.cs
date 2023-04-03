using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("TradingDates")]
    public class TradingDate : IdentityEntityBase, ICommonEntity<long>
    {
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime NextTransactionDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime PreviousTransactionDate { get; set; }
    }
}
