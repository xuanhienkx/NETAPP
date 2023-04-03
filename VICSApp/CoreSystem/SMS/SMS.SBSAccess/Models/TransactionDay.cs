using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TransactionDay")]
    public class TransactionDay
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [Required]
        [StringLength(6)]
        public string BankGl { get; set; }

        [Required]
        [StringLength(4)]
        public string SectionGl { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountId { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [StringLength(12)]
        public string TransactionNumber { get; set; }

        [StringLength(10)]
        public string TransactionCode { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }

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

        [StringLength(20)]
        public string Approver { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? TransactionTime { get; set; }

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