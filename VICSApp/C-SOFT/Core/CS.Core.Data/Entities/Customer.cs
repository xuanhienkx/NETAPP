using CS.Common.Contract.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Customers")]
    public class Customer : UniqueIdentityEntityBase, IBranchBaseEntity, IReversionEntity<Guid>
    {
        public DateTime? BirthDay { get; set; }
        public Guid? BrokerId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CardIdentity { get; set; }
        public DateTime CardIssuedDate { get; set; }
        [Required]
        [MaxLength(65)]
        public string CardIssuer { get; set; }
        public CardType CardType { get; set; }
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
        public byte Level { get; set; }
        public CustomerStatus Status { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }                                                         
        public byte[] SignatureImage1 { get; set; }
        public byte[] SignatureImage2 { get; set; }
        [MaxLength(50)]
        public string TaxCode { get; set; }
        public CustomerType Type { get; set; }
        public Guid? DelegatedCustomerId { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; }
        [MaxLength(2)]
        public string NationalityCode { get; set; }
        
        [ForeignKey(nameof(BrokerId))]
        public virtual User Broker { get; set; }
        [ForeignKey(nameof(DelegatedCustomerId))]
        public virtual Customer DelegatedCustomer { get; set; }

        public long BranchId { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Version { get; set; }
        [MaxLength(2)]
        public string LanguageCode { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual User CreatedBy { get; set; }
        [ForeignKey(nameof(ModifiedByUserId))]
        public virtual User ModifiedBy { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string AccountLogin { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<CustomerAccount> CustomerAccounts { get; set; }
        public virtual ICollection<Customer> RepresentativeCustomers { get; set; }
    }
}
