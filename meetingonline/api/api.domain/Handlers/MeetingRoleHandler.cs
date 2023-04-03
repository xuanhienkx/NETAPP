using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Queries;
using api.domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Queries;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain.Handlers
{
    public class MeetingRoleHandler : PersistentHandler<MeetingRole, DomainPersistentService>,
        IRequestHandler<MeetingRoleCreateCommand, Result<MeetingRole>>,
        IRequestHandler<MeetingRoleUpdateCommand, Result<MeetingRole>>,
        IRequestHandler<DeleteByIdCommand<MeetingRole>, Result<bool>>,
        IRequestHandler<UpdateFieldByIdCommand<MeetingRole>, Result<MeetingRole>>,
        // query
        IRequestHandler<GetAllQuery<MeetingRole>, Result<List<MeetingRole>>>,
        IRequestHandler<GetByIdQuery<MeetingRole>, Result<MeetingRole>>,
        IRequestHandler<MeetingRoleFilterCommand, Result<List<string>>>
    {
        private readonly ICurrentUser currentUser;
        private readonly ILookupNormalizer keyNormalizer;

        public MeetingRoleHandler(IMediator mediator, ICurrentUser currentUser, IPersistentService<DomainPersistentService> persistentService, ILookupNormalizer keyNormalizer, ILocalizer localizer)
            : base(mediator, persistentService, localizer)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.keyNormalizer = keyNormalizer ?? throw new ArgumentNullException(nameof(keyNormalizer));
        }

        protected override ProjectionDefinition<MeetingRole> ExcludeGetProjection { get; }

        private async Task EnsureAllowAccess()
        {
            var isUser = await currentUser.IsInRole(AccountRole.USER);
            if (isUser)
                throw new AccessViolationException(Text("meetingRole.notAllowToAccess"));
        }

        public async Task<Result<MeetingRole>> Handle(MeetingRoleCreateCommand request, CancellationToken cancellationToken)
        {
            await EnsureAllowAccess();

            cancellationToken.ThrowIfCancellationRequested();

            var normalizeName = keyNormalizer.NormalizeName(request.Name);

            var collection = PersistentService.GetCollection<MeetingRole>();
            var existed = await collection.Find(x => x.NormalizedName == normalizeName && x.MeetingType == request.MeetingType).AnyAsync(cancellationToken);
            if (existed)
                return Error<MeetingRole>(Text("meetingRole.duplicateName"));

            var role = new MeetingRole
            {
                Name = request.Name,
                Description = request.Description,
                Permissions = request.Permissions,
                MeetingType = request.MeetingType,
                DisabledDate = request.IsDisabled ? new Occurrence() : null
            };
            role.SetNormalizedName(normalizeName);

            if (PersistentService.HasSession)
                await collection.InsertOneAsync(PersistentService.Session, role, cancellationToken: cancellationToken);
            else 
                await collection.InsertOneAsync(role, cancellationToken: cancellationToken);

            return Result(role);
        }

        public async Task<Result<MeetingRole>> Handle(MeetingRoleUpdateCommand request, CancellationToken cancellationToken)
        {
            await EnsureAllowAccess();

            cancellationToken.ThrowIfCancellationRequested();

            var collection = PersistentService.GetCollection<MeetingRole>();
            var role = await collection.Find(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            if (role == null)
                return Error<MeetingRole>(Text("meetingRole.notFound"));

            var normalizeName = keyNormalizer.NormalizeName(request.Name);
            var existed = await collection.Find(x => x.NormalizedName == normalizeName && x.MeetingType == role.MeetingType && x.Id != role.Id)
                .AnyAsync(cancellationToken);
            if (existed)
                return Error<MeetingRole>(Text("meetingRole.duplicateName"));

            role.Name = request.Name;
            role.Description = request.Description;
            role.Permissions = request.Permissions;
            if (request.IsDisabled && role.DisabledDate == null)
                role.DisabledDate = new Occurrence();

            role.SetNormalizedName(normalizeName);

            if (PersistentService.HasSession)
                await collection.ReplaceOneAsync(PersistentService.Session, r => r.Id == role.Id, role, cancellationToken: cancellationToken);
            else
                await collection.ReplaceOneAsync(r => r.Id == role.Id, role, cancellationToken: cancellationToken);

            return Result(role);
        }

        public async Task<Result<MeetingRole>> Handle(UpdateFieldByIdCommand<MeetingRole> request, CancellationToken cancellationToken)
        {
            await EnsureAllowAccess();

            cancellationToken.ThrowIfCancellationRequested();

            var collection = PersistentService.GetCollection<MeetingRole>();
            var updateField = Builders<MeetingRole>.Update.Set(request.Field, request.Value);
            var result = PersistentService.HasSession
                ? await collection.FindOneAndUpdateAsync(PersistentService.Session, x => x.Id == request.Id, updateField, cancellationToken: cancellationToken)
                : await collection.FindOneAndUpdateAsync(x => x.Id == request.Id, updateField, cancellationToken: cancellationToken);

            result?.SetPropertyValue(request.Field, request.Value);

            return Result(result);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<MeetingRole> request, CancellationToken cancellationToken)
        {
            await EnsureAllowAccess();

            cancellationToken.ThrowIfCancellationRequested();

            // check if any usage
            var roleFilter = Builders<MeetingAccess>.Filter.AnyEq(x => x.MeetingRoles, request.Id);
            var accessFilter = Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, roleFilter);
            var isInUse = await PersistentService.GetCollection<IdentityUser>()
                .Find(accessFilter).AnyAsync(cancellationToken);
            if (isInUse)
            {
                return Error<bool>(Text("meetingRole.isInUsed"));
            }

            var collection = PersistentService.GetCollection<MeetingRole>();
            var deleteResult = PersistentService.HasSession
                ? await collection.DeleteOneAsync(PersistentService.Session, x => x.Id.Equals(request.Id), cancellationToken: cancellationToken)
                : await collection.DeleteOneAsync(x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);

            return Result(deleteResult.IsAcknowledged);
        }

        public async Task<Result<List<MeetingRole>>> Handle(GetAllQuery<MeetingRole> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filters = new List<FilterDefinition<MeetingRole>>();

            if (!request.IsGetAll)
            {
                filters.Add(Builders<MeetingRole>.Filter.Eq(x => x.DisabledDate, null));
            }

            // query by meeting type
            if (request.Arguments.Any())
            {
                var meetingType = (MeetingType)request.Arguments.First();
                filters.Add(Builders<MeetingRole>.Filter.Eq(x => x.MeetingType, meetingType));
            }

            var collection = PersistentService.GetCollection<MeetingRole>();
            var result = filters.Any()
                ? await collection.Find(Builders<MeetingRole>.Filter.And(filters)).ToListAsync(cancellationToken)
                : await collection.AsQueryable().ToListAsync(cancellationToken);

            return Result(result);
        }

        public async Task<Result<MeetingRole>> Handle(GetByIdQuery<MeetingRole> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await PersistentService.GetCollection<MeetingRole>()
                .Find(x => x.Id.Equals(request.Id)).SingleOrDefaultAsync(cancellationToken);
            return Result(result);
        }

        public async Task<Result<List<string>>> Handle(MeetingRoleFilterCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<MeetingRole>.Filter.And(
                    Builders<MeetingRole>.Filter.Eq(x => x.DisabledDate, null),
                    Builders<MeetingRole>.Filter.AnyIn(x => x.Permissions, request.Permissions.Select(x => x.ToString()))
                );
            var result = await PersistentService.GetCollection<MeetingRole>()
                .DistinctAsync(x => x.Id, filter, cancellationToken: cancellationToken);
            return Result(await result.ToListAsync(cancellationToken));
        }
    }
}
