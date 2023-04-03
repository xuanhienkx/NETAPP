using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Services;
using MediatR;
using MongoDB.Driver;

namespace api.domain.Handlers
{
    public class MediaResourceHandler : PersistentHandler<MediaResource, DomainPersistentService>,
        IRequestHandler<CreateEntityCommand<MediaResource>, Result<MediaResource>>,
        IRequestHandler<DeleteByIdCommand<MediaResource>, Result<bool>>
    {
        public MediaResourceHandler(IMediator mediator, IPersistentService<DomainPersistentService> persistentService, ILocalizer localizer) 
            : base(mediator, persistentService, localizer)
        {
        }

        protected override ProjectionDefinition<MediaResource> ExcludeGetProjection { get; }

        public async Task<Result<MediaResource>> Handle(CreateEntityCommand<MediaResource> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var option = new InsertOneOptions
            {
                BypassDocumentValidation = true
            };
            var resources = PersistentService.GetCollection<MediaResource>();

            if (PersistentService.HasSession)
                await resources.InsertOneAsync(PersistentService.Session, request.Entity, option, cancellationToken);
            else
                await resources.InsertOneAsync(request.Entity, option, cancellationToken);

            return Result(request.Entity);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<MediaResource> request, CancellationToken cancellationToken)
        {
            // delete media
            var resources = PersistentService.GetCollection<MediaResource>();
            var media = PersistentService.HasSession
                ? await resources.FindOneAndDeleteAsync(PersistentService.Session, Builders<MediaResource>.Filter.Eq(x => x.Id, request.Id), cancellationToken: cancellationToken)
                : await resources.FindOneAndDeleteAsync(Builders<MediaResource>.Filter.Eq(x => x.Id, request.Id), cancellationToken: cancellationToken);
            if (media == null)
            {
                return Error<bool>(Text("file.notFound"));
            }

            // send request to delete
            return await Mediator.Send(new DeleteFileCommand(media), cancellationToken);
        }
    }
}
