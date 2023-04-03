using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Data.Entities
{
    [Table("SystemSetting")]
    public class SystemSetting : ICommonEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
