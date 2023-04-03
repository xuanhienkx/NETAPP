using System.ComponentModel.DataAnnotations;

namespace SMS.SBSAccess.Models
{
    public class Security
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

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(10)]
        public string StockCode { get; set; }

        public long Quantity { get; set; }

        public long PendingDebitQuantity { get; set; }
    }
}