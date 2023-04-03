using api.common.Events;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
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
    public class HolderHandler : MeetingHandlerBase,
        IRequestHandler<MeetingHolderUploadCommand, Result<MeetingSummary>>,
        IRequestHandler<GetByIdFromSubSetQuery<Meeting, Holder>, Result<Holder>>,
        // event
        INotificationHandler<MeetingMapHolderToIdentityUserEvent>,
        // holder
        IRequestHandler<MeetingUpdateContentCommand<Holder>, Result<Holder>>,
        IRequestHandler<DeleteByIdCommand<Meeting, Holder>, Result<bool>>,
        IRequestHandler<SearchQuery<Meeting, Holder>, Result<List<Holder>>>,
        IRequestHandler<UpdateByIdCommand<Meeting, Holder>, Result<bool>>,
        IRequestHandler<MeetingAttendConfirmCommand, Result<Holder>>,
        // delegation
        IRequestHandler<MeetingDelegationRequestCommand<Holder>, Result<bool>>
    {
        private readonly ILoadDataService loadDataService;
        private readonly ILookupNormalizer normalizer;
        private readonly IContentProviderService contentProvider;
        private readonly ICurrentUser currentUser;
        private readonly IWebSocketService wsService;
        private readonly ILogger<HolderHandler> logger;

        public HolderHandler(IMediator mediator,
            ILoadDataService loadDataService,
            IPersistentService<DomainPersistentService> persistentService,
            ILookupNormalizer normalizer,
            IContentProviderService contentProvider,
            ICurrentUser currentUser,
            ILocalizer localizer,
            IWebSocketService wsService,
            ILogger<HolderHandler> logger
            ) : base(mediator, persistentService, localizer)
        {
            this.loadDataService = loadDataService ?? throw new ArgumentNullException(nameof(loadDataService));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
            this.contentProvider = contentProvider ?? throw new ArgumentNullException(nameof(contentProvider));
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.wsService = wsService ?? throw new ArgumentNullException(nameof(wsService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<MeetingSummary>> Handle(MeetingHolderUploadCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var holderCommands = loadDataService.ReadFromFile<MeetingHolderCreateCommand>(request.Media);

            var holders = holderCommands.Select(c =>
            {
                var holder = new Holder(ObjectId.GenerateNewId().ToString())
                {
                    Address = c.Address,
                    DisplayName = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    IdentityIssuedDate = c.IdentityDate,
                    IdentityIssuer = c.IdentityIssuer,
                    IdentityNumber = c.IdentityNumber,
                    IdentityType = c.IdentityType,
                    Nationality = c.Nationality,
                    Shares = c.Shares,
                    OwnedVotes = c.VoteRights,
                    AvailableVotes = c.VoteRights,
                    NormalizeIdentityNumber = normalizer.NormalizeName(c.IdentityNumber),
                    NormalizedEmail = normalizer.NormalizeEmail(c.Email)
                };
                return holder;
            }).ToList();

            var summary = new MeetingSummary
            {
                Holders = holders.Count,
                Shares = holders.Sum(x => x.Shares),
                Votes = holders.Sum(x => x.OwnedVotes)
            };
            var command = new UpdateManyByIdCommand<Meeting>(request.MeetingId)
                .With(x => x.Holders, holders)
                .With(x => x.HolderUploadFile, request.Media)
                .With(x => x.Summary, summary);

            var rs = await Mediator.Send(command, cancellationToken);
            if (rs.Succeeded)
                return Result(summary);

            return Error<MeetingSummary>(rs.Errors);
        }

        public async Task Handle(MeetingMapHolderToIdentityUserEvent request, CancellationToken cancellationToken)
        {
            cancellationToken = new CancellationToken();

            var holders = await PersistentService.GetCollection<Meeting>()
                .Find(x => x.Id.Equals(request.Meeting.Id))
                .Project(x => x.Holders)
                .ToListAsync(cancellationToken);


            var i = 0;
            var e = 0;
            foreach (var holder in holders.SelectMany(x => x))
            {
                logger.LogDebug(">>> {index} Process for [{id} - {userid}] {name} - [{email}]", ++i, holder.Id, holder.IdentityUserId, holder.DisplayName, holder.Email);

                var filters = new List<FilterDefinition<IdentityUser>>();
                if (holder.Email != null)
                    filters.Add(Builders<IdentityUser>.Filter.Eq(x => x.Email.NormalizedValue, normalizer.NormalizeEmail(holder.Email)));
                if (!string.IsNullOrEmpty(holder.IdentityNumber))
                    filters.Add(Builders<IdentityUser>.Filter.Eq(x => x.NormalizeIdentityNumber, normalizer.NormalizeName(holder.IdentityNumber)));

                if (filters.Count > 0)
                {
                    //check if any login exists
                    var filter = Builders<IdentityUser>.Filter.Or(filters);

                    var user = await PersistentService.GetCollection<IdentityUser>()
                        .Find(filter).Include(x => x.Id, x => x.Email)
                        .FirstOrDefaultAsync(cancellationToken);

                    string email = null;
                    if (user == null)
                    {
                        if (!string.IsNullOrEmpty(holder.Email))
                        {
                            // create account when holder having email
                            var userResult = await Mediator.Send(new AccountCreateCommand<AccountInfo>
                            {
                                Address = holder.Address,
                                Name = holder.DisplayName,
                                Email = holder.Email,
                                PhoneNumber = holder.PhoneNumber,
                                IdentityDate = holder.IdentityIssuedDate,
                                IdentityIssuer = holder.IdentityIssuer,
                                IdentityNumber = holder.IdentityNumber,
                                IdentityType = holder.IdentityType,
                                Nationality = holder.Nationality
                            }, cancellationToken);

                            if (userResult.Succeeded)
                            {
                                holder.IdentityUserId = userResult.Value.Id;
                                email = holder.Email;
                            }
                            else
                            {
                                logger.LogWarning("Cannot create login for [{id}] {email} - {name}", holder.Id, holder.Email, holder.DisplayName);
                            }
                        }
                    }
                    else
                    {
                        holder.IdentityUserId = user.Id;
                        email = user.Email.Value;
                    }

                    if (!string.IsNullOrEmpty(holder.IdentityUserId))
                    {
                        logger.LogDebug(">>>>>>>> Grant access for [{id}] {name} - email: [{email}]", holder.Id, holder.DisplayName, email);

                        // update Id for holder
                        await Mediator.Send(new UpdateByIdCommand<Meeting, Holder>(
                                request.Meeting.Id, holder.Id,
                                x => x.Holders, x => x.Holders[-1].IdentityUserId, holder.IdentityUserId),
                            cancellationToken);

                        // grant access to holder
                        await Mediator.Send(new MeetingAccessActionCommand(request.Meeting.Id, holder.IdentityUserId, isViewer: true, isGrantAccessRequest: true), cancellationToken);
                    }

                    // send email to inform
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email))
                    {
                        logger.LogDebug(">>>>>> {index} Send email to {email}", ++e, email);

                        var emailContent = contentProvider.GenerateEmailForMeetingHolder(request.Meeting, holder);
                        await Mediator.Publish(new SendEmailEvent(email, holder.DisplayName, emailContent), cancellationToken);
                    }
                }
            }

            logger.LogDebug("Finished, send {email} email to users", e);

            // change status of meeting from Locking to Lock
            await Update(request.Meeting.Id, o => o.Set(x => x.Status, MeetingStatus.Lock), cancellationToken);

            // send notifier
            await wsService.SendHangfire(request.UserId, request.HfId, Text("holder.locklist.completed", i, e));
        }

        public Task<Result<Holder>> Handle(GetByIdFromSubSetQuery<Meeting, Holder> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // get by identityClient
            if (string.IsNullOrEmpty(request.SubId))
                return QueryByIdFromSubSet(request.Id, x => x.Holders, h => h.IdentityUserId != null && h.IdentityUserId == currentUser.UserId, cancellationToken: cancellationToken);

            return QueryByIdFromSubSet(request.Id, x => x.Holders, h => h.Id.Equals(request.SubId), cancellationToken: cancellationToken);
        }

        public async Task<Result<Holder>> Handle(MeetingUpdateContentCommand<Holder> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var onUpdate = new Action<Holder>(async old =>
            {
                await Update(request.MeetingId,
                    x => x.SetInc(m => m.Summary.Shares, request.Value.Shares - old.Shares)
                        .SetInc(m => m.Summary.Votes, request.Value.OwnedVotes - old.OwnedVotes), cancellationToken);
            });
            var onInsert = new Action(async () =>
            {
                await Update(request.MeetingId,
                    x => x.SetInc(m => m.Summary.Holders)
                        .SetInc(m => m.Summary.Shares, request.Value.Shares)
                        .SetInc(m => m.Summary.Votes, request.Value.OwnedVotes), cancellationToken);
            });

            if (string.IsNullOrEmpty(request.Value.Id))
                request.Value.Id = ObjectId.GenerateNewId().ToString();

            // check if existed in holder list
            var normalizedIdentity = normalizer.NormalizeName(request.Value.IdentityNumber.Trim());
            var normalizedEmail = normalizer.NormalizeEmail(request.Value.Email);
            var existedIdentity = string.IsNullOrEmpty(normalizedEmail)
                ? await Exists(request.MeetingId, x => x.Holders, x => x.Id != request.Value.Id && x.NormalizeIdentityNumber.Equals(normalizedIdentity), cancellationToken)
                : await Exists(request.MeetingId, x => x.Holders, x => x.Id != request.Value.Id && x.NormalizeIdentityNumber.Equals(normalizedIdentity) || (x.NormalizedEmail != null && x.NormalizedEmail.Equals(normalizedEmail)), cancellationToken);
            if (existedIdentity)
                return Error<Holder>(Text("holder.existedIdentityOrEmail"));

            request.Value.NormalizeIdentityNumber = normalizedIdentity;
            request.Value.NormalizedEmail = normalizedEmail;

            var result = await UpdateOneToSubSet(request.MeetingId, h => h.Id.Equals(request.Value.Id), x => x.Holders, o =>
            {
                o.Where(x => x.Status.Equals(MeetingStatus.Started));
                o.OnUpdated = onUpdate;
                o.OnInserted = onInsert;
                o.OnSetupItem = holder =>
                {
                    if (holder == null)
                        return request.Value;

                    // update the holder
                    holder.DisplayName = request.Value.DisplayName;
                    holder.ConfirmedDate = request.Value.ConfirmedDate;
                    holder.Email = request.Value.Email;
                    holder.NormalizedEmail = request.Value.NormalizedEmail;
                    holder.PhoneNumber = request.Value.PhoneNumber;
                    holder.OwnedVotes = request.Value.OwnedVotes;
                    holder.AvailableVotes = request.Value.AvailableVotes;
                    holder.Shares = request.Value.Shares;
                    holder.Address = request.Value.Address;
                    holder.IdentityIssuedDate = request.Value.IdentityIssuedDate;
                    holder.IdentityIssuer = request.Value.IdentityIssuer;
                    holder.IdentityNumber = request.Value.IdentityNumber;
                    holder.IdentityType = request.Value.IdentityType;
                    holder.NormalizeIdentityNumber = request.Value.NormalizeIdentityNumber;
                    holder.Nationality = request.Value.Nationality;
                    return holder;
                };
            }, cancellationToken);

            if (!result.Succeeded)
                result.Errors.Add(Text("meeting.statusNotAllowToPerform"));

            return Result(request.Value);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<Meeting, Holder> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var onDelete = new Action<Holder>(async old =>
            {
                await Update(request.Id,
                    x => x.SetInc(m => m.Summary.Holders, -1)
                        .SetInc(m => m.Summary.Shares, -old.Shares)
                        .SetInc(m => m.Summary.Votes, -old.OwnedVotes), cancellationToken);
            });

            var result = await DeleteFromSubSet(request.Id, request.SubId, x => x.Holders,
                o =>
                {
                    o.Where(x => x.Status, MeetingStatus.Started);
                    o.OnDeleted = onDelete;
                }, cancellationToken);

            if (result.Succeeded && !result.Value)
                result.Errors.Add(Text("meeting.statusNotAllowToPerform"));

            return result;
        }

        public async Task<Result<bool>> Handle(UpdateByIdCommand<Meeting, Holder> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<Meeting>.Filter.And(
                 Builders<Meeting>.Filter.Eq(x => x.Id, request.Id),
                 Builders<Meeting>.Filter.ElemMatch(request.ElementMatch, x => x.Id.Equals(request.SubId)));
            var update = Builders<Meeting>.Update.Set(request.Field, request.Value);
            var result = PersistentService.HasSession
            ? await PersistentService.GetCollection<Meeting>().UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
            : await PersistentService.GetCollection<Meeting>().UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

            return Result(result.ModifiedCount != 0);
        }

        public async Task<Result<bool>> Handle(MeetingDelegationRequestCommand<Holder> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filters = new List<FilterDefinition<Meeting>>
            {
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Open)
            };

            var holder = await PersistentService.GetCollection<Meeting>()
                .Find(Builders<Meeting>.Filter.And(filters))
                .Project(x => x.Holders.FirstOrDefault(h => h.Id.Equals(request.HolderId)))
                .FirstOrDefaultAsync(cancellationToken);

            // only existed in attendee, this person is the man who always receive delegation votes
            if (holder == null)
            {
                if (request.Type == RequestType.Approve)
                {
                    return await Mediator.Send(
                        new MeetingDelegationRequestCommand<Attendee>(request.MeetingId, request.HolderId,
                            RequestType.Approve, request.Delegation),
                        cancellationToken);
                }

                return Error<bool>(Text("holder.delegationUpdateFailed"));
            }

            UpdateDefinition<Meeting> update = null;
            switch (request.Type)
            {
                case RequestType.Create:
                    if (holder.CheckedInDate == null && holder.AvailableVotes >= request.Delegation.Votes)
                    {
                        update = Builders<Meeting>.Update
                            .Inc(x => x.Holders[-1].DelegatingVotes, request.Delegation.Votes)
                            .Inc(x => x.Holders[-1].AvailableVotes, -request.Delegation.Votes);
                    }

                    break;
                case RequestType.Submit:
                    if (holder.CheckedInDate == null)
                    {
                        update = Builders<Meeting>.Update
                            .Inc(x => x.Holders[-1].BlockedVotes, request.Delegation.Votes)
                            .Inc(x => x.Holders[-1].DelegatingVotes, -request.Delegation.Votes);
                    }

                    break;
                case RequestType.Approve:
                    if (holder.CheckedInDate == null)
                    {
                        if (!request.IsOnline)
                        {
                            update = Builders<Meeting>.Update 
                                .Inc(x => x.Holders[-1].BlockedVotes, request.Delegation.Votes)
                                .Inc(x => x.Holders[-1].AvailableVotes, -request.Delegation.Votes);
                        }
                        else
                        {
                            update = Builders<Meeting>.Update.Inc(x => x.Holders[-1].DelegatedVotes, request.Delegation.Votes);
                        }
                    }

                    break;
                case RequestType.Reject:
                    update = Builders<Meeting>.Update
                        .Inc(x => x.Holders[-1].BlockedVotes, -request.Delegation.Votes)
                        .Inc(x => x.Holders[-1].DelegatingVotes, request.Delegation.Votes);
                    break;
                case RequestType.Delete:
                    if (holder.CheckedInDate == null)
                    {
                        if (request.Delegation.ApprovedDate != null)
                        {
                            update = Builders<Meeting>.Update
                                .Inc(x => x.Holders[-1].BlockedVotes, -request.Delegation.Votes)
                                .Inc(x => x.Holders[-1].AvailableVotes, request.Delegation.Votes);
                        }
                        else
                        {
                            update = Builders<Meeting>.Update
                                .Inc(x => x.Holders[-1].DelegatingVotes, -request.Delegation.Votes)
                                .Inc(x => x.Holders[-1].AvailableVotes, request.Delegation.Votes);
                        }
                        

                    }
                    break;
                //case RequestType.CheckIn:
                //    update = Builders<Meeting>.Update
                //        .Inc(x => x.Holders[-1].AvailableVotes, 0);
                //    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (update != null)
            {
                filters.Add(Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(request.HolderId)));
                var filter = Builders<Meeting>.Filter.And(filters);
                var result = PersistentService.HasSession
                    ? await PersistentService.GetCollection<Meeting>().UpdateOneAsync(PersistentService.Session, filter,
                        update, cancellationToken: cancellationToken)
                    : await PersistentService.GetCollection<Meeting>()
                        .UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

                return Result(result.ModifiedCount != 0 || result.MatchedCount != 0);
            }

            return Error<bool>(Text("holder.delegationUpdateFailed"));
        }

        public async Task<Result<List<Holder>>> Handle(SearchQuery<Meeting, Holder> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var projection = string.IsNullOrEmpty(request.Text)
                ? Builders<Meeting>.Projection.Expression(x => x.Holders.Skip(request.Skip).Take(request.Size))
                : Builders<Meeting>.Projection.Expression(x =>
                    x.Holders.Where(a =>
                            a.NormalizeIdentityNumber.Contains(request.Text, StringComparison.OrdinalIgnoreCase) ||
                            a.DisplayName.StartsWith(request.Text, StringComparison.OrdinalIgnoreCase))
                        .Skip(request.Skip).Take(request.Size));

            return await QuerySubSet(request.Id, projection, cancellationToken: cancellationToken);
        }

        public async Task<Result<Holder>> Handle(MeetingAttendConfirmCommand request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var holderFilter = request.IsForUserCheckIn
                ? new ExpressionFilterDefinition<Holder>(x =>
                    x.IdentityUserId != null && x.IdentityUserId == request.HolderId)
                : new ExpressionFilterDefinition<Holder>(x => x.Id.Equals(request.HolderId) && x.CheckedInDate == null);

            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, request.MeetingId),
                Builders<Meeting>.Filter.ElemMatch(x => x.Holders, holderFilter));

            var collection = PersistentService.GetCollection<Meeting>();

            var holder = await collection.Find(filter)
                .Project(x => x.Holders.FirstOrDefault(h => holderFilter.Expression.Compile().Invoke(h)))
                .SingleOrDefaultAsync(cancellationToken);

            if (holder == null)
                return Error<Holder>(Text("holder.notFindMeetingOrHolderOrHolderConfirmedOnline"));

            if (request.IsConfirmed && holder.ConfirmedDate != null)
                return Error<Holder>(Text("holder.alreadyConfirmed"));
            if (!request.IsConfirmed && holder.ConfirmedDate == null)
                return Error<Holder>(Text("holder.notConfirmed"));

            var options = new FindOneAndUpdateOptions<Meeting, Holder>
            {
                Projection = Builders<Meeting>.Projection
                    .Expression(x => x.Holders.FirstOrDefault(h => holderFilter.Expression.Compile().Invoke(h))),
                ReturnDocument = ReturnDocument.After
            };

            var attendVotes = request.IsConfirmed
                ? holder.OwnedVotes + holder.DelegatedVotes - holder.BlockedVotes
                : holder.DelegatedVotes + holder.BlockedVotes;

            var update = Builders<Meeting>.Update.Combine(
                Builders<Meeting>.Update.Set(x => x.Holders[-1].ConfirmedDate,
                    request.IsConfirmed ? new Occurrence() : null),
                Builders<Meeting>.Update.Inc(x => x.Summary.AttendConfirmed, request.IsConfirmed ? 1 : -1),
                Builders<Meeting>.Update.Inc(x => x.Summary.ConfirmedVotes,
                    request.IsConfirmed ? attendVotes : -attendVotes));
            var result = PersistentService.HasSession
                ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, options, cancellationToken)
                : await collection.FindOneAndUpdateAsync(filter, update, options, cancellationToken);
            return Result(result);
        }

    }
}