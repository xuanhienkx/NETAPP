using DO.Common.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DO.Domain.Audit.Entities
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
