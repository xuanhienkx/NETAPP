using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DataAccess.Models
{
    public class SmsTradingCustom
    {
        public string ConfirmTime { get; set; }
        [MaxLength(1)]
        public string OrderSide { get; set; }
        [MaxLength(10)]
        public string CustomerId { get; set; }
        [MaxLength(4)]
        public string StockCode { get; set; }
        public decimal Volume { get; set; }
        [Key]
        public Guid Id { get; set; } 
        public DateTime TransactionTime { get; set; }
    }
    public class SmsTradingCustomHist
    {
        public string ConfirmTime { get; set; }
        [MaxLength(1)]
        public string OrderSide { get; set; }
        [MaxLength(10)]
        public string CustomerId { get; set; }
        [MaxLength(4)]
        public string StockCode { get; set; }
        public decimal Volume { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid CustomId { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}