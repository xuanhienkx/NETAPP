using api.common.Commands;
using api.common.Events;
using api.common.Models;
using api.common.Queries;
using api.common.Shared;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Queries;
using api.domain.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.domain.Handlers
{
    public class AttendeeHandler : MeetingHandlerBase,
        // attendee
        IRequestHandler<MeetingAttendeeCheckInCommand, Result<Attendee>>,
        IRequestHandler<MeetingAttendeeCheckOutCommand, Result<Holder>>,
        IRequestHandler<MeetingUpdateContentCommand<Attendee>, Result<Attendee>>,
        IRequestHandler<DeleteByIdCommand<Meeting, Attendee>, Result<bool>>,
        IRequestHandler<SearchQuery<Meeting, Attendee>, Result<List<Attendee>>>,
        // query
        IRequestHandler<MeetingAttendeeDelegatedQuery, Result<List<Attendee>>>,
        IRequestHandler<GetByIdFromSubSetQuery<Meeting, Attendee>, Result<Attendee>>,
        // vote
        IRequestHandler<AttendeeMeetingElectionVoteCommand, Result<bool>>,
        IRequestHandler<AttendeeMeetingCheckInReportCommand, Result<List<MediaResource>>>,
        // delegate request
        IRequestHandler<MeetingDelegationRequestCommand<Attendee>, Result<bool>>
    {
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;
        private readonly IContentProviderService contentProvider;
        private readonly ILookupNormalizer normalizer;

        public AttendeeHandler(
            IMediator mediator,
            IPersistentService<DomainPersistentService> persistentService,
            ILocalizer localizer,
            IMapper mapper,
            ICurrentUser currentUser,
            IContentProviderService contentProvider,
            ILookupNormalizer normalizer)
            : base(mediator, persistentService, localizer)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.contentProvider = contentProvider ?? throw new ArgumentNullException(nameof(contentProvider));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
        }

        public async Task<Result<Attendee>> Handle(MeetingUpdateContentCommand<Attendee> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // update missing field
            if (string.IsNullOrEmpty(request.Value.Id))
            {
                request.Value.Id = ObjectId.GenerateNewId().ToString();
                request.Value.Shares = request.Value.OwnedVotes = 0;
            }

            request.Value.NormalizeIdentityNumber = normalizer.NormalizeName(request.Value.IdentityNumber.Trim());
            request.Value.NormalizedEmail = normalizer.NormalizeEmail(request.Value.Email);

            if (request.Value.OwnedVotes == 0 && await Exists(request.MeetingId, x => x.Holders, x => x.NormalizeIdentityNumber.Equals(request.Value.NormalizeIdentityNumber), cancellationToken))
            {
                return Error<Attendee>(Text("attendee.existedHolder"));
            }

            var existedIdentity = request.Value.Email == null
                ? await Exists(request.MeetingId, x => x.Attendees,
                    x => x.Id != request.Value.Id &&
                         x.NormalizeIdentityNumber.Equals(request.Value.NormalizeIdentityNumber), cancellationToken)
                : await Exists(request.MeetingId, x => x.Attendees,
                    x => x.Id != request.Value.Id &&
                         (x.NormalizeIdentityNumber.Equals(request.Value.NormalizeIdentityNumber) ||
                         (x.NormalizedEmail != null && x.NormalizedEmail.Equals(request.Value.NormalizedEmail))),
                    cancellationToken);

            if (existedIdentity)
                return Error<Attendee>(Text("attendee.existedIdentityOrEmail"));

            // check Mandators when delegated
            var sharedVotes = 0;
            if (request.Value.Mandators != null && request.Value.Mandators.Count > 0)
            {
                request.Value.Mandators = request.Value.Mandators.Where(v => v.Votes > 0).ToList();
                request.Value.SharedVotes = request.Value.Mandators.Sum(x => x.Votes);

                // update delegation request for those are delegations created by admin when check-in wil be create delegation request
                var mandators = request.Value.Mandators.Where(x => x.ApprovedDate == null).ToList();
                foreach (var mandator in mandators)
                {
                    var holder = mapper.Map<Holder>(mandator);
                    var delegation = mapper.Map<Delegation>(request.Value);
                    delegation.Votes = mandator.Votes;
                    delegation.ApprovedDate = new Occurrence();
                    sharedVotes += delegation.Votes;


                    await Mediator.Send(new DelegateRequestUpdateCommand(request.MeetingId, holder, delegation, new Activity(currentUser, "admin_check_in")), cancellationToken);
                }
            }
            else
            {
                request.Value.SharedVotes = 0;
            }

            request.Value.TotalVotes = request.Value.OwnedVotes - request.Value.DelegatingVotes + request.Value.SharedVotes;
            request.Value.CheckedInDate = new Occurrence();
            request.Value.IsOnlineCheckIn = request.IsOnline;

            // start process insert/update
            var onUpdate = new Action<Attendee>(async old =>
            {
                // update summary
                await Update(request.MeetingId, o =>
            {

                o.FilterFields.Add(Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(request.Value.Id)));

                o.UpdateFields.AddRange(new[]
            {
                        Builders<Meeting>.Update.Inc(x => x.Holders[-1].DelegatedVotes, sharedVotes),
                        Builders<Meeting>.Update.Inc(x => x.Summary.CheckInVotes, request.Value.TotalVotes - old.TotalVotes),
                });
            }, cancellationToken);
            });

            var onInsert = new Action(async () =>
            {

                if (request.Value.OwnedVotes == 0)
                {
                    await Update(request.MeetingId, o =>
                    {
                        o.UpdateFields.AddRange(new[]
                        {
                            Builders<Meeting>.Update.Inc(x => x.Summary.CheckIn, 1),
                            Builders<Meeting>.Update.Inc(x => x.Summary.CheckInVotes, request.Value.TotalVotes),
                        });

                        if (request.IsOnline)
                        {
                            o.UpdateFields.Add(Builders<Meeting>.Update
                                    .Inc(x => x.Summary.CheckIn, 1)
                                .Inc(x => x.Summary.OnlineCheckIn, 1));
                            o.UpdateFields.Add(Builders<Meeting>.Update.Inc(x => x.Summary.OnlineCheckInVotes, request.Value.TotalVotes));
                        }

                    }, cancellationToken);
                }
                else
                {
                    await Update(request.MeetingId, o =>
                    {
                        o.FilterFields.Add(Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(request.Value.Id)));
                        o.UpdateFields.AddRange(new[]
                        {
                            Builders<Meeting>.Update.Set(x => x.Holders[-1].CheckedInDate, new Occurrence()),
                            Builders<Meeting>.Update.Set(x => x.Holders[-1].AvailableVotes, 0),
                            Builders<Meeting>.Update.Inc(x => x.Holders[-1].DelegatedVotes, sharedVotes),

                            Builders<Meeting>.Update.Inc(x => x.Summary.CheckIn, 1),
                            Builders<Meeting>.Update.Inc(x => x.Summary.CheckInVotes, request.Value.TotalVotes),

                            Builders<Meeting>.Update.Inc(x => x.Summary.HolderCheckIn, 1),
                            Builders<Meeting>.Update.Inc(x => x.Summary.HolderCheckInVotes, request.Value.TotalVotes)
                        });

                        if (request.IsOnline)
                        {
                            o.UpdateFields.Add(Builders<Meeting>.Update.Inc(x => x.Summary.OnlineCheckIn, 1));
                            o.UpdateFields.Add(Builders<Meeting>.Update.Inc(x => x.Summary.OnlineCheckInVotes, request.Value.TotalVotes));

                            o.UpdateFields.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderOnlineCheckIn, 1));
                            o.UpdateFields.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderOnlineCheckInVotes, request.Value.TotalVotes));
                        }

                    }, cancellationToken);
                }
            });

            var result = await UpdateOneToSubSet(request.MeetingId, h => h.Id.Equals(request.Value.Id),
                x => x.Attendees, o =>
                {
                    o.Where(x => x.Status.Equals(MeetingStatus.Open));
                    o.OnUpdated = onUpdate;
                    o.OnInserted = onInsert;
                    o.OnSetupItem = attendee =>
                    {
                        if (attendee == null)
                            return request.Value;

                        // update the holder
                        attendee.DisplayName = request.Value.DisplayName;
                        attendee.Email = request.Value.Email;
                        attendee.NormalizedEmail = request.Value.NormalizedEmail;
                        attendee.PhoneNumber = request.Value.PhoneNumber;
                        attendee.Address = request.Value.Address;
                        attendee.IdentityIssuedDate = request.Value.IdentityIssuedDate;
                        attendee.IdentityIssuer = request.Value.IdentityIssuer;
                        attendee.IdentityNumber = request.Value.IdentityNumber;
                        attendee.IdentityType = request.Value.IdentityType;
                        attendee.NormalizeIdentityNumber = request.Value.NormalizeIdentityNumber;
                        attendee.Nationality = request.Value.Nationality;
                        attendee.Mandators = request.Value.Mandators;
                        attendee.RepTitle = request.Value.RepTitle;
                        attendee.SharedVotes = request.Value.SharedVotes;
                        attendee.TotalVotes = request.Value.TotalVotes;
                        attendee.IsRepresentative = request.Value.IsRepresentative;
                        attendee.Attachments = request.Value.Attachments;

                        return attendee;
                    };
                }, cancellationToken);

            if (!result.Succeeded)
                result.Errors.Add(Text("meeting.statusNotAllowToPerform"));

            return Result(request.Value);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, Attendee> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var onDeleted = new Action<Attendee>(async old =>
            {
                var filters = new List<FilterDefinition<Meeting>>();
                var updates = new List<UpdateDefinition<Meeting>>
                {
                    Builders<Meeting>.Update.Inc(m => m.Summary.CheckIn, -1),
                    Builders<Meeting>.Update.Inc(m => m.Summary.CheckInVotes, -old.TotalVotes)
                };

                if (old.IsOnlineCheckIn)
                {
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.OnlineCheckIn, -1));
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.OnlineCheckInVotes, -old.TotalVotes));
                }

                // update meeting summary
                if (old.OwnedVotes > 0)
                {
                    // update holder checkin date
                    filters.Add(Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(old.Id)));

                    updates.Add(Builders<Meeting>.Update.Set(x => x.Holders[-1].CheckedInDate, null));
                    updates.Add(Builders<Meeting>.Update.Set(x => x.Holders[-1].ConfirmedDate, null));
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Holders[-1].AvailableVotes, old.TotalVotes - old.SharedVotes - old.DelegatingVotes));
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.ConfirmedVotes, -old.TotalVotes));
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderCheckIn, -1));
                    updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderCheckInVotes, -old.TotalVotes));

                    if (old.IsOnlineCheckIn)
                    {
                        updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderOnlineCheckIn, -1));
                        updates.Add(Builders<Meeting>.Update.Inc(x => x.Summary.HolderOnlineCheckInVotes, -old.TotalVotes));
                    }
                }

                await Update(request.Id, o =>
                {
                    o.FilterFields.AddRange(filters);
                    o.UpdateFields.AddRange(updates);
                }, cancellationToken);
            });

            var result = await DeleteFromSubSet(request.Id, request.SubId, m => m.Attendees, o =>
            {
                o.Where(x => x.Status, MeetingStatus.Open);
                o.OnDeleted = onDeleted;

                var attendeeNotOnline = Builders<Meeting>.Filter.ElemMatch(x => x.Attendees,
                    x => x.Id.Equals(request.SubId) && !x.IsOnlineCheckIn);
                o.FilterFields.Add(attendeeNotOnline);
            }, cancellationToken);

            if (!result.Succeeded || !result.Value)
                result.Errors = new[] { Text("holder.invalidStateForDeletingOrResourceNotFound") };

            return result;
        }

        public async Task<Result<List<Attendee>>> Handle(SearchQuery<Meeting, Attendee> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var projection = string.IsNullOrEmpty(request.Text)
                ? Builders<Meeting>.Projection.Expression(x => x.Attendees.Skip(request.Skip).Take(request.Size))
                : Builders<Meeting>.Projection.Expression(x =>
                    x.Attendees.Where(a =>
                            a.NormalizeIdentityNumber.Contains(request.Text, StringComparison.OrdinalIgnoreCase) ||
                            a.DisplayName.StartsWith(request.Text, StringComparison.OrdinalIgnoreCase))
                        .Skip(request.Skip).Take(request.Size));

            return await QuerySubSet(request.Id, projection, cancellationToken: cancellationToken);
        }

        public Task<Result<bool>> Handle(AttendeeMeetingElectionVoteCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return UpdateAttendeeVote(request, cancellationToken);
        }

        public async Task<Result<Attendee>> Handle(MeetingAttendeeCheckInCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await AttendeeCheckIn(request.MeetingId, cancellationToken);
        }

        public async Task<Result<Holder>> Handle(MeetingAttendeeCheckOutCommand request, CancellationToken cancellationToken)
        {
            // check-out
            cancellationToken.ThrowIfCancellationRequested();
            return await AttendeeCheckOut(request.MeetingId, cancellationToken);
        }

        public async Task<Result<List<Attendee>>> Handle(MeetingAttendeeDelegatedQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.ElemMatch(x => x.Attendees, x => x.IsRepresentative));

            var result = await PersistentService.GetCollection<Meeting>()
                .Find(filter)
                .Project(x => x.Attendees.Where(a => a.IsRepresentative))
                .FirstOrDefaultAsync(cancellationToken);

            return Result(result?.ToList());
        }

        public Task<Result<Attendee>> Handle(GetByIdFromSubSetQuery<Meeting, Attendee> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // get by identityClient
            if (string.IsNullOrEmpty(request.SubId))
                return QueryByIdFromSubSet(request.Id, x => x.Attendees, h => h.IdentityUserId != null && h.IdentityUserId == currentUser.UserId, cancellationToken: cancellationToken);

            return QueryByIdFromSubSet(request.Id, x => x.Attendees, h => h.Id.Equals(request.SubId), cancellationToken: cancellationToken);
        }

        public async Task<Result<List<MediaResource>>> Handle(AttendeeMeetingCheckInReportCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await Mediator.Send(new GetByIdQuery<Meeting>(request.MeetingId), cancellationToken);
            var meeting = result.Value;
            var attendeeFilter = new ExpressionFilterDefinition<Attendee>(x => x.IdentityUserId != null && x.Id == request.AttendId);
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.ElemMatch(x => x.Attendees, attendeeFilter));

            var collection = PersistentService.GetCollection<Meeting>();

            var attendee = await collection.Find(filter)
                .Project(x => x.Attendees.FirstOrDefault(h => attendeeFilter.Expression.Compile().Invoke(h)))
                .SingleOrDefaultAsync(cancellationToken);

            if (attendee == null)
                return Error<List<MediaResource>>(Text("attendee.notFindMeetingOrHolderOrHolderConfirmedOnline"));

            var placeHolders = contentProvider.GenerateReportForAttendCheckInOffline(meeting, attendee);
            var mediaResources = new List<MediaResource>();

            if (placeHolders.Count > 0)
            {
                foreach (var placeHolder in placeHolders)
                {
                    var media = await Mediator.Send(new ReportGenerateCommand(placeHolder.ReportTemplateName, placeHolder, attendee.IdentityNumber, $"[IdentityNumber:{attendee.IdentityNumber}]"), cancellationToken);
                    if (media.Succeeded)
                        mediaResources.Add(media.Value);
                }
            }

            return Result(mediaResources);
        }

        public async Task<Result<bool>> Handle(MeetingDelegationRequestCommand<Attendee> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Open),
                Builders<Meeting>.Filter.ElemMatch(x => x.Attendees,
                    x => x.IsRepresentative && x.Id.Equals(request.HolderId)));
            var update = Builders<Meeting>.Update
                .Inc(x => x.Attendees[-1].SharedVotes, request.Delegation.Votes)
                .Inc(x => x.Attendees[-1].TotalVotes, request.Delegation.Votes)
                .AddToSet(x => x.Attendees[-1].Mandators, request.Delegation);
            var result = PersistentService.HasSession
                ? await PersistentService.GetCollection<Meeting>().UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await PersistentService.GetCollection<Meeting>().UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            return Result(result.ModifiedCount != 0 || result.MatchedCount != 0);
        }

        #region Helpers


        private async Task<Result<Holder>> AttendeeCheckOut(string meetingId, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<Meeting>();

            var filter = Builders<Meeting>.Filter.Eq(x => x.Id, meetingId);
            var fullUpdate = Builders<Meeting>.Update.PullFilter(x => x.Attendees, x => x.IdentityUserId != null && x.IdentityUserId == currentUser.UserId);
            var option = new FindOneAndUpdateOptions<Meeting, Holder>
            {
                Projection = Builders<Meeting>.Projection.Expression(x => x.Holders.FirstOrDefault(a => a.IdentityUserId != null && a.IdentityUserId == currentUser.UserId))
            };
            var holder = await collection.FindOneAndUpdateAsync(filter, fullUpdate, option, cancellationToken);
            if (holder != null)
            {
                var returnedVotes = holder.OwnedVotes + holder.DelegatedVotes - holder.BlockedVotes;
                var availableVotes = holder.OwnedVotes - holder.BlockedVotes - holder.DelegatingVotes;
                // update holder and meeting
                var result = await Update(meetingId, o =>
                {
                    o.FilterFields.Add(
                        Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(holder.Id)));
                    o
                        .SetInc(x => x.Summary.CheckIn, -1)
                        .SetInc(x => x.Summary.CheckInVotes, -returnedVotes)
                        .SetInc(x => x.Summary.OnlineCheckIn, -1)
                        .SetInc(x => x.Summary.OnlineCheckInVotes, -returnedVotes)
                        .SetInc(x => x.Summary.HolderOnlineCheckIn, -1)
                        .SetInc(x => x.Summary.HolderOnlineCheckInVotes, -returnedVotes)
                        .SetInc(x => x.Holders[-1].AvailableVotes, availableVotes)
                        .Set(x => x.Holders[-1].CheckedInDate, null);
                }, cancellationToken);

                if (result.ModifiedCount != 0 || result.MatchedCount != 0)
                {
                    holder.AvailableVotes = availableVotes;
                    holder.CheckedInDate = null;
                    return Result(holder);
                }
            }

            return Error<Holder>(Text("attendee.notFindMeetingOrAttendeeNotCheckIn"));
        }

        private async Task<Result<Attendee>> AttendeeCheckIn(string meetingId, CancellationToken cancellationToken)
        {
            var holderFilter = new ExpressionFilterDefinition<Holder>(x => x.IdentityUserId != null && x.IdentityUserId == currentUser.UserId);
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, meetingId),
                Builders<Meeting>.Filter.ElemMatch(x => x.Holders, holderFilter));

            var collection = PersistentService.GetCollection<Meeting>();

            var holder = await collection.Find(filter)
                .Project(x => x.Holders.FirstOrDefault(h => holderFilter.Expression.Compile().Invoke(h)))
                .SingleOrDefaultAsync(cancellationToken);

            if (holder == null)
                return Error<Attendee>(Text("holder.notFindMeetingOrHolderOrHolderConfirmedOnline"));

            if (holder.CheckedInDate != null)
                return Error<Attendee>(Text("attendee.alreadyCheckIn"));

            // check-in
            // create attendee 
            var attendee = mapper.Map<Attendee>(holder);
            var attResult = await Mediator.Send(new MeetingUpdateContentCommand<Attendee>(meetingId, attendee, isOnline: true), cancellationToken);
            return attResult.Succeeded ? Result(attResult.Value) : Error<Attendee>(attResult.Errors);
        }



        private async Task<Result<bool>> UpdateAttendeeVote(AttendeeMeetingElectionVoteCommand request, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<Meeting>();

            var attendeeFilter = string.IsNullOrEmpty(request.AttendeeId)
                ? new ExpressionFilterDefinition<Attendee>(x => x.IdentityUserId != null && x.IdentityUserId.Equals(currentUser.UserId))
                : new ExpressionFilterDefinition<Attendee>(x => x.Id.Equals(request.AttendeeId));

            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Open),
                Builders<Meeting>.Filter.ElemMatch(x => x.Attendees, attendeeFilter));

            var oldVotes = await collection.Find(filter)
                .Project(x => x.Attendees.FirstOrDefault(a => attendeeFilter.Expression.Compile().Invoke(a)).Votes)
                .FirstOrDefaultAsync(cancellationToken);

            if (!request.IsForceUpdated && oldVotes != null)
            {
                return Error<bool>(Text("attendee.alreadyTookTheVote"));
            }

            var option = new FindOneAndUpdateOptions<Meeting, Attendee>
            {
                Projection = Builders<Meeting>.Projection.Expression(x => x.Attendees.SingleOrDefault(m => m.Id.Equals(request.AttendeeId))),
                ReturnDocument = ReturnDocument.After
            };

            var update = Builders<Meeting>.Update.Set(x => x.Attendees[-1].Votes, request.Votes);
            var attendee = PersistentService.HasSession
            ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
            : await collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);

            if (attendee != null)
            {
                foreach (var vote in attendee.Votes)
                {
                    var oldVote = oldVotes?.SingleOrDefault(x => x.Id.Equals(vote.Id));
                    await Mediator.Send(new MeetingElectionVoteUpdateCommand(request.MeetingId, oldVote, vote), cancellationToken);
                }

                // notifier 
                await Mediator.Publish(new VoteSubmitEvent(attendee, request.MeetingId, currentUser.User), cancellationToken);

                return Result(true);
            }

            return Error<bool>(Text("attendee.updateAttendeeVote"));
        }

        #endregion
    }
}
