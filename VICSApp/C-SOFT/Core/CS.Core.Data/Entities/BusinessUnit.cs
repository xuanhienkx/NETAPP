using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("BusinessUnits")]
    public class BusinessUnit : IdentityEntityBase, ICommonEntity<long>
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        public BusinessType Type { get; set; }

        public virtual ICollection<BusinessAccountSetting> Settlements { get; set; }
    }
}
