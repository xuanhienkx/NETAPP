using System.IO;
using System.Threading.Tasks;

namespace CS.Common.FileTransfer
{
    public interface IFileService
    {
        void EnsurePath(string path);
        Task Move(string fromFile, string path);
        Task Transfer(Stream fromStream, Stream toStream);
        Task<Stream> Read(string fileName, bool useCircuitBreaker = false);
        Task<Stream> Open(string tempFilePath, bool useCircuitBreaker = false);
        Task Delete(string fileName, bool useCircuitBreaker = false);
        string GetFileName(string fileName);
    }
}
