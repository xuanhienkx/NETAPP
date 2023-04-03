using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Events;
using api.domain.Queries;
using api.domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
    public class AccountHandler : PersistentHandler<IdentityUser, DomainPersistentService>,
        INotificationHandler<MeetingCreatedOrDeleteEvent>,
        // meeting groups
        IRequestHandler<MeetingGroupUpdateCommand, Result<MeetingGroup>>,
        IRequestHandler<DeleteByIdCommand<IdentityUser, MeetingGroup>, Result<bool>>,
        // meeting access
        IRequestHandler<MeetingAccessActionCommand, Result<bool>>,
        // user
        IRequestHandler<SearchQuery<Account>, Result<List<Account>>>,
        IRequestHandler<GetUsersAccessToMeeting, Result<List<Account>>>
    {
        private readonly ICurrentUser currentUser;
        private readonly ILookupNormalizer keyNormalizer;

        public AccountHandler(IMediator mediator, ICurrentUser currentUser, IPersistentService<DomainPersistentService> persistentService, ILookupNormalizer keyNormalizer, ILocalizer localizer)
            : base(mediator, persistentService, localizer)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.keyNormalizer = keyNormalizer ?? throw new ArgumentNullException(nameof(keyNormalizer));
        }

        #region Commands


        public async Task<Result<MeetingGroup>> Handle(MeetingGroupUpdateCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await UpdateMeetingGroup(request);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<IdentityUser, MeetingGroup> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await DeleteMeetingGroup(request, cancellationToken);
        }

        public async Task Handle(MeetingCreatedOrDeleteEvent notification, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await UpdateMeetingAccess(notification, cancellationToken);
        }

        public async Task<Result<bool>> Handle(MeetingAccessActionCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (request.IsGrantAccessRequest)
                return await GrantMeetingAccess(request, request.RequestFlag, cancellationToken);
            return await LockMeetingAccess(request, request.RequestFlag, cancellationToken);
        }

        #endregion

        #region Queries

        public Task<Result<List<Account>>> Handle(SearchQuery<Account> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return SearchUserByEmailOrUserName(request, cancellationToken);
        }

        public Task<Result<List<Account>>> Handle(GetUsersAccessToMeeting request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return SearchUserByMeeting(request, cancellationToken);
        }


        #endregion


        #region Helpers

        protected override ProjectionDefinition<IdentityUser> ExcludeGetProjection { get; } = Builders<IdentityUser>
            .Projection
            .Exclude(x => x.Claims)
            .Exclude(x => x.Logins)
            .Exclude(x => x.PasswordHash)
            .Exclude(x => x.NormalizedUserName)
            .Exclude(x => x.Tokens)
            .Exclude(x => x.MeetingAccesses)
            .Exclude(x => x.SecurityStamp)
            .Exclude(x => x.LockoutEndDate)
            .Exclude(x => x.CreatedDate)
            .Exclude(x => x.LockedDate)
            .Exclude(x => x.IsTwoFactorEnabled)
            .Exclude(x => x.DeletedDate)
            .Exclude(x => x.AccessFailedCount)
            .Exclude(x => x.IsLockoutEnabled)
            .Exclude(x => x.LockoutEndDate)
            .Exclude(x => x.NormalizeIdentityNumber);

        private async Task<Result<List<Account>>> SearchUserByEmailOrUserName(SearchQuery<Account> request, CancellationToken cancellationToken)
        {
            var query = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(x => x.DeletedDate, null),
                Builders<IdentityUser>.Filter.Or(
                    Builders<IdentityUser>.Filter.Regex(x => x.NormalizedUserName, new BsonRegularExpression(keyNormalizer.NormalizeName(request.Text))),
                    Builders<IdentityUser>.Filter.Regex(x => x.Email.NormalizedValue, new BsonRegularExpression(keyNormalizer.NormalizeEmail(request.Text)))
                )
            );

            var result = await PersistentService.GetCollection<IdentityUser>()
                .Find(query)
                .Project<Account>(ExcludeGetProjection)
                .SortByDescending(x => x.NormalizedUserName).Skip(request.Skip).Limit(request.Size)
                .ToListAsync(cancellationToken);

            return Result(result);
        }

        private async Task<Result<List<Account>>> SearchUserByMeeting(GetUsersAccessToMeeting request, CancellationToken cancellationToken)
        {

            var filters = new List<FilterDefinition<IdentityUser>>
            {
                Builders<IdentityUser>.Filter.Eq(x => x.DeletedDate, null),
                request.IsMemberOnly
                    ? Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses,
                        x => x.MeetingId.Equals(request.MeetingId) && x.IsViewer == false)
                    : Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses,
                        x => x.MeetingId.Equals(request.MeetingId))
            };

            if (request.IsMemberOnly)
            {
                if (request.Roles != null && request.Roles.Any())
                    Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(request.MeetingId) && x.IsViewer == false && x.MeetingRoles.Intersect(request.Roles).Any());
                else
                    Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(request.MeetingId) && x.IsViewer == false);
            }
            else
            {
                filters.Add(Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(request.MeetingId)));
            }

            var query = Builders<IdentityUser>.Filter.And(filters);
            var collection = PersistentService.GetCollection<IdentityUser>()
                .Find(query)
                .Project<Account>(
                    Builders<IdentityUser>.Projection.IncludeMany(
                        x => x.DisplayName, x => x.Avatar,
                        x => x.UserName, x => x.Email,
                        x => x.MeetingAccesses));

            var result = request.Top == 0
                ? await collection.ToListAsync(cancellationToken)
                : await collection.SortByDescending(x => x.NormalizedUserName)
                    .Skip(0).Limit(request.Top).ToListAsync(cancellationToken);

            if (request.IsMemberOnly && request.IsRoleDetail)
            {
                // update access roles
                var allRoles = await PersistentService.GetCollection<MeetingRole>()
                    .AsQueryable().Where(x => x.DisabledDate == null)
                    .ToListAsync(cancellationToken);

                var mrConverter = new Converter<string, MeetingRoleLite>(id => allRoles.Single(x => x.Id.Equals(id)));
                result.ForEach(x =>
                {
                    x.MeetingAccesses = x.MeetingAccesses
                        ?.Where(a => a.MeetingId.Equals(request.MeetingId) && a.IsViewer == false)
                        .Select(ma =>
                        {
                            ma.UserRoles =  ma.MeetingRoles?.ConvertAll(mrConverter);
                            return ma;
                        }).ToList();
                });
            }
            else
            {
                result.ForEach(x => x.MeetingAccesses = null);
            }

            return Result(result);
        }

       private async Task<Result<MeetingGroup>> UpdateMeetingGroup(MeetingGroupUpdateCommand request)
        {
            // check duplicate name
            var meetingGroup = currentUser.User.MeetingGroups.Find(x => x.Id != request.Id && x.Name.Equals(request.Name));
            if (meetingGroup != null)
                return Error<MeetingGroup>(Text("account.duplicateMeetingGroupName", request.Name));

            var group = new MeetingGroup(request.Name, request.Logo, request.Header, request.Footer);
            if (!string.IsNullOrEmpty(request.Id))
                group.Id = request.Id;

            return await UpdateOneToSubSet(currentUser.UserId, group, x => x.MeetingGroups);
        }

        private async Task<Result<bool>> DeleteMeetingGroup(DeleteByIdCommand<IdentityUser, MeetingGroup> request, CancellationToken cancellationToken)
        {
            var meetingGroup = currentUser.User.MeetingGroups.Find(x => x.Id == request.SubId);
            if (meetingGroup == null)
                return Error<bool>(Text("account.meetingGroupNotFound"));

            // check if meeting group has no children
            var hasChild = await PersistentService.GetCollection<Meeting>()
                .AsQueryable()
                .AnyAsync(x => x.GroupId.Equals(request.SubId), cancellationToken);

            if (hasChild)
                return Error<bool>(Text("account.meetingGroupHasChildren"));

            currentUser.User.MeetingGroups.Remove(meetingGroup);
            var result = await currentUser.Update();
            if (result.Succeeded)
                return Result(true);

            return Error<bool>(Text("account.deleteMeetingGroupFailed", result.Errors));
        }

        private async Task<bool> CheckAllRolesExistedAndSameMeetingType(MeetingAccessCommand content, MeetingType meetingType, CancellationToken cancellationToken)
        {
            var roleIds = content.MeetingRoles.Distinct().ToList();
            var roleQuery = Builders<MeetingRole>.Filter.And(
                Builders<MeetingRole>.Filter.Eq(x => x.MeetingType, meetingType),
                Builders<MeetingRole>.Filter.Eq(x => x.DisabledDate, null),
                Builders<MeetingRole>.Filter.In(x => x.Id, roleIds)
            );
            var allRoles = await PersistentService.GetCollection<MeetingRole>()
                .Find(roleQuery).ToListAsync(cancellationToken);

            if (allRoles.Count != roleIds.Count)
                return false;
            if (allRoles.Select(x => x.MeetingType).Distinct().Count() != 1)
                return false;
            return true;
        }

        private async Task UpdateMeetingAccess(MeetingCreatedOrDeleteEvent notification, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<IdentityUser>();

            if (notification.IsDeleted)
            {
                var filter = Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(notification.Id));

                // remove access to every users
                if (notification.IsPermanentDeleted)
                {
                    var deletedPullFilter =
                        Builders<IdentityUser>.Update.PullFilter(x => x.MeetingAccesses, m => m.MeetingId == notification.Id);

                    if (PersistentService.HasSession)
                        await collection.UpdateManyAsync(PersistentService.Session, filter, deletedPullFilter, cancellationToken: cancellationToken);
                    else
                        await collection.UpdateManyAsync(filter, deletedPullFilter, cancellationToken: cancellationToken);
                }
                else
                {
                    // update LockedDate
                    var updateFilter = Builders<IdentityUser>.Update.Set(x => x.MeetingAccesses[-1].LockedDate, new Occurrence());
                    if (PersistentService.HasSession)
                        await collection.UpdateManyAsync(PersistentService.Session, filter, updateFilter, cancellationToken: cancellationToken);
                    else
                        await collection.UpdateManyAsync(filter, updateFilter, cancellationToken: cancellationToken);
                }
            }
            else
            {
                // update for owner
                var access = new MeetingAccess
                {
                    IsOwner = true,
                    MeetingId = notification.Id,
                    MeetingType = notification.MeetingType
                };
                var filter = Builders<IdentityUser>.Filter.Eq(x => x.Id, currentUser.UserId);
                var update = Builders<IdentityUser>.Update.AddToSet(x => x.MeetingAccesses, access);
                if (PersistentService.HasSession)
                    await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken);
                else
                    await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
            }
        }

        private async Task<Result<bool>> GrantMeetingAccess(MeetingAccessActionCommand request, bool isDeleted, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<IdentityUser>();
            UpdateResult result;

            // remove access
            if (isDeleted)
            {
                var unset = Builders<IdentityUser>.Update.PullFilter(x => x.MeetingAccesses, x => x.MeetingId == request.MeetingId);
                result = PersistentService.HasSession
                ? await collection.UpdateOneAsync(PersistentService.Session, x => x.Id.Equals(request.UserId), unset, cancellationToken: cancellationToken)
                : await collection.UpdateOneAsync(x => x.Id.Equals(request.UserId), unset, cancellationToken: cancellationToken);

                if (result.ModifiedCount != 0)
                    return Result(true);

                return Error<bool>(Text("account.userOrMeetingNotFound"));
            }

            // grant access
            var meeting = await PersistentService.GetCollection<Meeting>()
                .Find(x => x.Id.Equals(request.MeetingId))
                .Include(x => x.Type)
                .SingleOrDefaultAsync(cancellationToken);

            if (meeting == null)
                return Error<bool>(Text("account.meetingNotFound"));

            if (!request.IsViewer && !await CheckAllRolesExistedAndSameMeetingType(request.Content, meeting.Type, cancellationToken))
                return Error<bool>(Text("account.roleExistAndTheSameMeetingType"));

            var filter = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(x => x.Id, request.UserId),
                Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(request.MeetingId) && x.IsViewer == request.IsViewer));
            var access = await collection.Find(filter)
                .Project(x => x.MeetingAccesses.FirstOrDefault())
                .SingleOrDefaultAsync(cancellationToken);

            UpdateDefinition<IdentityUser> update;
            if (access == null)
            {
                access = new MeetingAccess
                {
                    MeetingId = request.MeetingId,
                    MeetingType = meeting.Type,
                    IsViewer = request.IsViewer,
                    MeetingRoles = request.IsViewer ? null : request.Content.MeetingRoles
                };
                // insert
                filter = Builders<IdentityUser>.Filter.Eq(x => x.Id, request.UserId);
                update = Builders<IdentityUser>.Update.AddToSet(x => x.MeetingAccesses, access);
                result = PersistentService.HasSession
                ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

                if (result.MatchedCount != 0)
                    return Result(true);
            }
            else if (request.Content?.MeetingRoles != null)
            {
                update = Builders<IdentityUser>.Update.Set(x => x.MeetingAccesses[-1].MeetingRoles, request.Content.MeetingRoles);
                result = PersistentService.HasSession
                    ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                    : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

                if (result.MatchedCount != 0)
                    return Result(true);
            }
            
            return Error<bool>(Text("account.userNotFound"));
        }

        private async Task<Result<bool>> LockMeetingAccess(MeetingAccessActionCommand request, bool isBlock, CancellationToken cancellationToken)
        {
            if (currentUser.UserId == request.UserId)
                return Error<bool>(Text("account.grantAccessToYourself"));

            var collection = PersistentService.GetCollection<IdentityUser>();
            var unset = Builders<IdentityUser>.Update.Set(x => x.MeetingAccesses[-1].LockedDate, isBlock ? new Occurrence() : null);

            var filter = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Eq(x => x.Id, request.UserId),
                Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses, x => x.MeetingId.Equals(request.MeetingId) && x.IsViewer == request.IsViewer)
            );

            var result = PersistentService.HasSession
            ? await collection.UpdateOneAsync(PersistentService.Session, filter, unset, cancellationToken: cancellationToken)
            : await collection.UpdateOneAsync(filter, unset, cancellationToken: cancellationToken);

            if (result.ModifiedCount != 0)
                return Result(true);
            return Error<bool>(Text("account.userNotFound"));
        }

        #endregion



    }
}
