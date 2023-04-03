using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("BalanceHist")]
    public class BalanceHist
    {
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

        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime OpenDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastDate { get; set; }

        public decimal BeginCredit { get; set; }

        public decimal BeginDay { get; set; }

        public decimal YearDebit { get; set; }

        public decimal YearCredit { get; set; }

        public decimal MonthDebit { get; set; }

        public decimal MonthCredit { get; set; }

        public decimal DayDebit { get; set; }

        public decimal DayCredit { get; set; }

        public decimal CurrentBalance { get; set; }

        [Required]
        [StringLength(1)]
        public string DebitOrCredit { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }
    }
}