using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TradingResult")]
    public class TradingResult
    {
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string OrderDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string OrderNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string ConfirmNo { get; set; }

        [Required]
        [StringLength(12)]
        public string ConfirmTime { get; set; }

        [StringLength(3)]
        public string BranchCode { get; set; }

        [StringLength(30)]
        public string TradeCode { get; set; }

        public int? OrderSeq { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderSide { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerId { get; set; }

        [StringLength(3)]
        public string CustomerBranchCode { get; set; }

        [StringLength(30)]
        public string CustomerTradeCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string BoardType { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCode { get; set; }

        [Required]
        [StringLength(1)]
        public string StockType { get; set; }

        public decimal MatchedVolume { get; set; }

        public decimal MatchedPrice { get; set; }

        public decimal MatchedValue { get; set; }

        public decimal FeeRate { get; set; }

        public bool NoPost { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(1)]
        public string IsCross { get; set; }

        public bool T { get; set; }

        public bool T3 { get; set; }

        public bool Deferred { get; set; }

        [StringLength(20)]
        public string ClearingCode { get; set; }

        public int? DayId { get; set; }

        public decimal? DeferredAmount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }

        public bool SpecialFee { get; set; } 
    }
}