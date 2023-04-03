using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TradingOrder")]
    public class TradingOrder
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string OrderDate { get; set; }

        [Required]
        [StringLength(12)]
        public string OrderTime { get; set; }

        public int? OrderSeq { get; set; }

        [StringLength(3)]
        public string BranchCode { get; set; }

        [StringLength(30)]
        public string TradeCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string OrderNo { get; set; }

        [Required]
        [StringLength(5)]
        public string OrderType { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderSide { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string BoardType { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCode { get; set; }

        [Required]
        [StringLength(1)]
        public string StockType { get; set; }

        public decimal OrderVolume { get; set; }

        public decimal OrderPrice { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerId { get; set; }

        [StringLength(3)]
        public string CustomerBranchCode { get; set; }

        [StringLength(30)]
        public string CustomerTradeCode { get; set; }

        [Required]
        [StringLength(1)]
        public string PcFlag { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }

        public decimal MatchedVolume { get; set; }

        public decimal MatchedValue { get; set; }

        public decimal FeeRate { get; set; }

        public decimal PublishedVolume { get; set; }

        public decimal PublishedPrice { get; set; }

        public decimal CancelledVolume { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }

        public decimal? IcebergVolume { get; set; }

        public decimal? StopPx { get; set; }
    }
}