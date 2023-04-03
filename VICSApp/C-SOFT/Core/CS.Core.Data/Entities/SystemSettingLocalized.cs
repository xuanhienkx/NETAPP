using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("SystemSettingLocalized")]
    public class SystemSettingLocalized : ICommonEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public Guid SystemSettingId { get; set; }
        [Required, MaxLength(5)]
        public string LanguageCode { get; set; }
        public string Text{ get; set; }

        [ForeignKey(nameof(SystemSettingId))]
        public SystemSetting SystemSetting { get; set; }
    }
}