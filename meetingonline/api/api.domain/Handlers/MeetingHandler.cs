using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Events;
using api.domain.Services;
using AutoMapper;
using Hangfire;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using api.common;
using api.common.Commands;
using api.common.Queries;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain.Handlers
{
    public class MeetingHandler : MeetingHandlerBase,
        IRequestHandler<MeetingCreateCommand, Result<Meeting>>,
        IRequestHandler<MeetingUpdateCommand, Result<Meeting>>,
        IRequestHandler<MeetingStatusChangedCommand, Result<string>>,
        IRequestHandler<UpdateByIdCommand<Meeting>, Result<bool>>,
        IRequestHandler<UpdateManyByIdCommand<Meeting>, Result<UpdateResult>>,
        IRequestHandler<DeleteByIdCommand<MeetingLite>, Result<bool>>,
        // queries
        IRequestHandler<GetByIdQuery<Meeting>, Result<Meeting>>,
        IRequestHandler<GetAllQuery<Meeting>, Result<List<Meeting>>>,
        // meeting info
        IRequestHandler<MeetingUpdateContentCommand<MeetingInfo>, Result<MeetingInfo>>,
        IRequestHandler<DeleteByIdCommand<Meeting, MeetingInfo>, Result<bool>>,
        IRequestHandler<DeleteByIdCommand<Meeting, MeetingInfo, MediaResource>, Result<bool>>,
        // election matter
        IRequestHandler<MeetingUpdateContentCommand<ElectionMatter>, Result<ElectionMatter>>,
        IRequestHandler<MeetingElectionMatterIndexedCommand, Result<bool>>,
        IRequestHandler<MeetingElectionVoteUpdateCommand, Result<bool>>,
        IRequestHandler<DeleteByIdCommand<Meeting, ElectionMatter>, Result<bool>>,
        IRequestHandler<DeleteByIdCommand<Meeting, ElectionMatter, MediaResource>, Result<bool>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IBackgroundJobClient backgroundJob;
        private readonly IMapper mapper;

        public MeetingHandler(
            IMediator mediator,
            IPersistentService<DomainPersistentService> persistentService,
            ICurrentUser currentUser,
            IBackgroundJobClient backgroundJob,
            IMapper mapper,
            ILocalizer localizer)
            : base(mediator, persistentService, localizer)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.backgroundJob = backgroundJob ?? throw new ArgumentNullException(nameof(backgroundJob));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<Meeting>> Handle(MeetingCreateCommand request, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();
            return await CreateMeeting(request, cancellation);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<MeetingLite> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await DeleteMeeting(request, cancellationToken);
        }

        public async Task<Result<Meeting>> Handle(MeetingUpdateCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await UpdateMeeting(request, cancellationToken);
        }

        public async Task<Result<Meeting>> Handle(GetByIdQuery<Meeting> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await GetMeetingForCurrentUser(request, cancellationToken);
        }

        public Task<Result<List<Meeting>>> Handle(GetAllQuery<Meeting> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return GetAllMeetingsForCurrentUser(request, cancellationToken);
        }

        public Task<Result<MeetingInfo>> Handle(MeetingUpdateContentCommand<MeetingInfo> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return UpdateMeetingContent(request.MeetingId, request.Value, meeting => meeting.Contents,
                cancellationToken);
        }

        public Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, MeetingInfo> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // delete election content
            return DeleteMeetingContent(request, m => m.Contents, cancellationToken);
        }

        public Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, MeetingInfo, MediaResource> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // delete attachment
            return DeleteMeetingContent(request, m => m.Contents, m => m.Contents[-1].Attachments, cancellationToken);
        }

        public Task<Result<ElectionMatter>> Handle(MeetingUpdateContentCommand<ElectionMatter> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!request.Value.Optional && (request.Value.Options == null || !request.Value.Options.Any()))
            {
                request.Value.Options = new List<ElectionOption>
                {
                    new ElectionOption{ Name = ProviderConstants.ElectionYes },
                    new ElectionOption{ Name = ProviderConstants.ElectionNo },
                    new ElectionOption{ Name = ProviderConstants.ElectionIgnore }
                };
            }
            return UpdateMeetingContent(request.MeetingId, request.Value, meeting => meeting.ElectionMatters,
                cancellationToken);
        }

        public Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, ElectionMatter> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // delete election matter
            return DeleteMeetingContent(request, m => m.ElectionMatters, cancellationToken);
        }

        public Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, ElectionMatter, MediaResource> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // delete attachment
            return DeleteMeetingContent(request, m => m.ElectionMatters, m => m.ElectionMatters[-1].Attachments, cancellationToken);

        }

        public Task<Result<bool>> Handle(MeetingElectionMatterIndexedCommand request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return IndexedMeetingElectionMatter(request, cancellationToken);
        }

        public async Task<Result<string>> Handle(MeetingStatusChangedCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return request.Status switch
            {
                MeetingStatus.Lock => await LockMeeting(request.Id, cancellationToken),
                MeetingStatus.Open => await OpenMeetingSession(request.Id, cancellationToken),
                MeetingStatus.Close => await CloseMeeting(request.Id, cancellationToken),
                _ => Error<string>(Text("meeting.notSupport")),
            };
        }

        public async Task<Result<bool>> Handle(UpdateByIdCommand<Meeting> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var rs = await Update(request.Id,
                o => o.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close)
                    .Set(request.Field, request.Value),
                cancellationToken);
            return Result(rs.ModifiedCount != 0);
        }

        public async Task<Result<UpdateResult>> Handle(UpdateManyByIdCommand<Meeting> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var rs = await Update(request.Id, o =>
            {
                o.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close);
                o.UpdateFields.AddRange(
                    request.UpdateFields.Select(x => Builders<Meeting>.Update.Set(x.Item1, x.Item2)));
            }, cancellationToken);
            return Result(rs);

        }

        public Task<Result<bool>> Handle(MeetingElectionVoteUpdateCommand request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return UpdateElectionMaterVote(request, cancellationToken);
        }


        #region Helpers

        private async Task<Result<Meeting>> CreateMeeting(MeetingCreateCommand request, CancellationToken cancellation)
        {
            // check meeting group exists
            if (!string.IsNullOrEmpty(request.GroupId) && !currentUser.IsGroupExisted(request.GroupId))
                return Error<Meeting>(Text("meeting.groupNotExisted"));

            // create meeting
            var meeting = new Meeting(request.Name, request.Description, request.Address, request.OpenedDate,
                request.Type)
            {
                GroupId = request.GroupId,
                Logo = request.Logo,
                Header = request.Header,
                Footer = request.Footer
            };

            if (PersistentService.HasSession)
                await PersistentService.GetCollection<Meeting>().InsertOneAsync(PersistentService.Session, meeting, cancellationToken: cancellation);
            else
                await PersistentService.GetCollection<Meeting>().InsertOneAsync(meeting, cancellationToken: cancellation);

            // update meeting to current user

            await Mediator.Publish(new MeetingCreatedOrDeleteEvent(meeting.Id, meeting.Type), cancellation);

            return Result(meeting);
        }

        private async Task<Result<Meeting>> UpdateMeeting(MeetingUpdateCommand request, CancellationToken cancellation)
        {
            var filter = Builders<Meeting>.Filter.WhereAll(x => x.Id.Equals(request.Id),
                x => x.Status != MeetingStatus.Open, x => x.ClosedDate == null);
            var update = Builders<Meeting>.Update
                .Set(x => x.Name, request.Name)
                .Set(x => x.Address, request.Address)
                .Set(x => x.Description, request.Description)
                .Set(x => x.OpenedDate, Occurrence.FromLocal(request.OpenedDate))
                .Set(x => x.GroupId, request.GroupId)
                .Set(x => x.Logo, request.Logo)
                .Set(x => x.Header, request.Header)
                .Set(x => x.Footer, request.Footer);
            var options = new FindOneAndUpdateOptions<Meeting>
            {
                ReturnDocument = ReturnDocument.After,
                Projection = ExcludeGetProjection
            };
            var updated = PersistentService.HasSession
                ? await PersistentService.GetCollection<Meeting>().FindOneAndUpdateAsync(PersistentService.Session, filter, update, options, cancellation)
                : await PersistentService.GetCollection<Meeting>().FindOneAndUpdateAsync(filter, update, options, cancellation);

            if (updated == null)
                return Error<Meeting>(Text("meeting.notFound"));

            return Result(updated);
        }

        private async Task<Result<bool>> DeleteMeeting(DeleteByIdCommand<MeetingLite> request,
            CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<Meeting>();

            // only accepted meeting owner do this
            var isOwner = await currentUser.HasMeetingAccess(request.Id);
            if (!isOwner)
                return Error<bool>(Text("meeting.notAllowToDelete"));

            // check if meeting having giving access to anyone
            var isInUseFilter = Builders<IdentityUser>.Filter.And(
                Builders<IdentityUser>.Filter.Not(Builders<IdentityUser>.Filter.Eq(x => x.Id, currentUser.UserId)),
                Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses,
                    x => !x.IsOwner && x.MeetingId == request.Id));
            var isInUse = await PersistentService.GetCollection<IdentityUser>()
                .Find(isInUseFilter).AnyAsync(cancellationToken);

            bool isDeleted;
            if (!isInUse)
            {
                var result = PersistentService.HasSession
                    ? await collection.DeleteOneAsync(PersistentService.Session, x => x.Id.Equals(request.Id), cancellationToken: cancellationToken)
                    : await collection.DeleteOneAsync(x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);
                isDeleted = result.IsAcknowledged;
            }
            else
            {
                var updated = Builders<Meeting>.Update.Set(x => x.DeletedDate, new Occurrence());
                var result = PersistentService.HasSession
                    ? await collection.UpdateOneAsync(PersistentService.Session, x => x.Id.Equals(request.Id), updated, cancellationToken: cancellationToken)
                    : await collection.UpdateOneAsync(x => x.Id.Equals(request.Id), updated, cancellationToken: cancellationToken);
                isDeleted = result.IsAcknowledged;
            }

            if (!isDeleted)
                return Error<bool>(Text("meeting.notFound"));

            await Mediator.Publish(
                new MeetingCreatedOrDeleteEvent(request.Id, isDeleted: true,
                    isPermanentDeleted: request.IsPermanentDeleted),
                cancellationToken);

            return Result(true);
        }

        private async Task<Result<string>> LockMeeting(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, id),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Started));
            var update = Builders<Meeting>.Update.Set(x => x.Status, MeetingStatus.Locking);
            var option = new FindOneAndUpdateOptions<Meeting>
            {
                ReturnDocument = ReturnDocument.After,
                Projection = Builders<Meeting>.Projection
                    .Include(x => x.Name)
                    .Include(x => x.Address)
                    .Include(x => x.OpenedDate)
                    .Include(x => x.Holders)
            };
            var collection = PersistentService.GetCollection<Meeting>();
            var meeting = PersistentService.HasSession
                ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
                : await collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);
            if (meeting == null)
                return Error<string>(Text("meeting.notFound"));

            // publish to execute long process
            var meetingLite = mapper.Map<MeetingLite>(meeting);
            var hfId = ObjectId.GenerateNewId().ToString();
            backgroundJob.Enqueue(() => Mediator.Publish(new MeetingMapHolderToIdentityUserEvent(hfId, meetingLite, currentUser.UserId), CancellationToken.None));

            return Result(hfId);
        }

        private async Task<Result<string>> OpenMeetingSession(string id, CancellationToken cancellationToken)
        {
            var rs = await Update(id,
                o => o.Where(x => x.Status, MeetingStatus.Lock).Set(x => x.Status, MeetingStatus.Open),
                cancellationToken);

            if (rs.ModifiedCount != 0)
                return Result(string.Empty);
            return Error<string>("meeting.notFound");
        }

        private Task<Result<string>> CloseMeeting(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        private async Task<Result<Meeting>> GetMeetingForCurrentUser(GetByIdQuery<Meeting> request,
            CancellationToken cancellationToken)
        {
            var meetingAccess = currentUser.User.MeetingAccesses.FirstOrDefault(x =>
                x.MeetingId == request.Id && (x.IsOwner || x.LockedDate == null));
            if (meetingAccess == null)
                return Error<Meeting>(Text("meeting.accessLimit"));

            var meeting = await PersistentService.GetCollection<Meeting>()
                .Find(f => f.Id.Equals(request.Id))
                .Project<Meeting>(ExcludeGetProjection)
                .FirstOrDefaultAsync(cancellationToken);

            if (meeting != null)
            {
                meeting.IsOwner = meetingAccess.IsOwner;
                if (!meeting.IsOwner && meetingAccess.MeetingRoles != null)
                {
                    var roles = await PersistentService
                        .GetCollection<MeetingRole>()
                        .Find(x => x.DisabledDate == null)
                        .ToListAsync(cancellationToken);
                    meeting.UserRoles =
                        meetingAccess.MeetingRoles.ConvertAll(id => roles.FirstOrDefault(r => r.Id == id));
                }

                if (meetingAccess.IsViewer)
                {
                    var role = new MeetingRole
                    {
                        Name = "Viewer",
                        Permissions = new List<string>() { "meeting_access_view" },
                        MeetingType = meeting.Type,
                    };

                    role.SetNormalizedName(role.Name);

                    if (meeting.UserRoles?.Count > 0)
                    {

                        meeting.UserRoles.Add(role);
                    }
                    else
                    {
                        meeting.UserRoles = new List<MeetingRole>() { role };
                    }
                }
            }

            return Result(meeting);
        }

        private async Task<Result<List<Meeting>>> GetAllMeetingsForCurrentUser(GetAllQuery<Meeting> request,
            CancellationToken cancellationToken)
        {
            if (currentUser.User?.MeetingAccesses == null || !currentUser.User.MeetingAccesses.Any())
                return new Result<List<Meeting>>();

            var collection = PersistentService.GetCollection<Meeting>();
            var meetingAccess = request.IsGetAll
                ? currentUser.User.MeetingAccesses.ToList()
                : currentUser.User.MeetingAccesses.Where(x => x.IsOwner || x.LockedDate == null).ToList();
            var meetingIds = meetingAccess.Select(x => x.MeetingId).ToList();

            var query = request.IsGetAll
                ? Builders<Meeting>.Filter.In(x => x.Id, meetingIds)
                : Builders<Meeting>.Filter.And(
                    Builders<Meeting>.Filter.Eq(x => x.DeletedDate, null),
                    Builders<Meeting>.Filter.In(x => x.Id, meetingIds)
                );
            var sort = Builders<Meeting>.Sort.Combine(
                Builders<Meeting>.Sort.Ascending(x => x.Status),
                Builders<Meeting>.Sort.Descending(x => x.OpenedDate),
                Builders<Meeting>.Sort.Ascending(x => x.Name)
            );

            var meetings = await collection.Find(query)
                .Project<Meeting>(ExcludeGetProjection
                    .Exclude(x => x.Contents)
                    .Exclude(x => x.ElectionMatters)
                    .Exclude(x => x.Header)
                    .Exclude(x => x.Footer)
                    .Exclude(x => x.HolderUploadFile))
                .Sort(sort).ToListAsync(cancellationToken);

            var roles = await Mediator.Send(new GetAllQuery<MeetingRole>(), cancellationToken);
            if (roles.Succeeded)
            {
                meetings.ForEach(m =>
                {
                    var ma = meetingAccess.FirstOrDefault(x => x.MeetingId == m.Id);
                    if (ma != null)
                    {
                        m.IsOwner = ma.IsOwner;

                        if (!ma.IsOwner && ma.MeetingRoles != null && ma.MeetingRoles.Count > 0)
                        {
                            m.UserRoles = ma.MeetingRoles.ConvertAll(id => roles.Value.FirstOrDefault(r => r.Id == id));
                        }
                    }
                });
            }

            return Result(meetings);
        }

        private Task<Result<T>> UpdateMeetingContent<T>(
            string meetingId, T value,
            Expression<Func<Meeting, IEnumerable<T>>> field,
            CancellationToken cancellationToken) where T : BaseModel
        {
            return UpdateOneToSubSet(meetingId, value, field,
                o => o.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close),
                cancellationToken);
        }

        private async Task<Result<bool>> DeleteMeetingContent<T>(
            DeleteByIdCommand<Meeting, T> request, Expression<Func<Meeting, IEnumerable<T>>> contentField,
            CancellationToken cancellationToken = default)
            where T : ILiteralId
        {
            return await DeleteFromSubSet(request.Id, request.SubId, contentField,
                o => o.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close),
                cancellationToken);
        }

        private async Task<Result<bool>> DeleteMeetingContent<T, TO>(
            DeleteByIdCommand<Meeting, T, TO> request, Expression<Func<Meeting, IEnumerable<T>>> contentField,
            Expression<Func<Meeting, IEnumerable<TO>>> pullField, CancellationToken cancellationToken = default)
            where T : ILiteralId
            where TO : ILiteralId
        {
            return await DeleteFromNestedSubSet(request.Id, request.SubId, request.NestedSubId, contentField, pullField,
                o => o.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close),
                cancellationToken);
        }

        private async Task<Result<bool>> IndexedMeetingElectionMatter(MeetingElectionMatterIndexedCommand request,
            CancellationToken cancellationToken = default)
        {
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.Where(x => x.Status != MeetingStatus.Open || x.Status != MeetingStatus.Close));
            var pull = Builders<Meeting>.Update.PullFilter(x => x.ElectionMatters, x => x.Id.Equals(request.MatterId));

            var collection = PersistentService.GetCollection<Meeting>();
            var option = new FindOneAndUpdateOptions<Meeting, ElectionMatter>()
            {
                Projection = Builders<Meeting>.Projection.Expression(x =>
                    x.ElectionMatters.FirstOrDefault(m => m.Id.Equals(request.MatterId))),
                ReturnDocument = ReturnDocument.Before
            };
            var matter = PersistentService.HasSession
                ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, pull, options: option, cancellationToken: cancellationToken)
                : await collection.FindOneAndUpdateAsync(filter, pull, options: option, cancellationToken: cancellationToken);

            if (matter == null)
                return Error<bool>(Text("meeting.matterNotFound"));

            // update new index
            var updateMatter = new List<ElectionMatter> { matter };
            var update =
                Builders<Meeting>.Update.PushEach(x => x.ElectionMatters, updateMatter, position: request.Index);
            var result = PersistentService.HasSession
                ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            return Result(result.ModifiedCount != 0 || result.MatchedCount != 0);
        }

        private async Task<Result<bool>> UpdateElectionMaterVote(MeetingElectionVoteUpdateCommand request, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<Meeting>();
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Open),
                Builders<Meeting>.Filter.ElemMatch(x => x.ElectionMatters, x => x.Id.Equals(request.NewVote.Id)));

            var vote = mapper.Map<ElectionMatter>(request.NewVote);
            if (vote.Options != null && request.OldVote != null)
            {
                vote.Options.ForEach(x =>
                {
                    x.Votes -= (int)request.OldVote?.Options.Single(o => o.Id.Equals(x.Id)).Votes;
                });
                var exVotes = request.OldVote.Options.Except(request.NewVote.Options, new IdEqualityComparer<Vote>())
                    .Select(x => mapper.Map<ElectionOption>(x))
                    .ToList();
                exVotes.ForEach(x =>
                {
                    x.Votes = -x.Votes;
                    vote.Options.Add(x);
                });
            }
            var matter = await collection.Find(filter).Project(x => x.ElectionMatters.FirstOrDefault(e => e.Id.Equals(request.NewVote.Id)))
                .SingleAsync(cancellationToken);

            if (matter.Options != null && matter.Options.Any())
            {
                if (matter.Taken > vote.Options?.Count)
                    return Error<bool>(Text("meeting.votes.invalidOptions"));

                vote.Options?.ForEach(x => { matter.Options.Single(m => m.Id.Equals(x.Id)).Votes += x.Votes; });
            }

            var update = Builders<Meeting>.Update.Set(x => x.ElectionMatters[-1], matter);
            var result = PersistentService.HasSession
                ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            return Result(result.ModifiedCount != 0 || result.MatchedCount != 0);
        }

        #endregion
    }
}