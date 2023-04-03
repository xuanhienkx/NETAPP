using api.common.Models;
using api.common.Shared.Base;

namespace api.common.Commands
{
    public class DeleteFileCommand : BaseCommand<bool>
    {
        public MediaResource Media { get; }

        public DeleteFileCommand(MediaResource media)
        {
            Media = media;
        }
    }
}