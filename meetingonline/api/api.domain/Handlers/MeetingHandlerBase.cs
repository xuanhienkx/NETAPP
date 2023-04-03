using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Services;
using MediatR;
using MongoDB.Driver;

namespace api.domain.Handlers
{
    public abstract class MeetingHandlerBase : PersistentHandler<Meeting, DomainPersistentService>
    {
        protected MeetingHandlerBase(IMediator mediator, IPersistentService<DomainPersistentService> persistentService, ILocalizer localizer)
            : base(mediator, persistentService, localizer)
        {
        }

        protected override ProjectionDefinition<Meeting> ExcludeGetProjection { get; } = Builders<Meeting>.Projection
            .Exclude(x => x.Attendees)
            .Exclude(x => x.Holders)
            .Exclude(x => x.HolderUploadFile);

        protected Task<bool> Exists<T>(string meetingId, Expression<Func<Meeting, IEnumerable<T>>> field, Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken)
        {
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, meetingId),
                Builders<Meeting>.Filter.ElemMatch(field, filterExpression));

            return PersistentService.GetCollection<Meeting>().Find(filter).AnyAsync(cancellationToken);
        }
    }
}