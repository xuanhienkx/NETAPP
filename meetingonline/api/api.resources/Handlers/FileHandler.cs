using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using api.common.Commands;

namespace api.resources.Handlers
{
    public class FileHandler : BaseHandler,
        IRequestHandler<UploadFileCommand, Result<MediaResource>>, 
        IRequestHandler<DeleteFileCommand, Result<bool>>
    {
        private readonly IFileService fileService;

        public FileHandler(IMediator mediator, IFileService fileService, ILocalizer localizer) 
            : base(mediator, localizer)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<Result<MediaResource>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await fileService.Upload(request.Stream, request.FileName, cancellationToken);
            if (result.Succeeded)
            {
                await Mediator.Send(new CreateEntityCommand<MediaResource>(result.Value), cancellationToken);
            }

            return result;
        }

        public async Task<Result<bool>> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            // delete the physical file
            return new Result<bool>(await fileService.Delete(request.Media));
        }
    }
}
