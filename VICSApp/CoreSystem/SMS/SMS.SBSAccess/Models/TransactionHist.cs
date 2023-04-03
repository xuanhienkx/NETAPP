using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TransactionHist")]
    public class TransactionHist
    {
        public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string BankGl { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string SectionGl { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string AccountId { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(12)]
        public string TransactionNumber { get; set; }

        [StringLength(10)]
        public string TransactionCode { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(1)]
        public string DebitOrCredit { get; set; }

        public decimal Amount { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(1)]
        public string Approved { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Approver { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransactionTime { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        [StringLength(30)]
        public string TradeCode { get; set; }

        [StringLength(20)]
        public string DepartmentCode { get; set; }

        [StringLength(48)]
        public string ClientIP { get; set; }
    }
}