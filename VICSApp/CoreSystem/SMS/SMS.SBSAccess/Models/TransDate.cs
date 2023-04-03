using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.SBSAccess.Models
{
    [Table("TransDate")]
    public class TransDate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string BranchCode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CurrentTransDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastTransDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FirstDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CurrentTransMonth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastTransMonth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FirstDateMonth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CurrentTransYear { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? LastTransYear { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? FirstDateYear { get; set; }
    }
}