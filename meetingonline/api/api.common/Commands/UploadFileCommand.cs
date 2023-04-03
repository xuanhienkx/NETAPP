using System.IO;
using api.common.Models;
using api.common.Shared.Base;

namespace api.common.Commands
{
    public class UploadFileCommand : BaseCommand<MediaResource>
    {
        public Stream Stream { get; }
        public string FileName { get; }
        
        public UploadFileCommand(Stream  stream, string fileName)
        {
            Stream = stream;
            FileName = fileName;
        }
    }
}
