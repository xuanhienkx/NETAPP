using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;

namespace CS.Domain.Audit.Entities
{
    [Table("EventSources")]
    public class EventSource : ICommonEntity<long>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(512)]
        public string Path { get; set; }
        public Guid? UserLoginId { get; set; }
        [MaxLength(256)]
        public string DeviceId { get; set; }
        [MaxLength(512)]
        public string RequestSource { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
