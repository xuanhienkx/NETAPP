using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("StockOrder")]
    public class StockOrder
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string OrderDate { get; set; }

        [Required]
        [StringLength(12)]
        public string OrderTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderSeq { get; set; }

        [StringLength(20)]
        public string OrderNo { get; set; }

        [Required]
        [StringLength(5)]
        public string OrderType { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderSide { get; set; }

        [Required]
        [StringLength(1)]
        public string BoardType { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCode { get; set; }

        public decimal OrderVolume { get; set; }

        public decimal OrderPrice { get; set; }

        public decimal OrderValue { get; set; }

        public decimal OrderFee { get; set; }

        [Required]
        [StringLength(10)]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [Required]
        [StringLength(30)]
        public string TradeCode { get; set; }

        [StringLength(3)]
        public string CustomerBranchCode { get; set; }

        [StringLength(30)]
        public string CustomerTradeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ReceivedBy { get; set; }

        [StringLength(30)]
        public string ApprovedBy { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }

        [Required]
        [StringLength(1)]
        public string AlertCode { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        public int? Session { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }

        public int? RefNo { get; set; }

        public decimal? IcebergVolume { get; set; }

        public decimal? StopPx { get; set; }
    }
}