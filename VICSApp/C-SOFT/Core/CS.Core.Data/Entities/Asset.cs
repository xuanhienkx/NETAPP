using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{

    // Assets
    [Table("Assets")]
    public class Asset : IdentityEntityBase, IReversionEntity<long>, ICommonEntity<long>
    {
        public BoardType BoardType { get; set; }
        [MaxLength(30)]
        public string BoardName { get; set; }
        [Required]
        [MaxLength(35)]
        [Column(TypeName = "varchar(35)")]
        public string Code { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "varchar(2)")]
        public string CountryCode { get; set; }
        public string Fax { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ForginRate { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string IsinCode { get; set; }
        [Required]
        [MaxLength(350)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string NameLocal { get; set; }
        [Column(TypeName = "decimal")]
        public decimal ParValue { get; set; }
        public string Phone { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Rational { get; set; }
        public AssetSubType SubType { get; set; }
        [Column(TypeName = "decimal")]
        public decimal TotalIssue { get; set; }
        public DateTime? TradeDate { get; set; }
        public AssetType Type { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Value { get; set; }
        public int Version { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
