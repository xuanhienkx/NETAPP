using api.common.Models;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace api.common.Shared.Interfaces
{
    public interface IFileService
    {
        Task<Result<MediaResource>> Upload(Stream stream, string fileName, CancellationToken cancellationToken);
        Task<bool> Delete(MediaResource media);
        string Load(string fileName);
        void Save(string fileName, StringBuilder contentBuilder);
        string GetPath(string filePath);
    }
}