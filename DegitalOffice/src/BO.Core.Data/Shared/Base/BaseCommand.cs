using BO.Core.DataCommon.Shared.Interfaces;
using MediatR;

namespace BO.Core.DataCommon.Shared.Base
{
    public abstract class BaseCommand<T> : IRequest<Result<T>>
    {

    }

    public class MediaResource : BaseModel, IPersistentEntity
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public string FileId { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
    }

}
