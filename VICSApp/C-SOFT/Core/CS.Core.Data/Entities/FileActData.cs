using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("FileActs")]
    public class FileAct : IdentityEntityBase, ICommonEntity<long>
    {
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string OrigTransferRef { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string ReportCode { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string SwiftTime { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string DeliveryTime { get; set; } 
        [MaxLength(300)]
        [Required]
        public string LogicalName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string RequestRef { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string TransferRef { get; set; }
        [MaxLength(300)]
        public string TransferDescription { get; set; }
       [ MaxLength(256)]
        public string TransferInfo { get; set; }
        [MaxLength(600)]
        public string FileInfo { get; set; }
        [MaxLength(600)]
        public string FileDescription { get; set; } 
        public ReportType ReportType { get; set; }   
        public ReportStatus ReportStatus { get; set; }
        [MaxLength(256)]
        public string BusinessId { get; set; }

    }
}