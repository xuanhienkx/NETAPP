using DSoft.Common.Models;
using DSoft.Common.Shared.Interfaces;

namespace DSoft.Common.Shared
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
