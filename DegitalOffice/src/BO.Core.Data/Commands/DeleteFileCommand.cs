using BO.Core.DataCommon.Shared.Base;

namespace BO.Core.DataCommon.Commands
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