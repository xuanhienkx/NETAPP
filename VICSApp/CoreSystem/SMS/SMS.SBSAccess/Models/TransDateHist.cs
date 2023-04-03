using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TransDateHist")]
    public class TransDateHist
    {
        public int Id { get; set; }

        [StringLength(3)]
        public string BranchCode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TransDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(20)]
        public string StartUsername { get; set; }

        public DateTime? StartTime { get; set; }

        [StringLength(20)]
        public string EndUsername { get; set; }

        public DateTime? EndTime { get; set; }
    }
}