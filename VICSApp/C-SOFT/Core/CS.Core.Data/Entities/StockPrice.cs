using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("StockPrices")]
    public class StockPrice : IdentityEntityBase, ICommonEntity<long>
    {
        [Column(TypeName = "decimal")]
        public decimal AveragePrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal BasicPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal CeilingPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ClosePrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal FloorPrice { get; set; }
        [Column(TypeName = "decimal")]
        public decimal OpenPrice { get; set; }
        public int Status { get; set; }
        public int StockNo { get; set; }
        public byte StockType { get; set; }
        public DateTime TradingDate { get; set; }
    }
}
