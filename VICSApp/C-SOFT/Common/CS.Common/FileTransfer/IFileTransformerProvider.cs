using System;
using System.IO;
using System.Threading.Tasks;

namespace CS.Common.FileTransfer
{
    public interface IFileTransformerProvider
    {
        bool CanUse(string fileName);
        Task EnsurePath(string path);
        Task<Stream> LoadStream(string fileName);
        Task<Stream> PlushStreamAsync(string fileName);
        Task Delete(string fileName);
    }
}
