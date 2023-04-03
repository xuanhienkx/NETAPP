using api.common.Shared.Base;
using api.common.Shared.Interfaces;

namespace api.common.Models
{
    public class MediaResource : BaseModel, IPersistentEntity
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public string FileId { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
    }
}
