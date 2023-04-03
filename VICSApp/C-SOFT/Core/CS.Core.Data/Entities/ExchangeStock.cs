using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("ExchangeStocks")]
    public class ExchangeStock : IdentityEntityBase, ICommonEntity<long>
    {
        public BoardType BoardType { get; set; }//0003
        [Required]
        [Column(TypeName = "varchar(4)")]
        public string VsdBoardCode { get; set; }//XSTC
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string ShortName { get; set; }//HOSE
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }//HOCHIMINH STOCK EXCHANGE
    }
}