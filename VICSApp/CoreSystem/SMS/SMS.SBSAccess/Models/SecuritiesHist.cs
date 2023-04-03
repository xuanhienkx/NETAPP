using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("SecuritiesHist")]
    public class SecuritiesHist
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string BankGl { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string SectionGl { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string AccountId { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string StockCode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Quantity { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PendingDebitQuantity { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "smalldatetime")]
        public DateTime TransactionDate { get; set; }
    }
}