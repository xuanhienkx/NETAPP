using DO.Common.Contract.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO.Domain.Audit.Entities
{
    public enum CustomerAuditType : byte
    {
        Created,
        Modifiled,
        Closed
    }

    [Table("CustomerAudits")]
    public class CustomerAudit : EventBase
    {
        public DateTime? BirthDay { get; set; }
        public Guid? BrokerId { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string CardIdentity { get; set; }
        public DateTime CardIssuedDate { get; set; }
        [Required]
        [MaxLength(65)]
        public string CardIssuer { get; set; }
        public CardType CardType { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string CustomerNumber { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string PinCode { get; set; }
        [Required]
        [MaxLength(65)]
        public string Address { get; set; }
        [Required]
        [MaxLength(35)]
        public string City { get; set; }
        [Required]
        [MaxLength(140)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(140)]
        public string FullNameLocal { get; set; }
        public GenereType Genere { get; set; }
        public CustomerStatus Status { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }
        public byte[] SignatureImage1 { get; set; }
        public byte[] SignatureImage2 { get; set; }
        public string TaxCode { get; set; }
        public CustomerType Type { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; }
        [MaxLength(2)]
        public string NationalityCode { get; set; }
        public CustomerAuditType AuditType { get; set; }
    }
}