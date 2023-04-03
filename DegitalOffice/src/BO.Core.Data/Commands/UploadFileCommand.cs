using BO.Core.DataCommon.Shared.Base;

namespace BO.Core.DataCommon.Commands
{
    public class UploadFileCommand : BaseCommand<MediaResource>
    {
        public Stream Stream { get; }
        public string FileName { get; }

        public UploadFileCommand(Stream stream, string fileName)
        {
            Stream = stream;
            FileName = fileName;
        }
    }
}
