using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("Banks")]
    public class Bank : IdentityEntityBase, ICommonEntity<long>
    {
        /// <summary>
        /// ShortName
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string BankCode { get; set; }
        [MaxLength(300)]
        public string FullName { get; set; }
        /// <summary>
        /// Code of  PledgeReleasing
        /// Mã nhận phong toả giải toả 
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string BankPlRlCode { get; set; }
    }
}