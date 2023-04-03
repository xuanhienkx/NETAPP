using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Net.Http.Headers;

namespace api.common.Shared.Interfaces
{
    public interface IMultipartConsumer
    {
        Result<string> GetBoundary(MediaTypeHeaderValue contentType);
        bool IsMultipartContentType(string contentType);
        bool HasFormDataContentDisposition(ContentDispositionHeaderValue contentDisposition);
        bool HasFileContentDisposition(ContentDispositionHeaderValue contentDisposition);
    }
}
