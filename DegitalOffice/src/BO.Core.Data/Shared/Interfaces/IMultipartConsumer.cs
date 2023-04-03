using BO.Core.DataCommon.Shared.Base;
using Microsoft.Net.Http.Headers;

namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface IMultipartConsumer
    {
        Result<string> GetBoundary(MediaTypeHeaderValue contentType);
        bool IsMultipartContentType(string contentType);
        bool HasFormDataContentDisposition(ContentDispositionHeaderValue contentDisposition);
        bool HasFileContentDisposition(ContentDispositionHeaderValue contentDisposition);
    }
}
