using api.common.Events;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Events;
using api.domain.Queries;
using api.domain.Services;
using AutoMapper;
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

namespace api.domain.Handlers
{
    public class DelegateRequestHandler : PersistentHandler<DelegateRequest, DomainPersistentService>,
        IRequestHandler<DelegateRequestUpdateCommand, Result<DelegateRequest>>,
        IRequestHandler<DelegateRequestCommand, Result<DelegateRequest>>,
        IRequestHandler<DelegateRequestResponseCommand, Result<DelegateRequest>>,
        IRequestHandler<DeleteByIdCommand<DelegateRequest>, Result<bool>>,
        // get & search
        IRequestHandler<GetAllByExpressionQuery<DelegateRequest>, Result<List<DelegateRequest>>>,
        IRequestHandler<SearchQuery<DelegateRequest, DelegateRequestGroup>, Result<List<DelegateRequestGroup>>>,
        // events
        INotificationHandler<DelegateRequestEvent>
    {
        private readonly IContentProviderService contentProvider;
        private readonly ILookupNormalizer normalizer;
        private readonly IMapper mapper;
        private readonly ICurrentUser currentUser;

        public DelegateRequestHandler(
            IMediator mediator, ILocalizer localizer,
            IPersistentService<DomainPersistentService> persistentService,
            IContentProviderService contentProvider,
            ILookupNormalizer normalizer,
            IMapper mapper, ICurrentUser currentUser)
            : base(mediator, persistentService, localizer)
        {
            this.contentProvider = contentProvider ?? throw new ArgumentNullException(nameof(contentProvider));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        protected override ProjectionDefinition<DelegateRequest> ExcludeGetProjection { get; }

        public async Task<Result<DelegateRequest>> Handle(DelegateRequestUpdateCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            request.Mandator.NormalizeIdentityNumber = normalizer.NormalizeName(request.Mandator.IdentityNumber);

            var filter = Builders<DelegateRequest>.Filter.And(
                Builders<DelegateRequest>.Filter.Eq(x => x.MeetingId, request.MeetingId),
                Builders<DelegateRequest>.Filter.Eq(x => x.Delegation.Id, request.Delegation.Id),
                Builders<DelegateRequest>.Filter.Eq(x => x.Mandator.NormalizeIdentityNumber, request.Mandator.NormalizeIdentityNumber)
                );

            var update = Builders<DelegateRequest>.Update
                .Set(x => x.Delegation.Votes, request.Delegation.Votes)
                .Set(x => x.Delegation.Attachments, request.Delegation.Attachments)
                .Set(x => x.Mandator.IdentityIssuedDate, request.Mandator.IdentityIssuedDate)
                .Set(x => x.Mandator.IdentityType, request.Mandator.IdentityType)
                .Set(x => x.Mandator.IdentityIssuer, request.Mandator.IdentityIssuer)
                .Set(x => x.Mandator.Email, request.Mandator.Email)
                .Set(x => x.Mandator.NormalizedEmail, normalizer.NormalizeEmail(request.Mandator.Email))
                .Set(x => x.Mandator.PhoneNumber, request.Mandator.PhoneNumber)
                .Set(x => x.Mandator.Address, request.Mandator.Address);

            var delegationRequest = PersistentService.HasSession
                ? await Collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await Collection.FindOneAndUpdateAsync(filter, update, cancellationToken: cancellationToken);

            Delegation updateDelegation;
            if (delegationRequest == null)
            {
                delegationRequest = new DelegateRequest
                {
                    MeetingId = request.MeetingId,
                    Mandator = request.Mandator,
                    Delegation = request.Delegation,
                    IsOnline = request.IsOnline
                };

                if (request.Activity != null)
                    delegationRequest.AdminActivities = new List<Activity> { request.Activity };

                // insert
                if (PersistentService.HasSession)
                    await Collection.InsertOneAsync(PersistentService.Session, delegationRequest, cancellationToken: cancellationToken);
                else
                    await Collection.InsertOneAsync(delegationRequest, cancellationToken: cancellationToken);

                updateDelegation = request.Delegation;
            }
            else
            {
                // update holder
                updateDelegation = mapper.Map<Delegation>(delegationRequest.Delegation);
                updateDelegation.Votes = request.Delegation.Votes - delegationRequest.Delegation.Votes;

                request.Delegation.RejectedDate = updateDelegation.RejectedDate;
                request.Delegation.RequestedDate = updateDelegation.RequestedDate;
                request.Delegation.ApprovedDate = updateDelegation.ApprovedDate;
                delegationRequest.Delegation = request.Delegation;
            }
            // update holder
            await Mediator.Send(new MeetingDelegationRequestCommand<Holder>(
                request.MeetingId, request.Mandator.Id,
                request.Delegation.ApprovedDate != null ? RequestType.Approve : RequestType.Create,
                updateDelegation, delegationRequest.IsOnline), cancellationToken);

            return Result(delegationRequest);
        }

        public async Task<Result<bool>> Handle(DeleteByIdCommand<DelegateRequest> request,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<DelegateRequest>.Filter.And(
                Builders<DelegateRequest>.Filter.Eq(x => x.Id, request.Id),
                Builders<DelegateRequest>.Filter.Or(
                    Builders<DelegateRequest>.Filter.Eq(x => x.Delegation.RequestedDate, null),
                    Builders<DelegateRequest>.Filter.Ne(x => x.Delegation.RejectedDate, null)
                ));

            var result = PersistentService.HasSession
                ? await Collection.FindOneAndDeleteAsync(PersistentService.Session, filter, cancellationToken: cancellationToken)
                : await Collection.FindOneAndDeleteAsync(filter, cancellationToken: cancellationToken);

            if (result != null)
            {
                await Mediator.Send(new MeetingDelegationRequestCommand<Holder>(result.MeetingId, result.Mandator.Id, RequestType.Delete, result.Delegation), cancellationToken);
                return Result(true);
            }

            return Error<bool>(Text("delegation.cannotDelete"));
        }

        /// <summary>
        /// Submit request
        /// </summary>
        public async Task<Result<DelegateRequest>> Handle(DelegateRequestCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // check if the mandator is checkin


            var filter = Builders<DelegateRequest>.Filter.And(
                Builders<DelegateRequest>.Filter.Eq(x => x.Id, request.Id),
                Builders<DelegateRequest>.Filter.Or(
                    Builders<DelegateRequest>.Filter.Eq(x => x.Delegation.RequestedDate, null),
                    Builders<DelegateRequest>.Filter.Ne(x => x.Delegation.RejectedDate, null)
                ));
            var update = Builders<DelegateRequest>.Update
                .Set(x => x.Delegation.RequestedDate, new Occurrence())
                .Set(x => x.Delegation.RejectedDate, null);

            var option = new FindOneAndUpdateOptions<DelegateRequest, DelegateRequest> { ReturnDocument = ReturnDocument.After };
            var delegationRequest = PersistentService.HasSession
                ? await Collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
                : await Collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);

            if (delegationRequest != null)
            {
                await Mediator.Send(
                    new MeetingDelegationRequestCommand<Holder>(delegationRequest.MeetingId, delegationRequest.Mandator.Id, RequestType.Submit, delegationRequest.Delegation),
                    cancellationToken);

                return Result(delegationRequest);
            }

            return Error<DelegateRequest>(Text("delegationRequest.cannotSubmit"));
        }


        public async Task<Result<DelegateRequest>> Handle(DelegateRequestResponseCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filters = new List<FilterDefinition<DelegateRequest>>
            {
                Builders<DelegateRequest>.Filter.Eq(x => x.Id, request.Id),
                Builders<DelegateRequest>.Filter.Eq(x => x.Delegation.ApprovedDate, null)
            };

            var option = new FindOneAndUpdateOptions<DelegateRequest, DelegateRequest> { ReturnDocument = ReturnDocument.After };

            // approve
            UpdateDefinition<DelegateRequest> update;
            DelegateRequest delegationRequest;
            FilterDefinition<DelegateRequest> filter;
            if (request.IsApprove)
            {
                filters.Add(
                    Builders<DelegateRequest>.Filter.Or(
                        Builders<DelegateRequest>.Filter.Ne(x => x.Delegation.RequestedDate, null),
                        Builders<DelegateRequest>.Filter.Ne(x => x.Delegation.RejectedDate, null)
                    ));

                filter = Builders<DelegateRequest>.Filter.And(filters);

                update = Builders<DelegateRequest>.Update
                    .AddToSet(x => x.AdminActivities, new Activity(currentUser, request.Message))
                    .Set(x => x.Delegation.ApprovedDate, new Occurrence());

                delegationRequest = PersistentService.HasSession
                    ? await Collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
                    : await Collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);

                if (delegationRequest != null)
                {
                    var mandator = mapper.Map<Delegation>(delegationRequest.Mandator);
                    mandator.Votes = delegationRequest.Delegation.Votes;
                    await Mediator.Send(
                        new MeetingDelegationRequestCommand<Holder>(delegationRequest.MeetingId, delegationRequest.Delegation.Id, RequestType.Approve, mandator),
                        cancellationToken);

                    return Result(delegationRequest);
                }

                return Error<DelegateRequest>(Text("delegationRequest.cannotApprove"));
            }

            // reject
            filters.AddRange(new[]
            {
                Builders<DelegateRequest>.Filter.Ne(x => x.Delegation.RequestedDate, null),
                Builders<DelegateRequest>.Filter.Eq(x => x.Delegation.RejectedDate, null)
            });
            filter = Builders<DelegateRequest>.Filter.And(filters);

            update = Builders<DelegateRequest>.Update
                .AddToSet(x => x.AdminActivities, new Activity(currentUser, request.Message))
                .Set(x => x.Delegation.RejectedDate, new Occurrence());

            delegationRequest = PersistentService.HasSession
                ? await Collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
                : await Collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);

            if (delegationRequest != null)
            {
                await Mediator.Send(
                    new MeetingDelegationRequestCommand<Holder>(delegationRequest.MeetingId, delegationRequest.Mandator.Id, RequestType.Reject, delegationRequest.Delegation),
                    cancellationToken);

                return Result(delegationRequest);
            }

            return Error<DelegateRequest>(Text("delegationRequest.cannotApprove"));
        }

        public async Task Handle(DelegateRequestEvent notification, CancellationToken cancellationToken)
        {
            var collection = PersistentService.GetCollection<Meeting>();

            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, notification.MeetingId),
                Builders<Meeting>.Filter.Eq(x => x.Status, MeetingStatus.Open),
                Builders<Meeting>.Filter.Eq(x => x.DeletedDate, null)
            );
            var meeting = await collection.Find(filter)
                .Project<Meeting, MeetingLite>(x => x.Name, x => x.OpenedDate, x => x.Address, x => x.Type, x => x.Logo, x => x.Status)
                .SingleOrDefaultAsync(cancellationToken);
            if (meeting == null)
                return;

            var holder = await collection.Find(filter)
                .Project(x => x.Holders.FirstOrDefault(h => h.Id.Equals(notification.MandatorId)))
                .SingleOrDefaultAsync(cancellationToken);
            if (holder == null)
                return;

            // get role
            var roles = await Mediator.Send(new MeetingRoleFilterCommand(meeting.Type, MeetingPermission.meeting_delegation_approve), cancellationToken);
            // get user by roles
            var appvover = await Mediator.Send(new GetUsersAccessToMeeting(meeting.Id, isMemberOnly: true, isRoleDetail: false) { Roles = roles.Value }, cancellationToken);
            // send email
            var emailContent = contentProvider.GenerateEmailForApprovalDelegation(meeting, mapper.Map<AccountInfo>(holder));
            await Mediator.Publish(new SendEmailEvent(appvover.Value, emailContent), cancellationToken);
        }

        public async Task<Result<List<DelegateRequest>>> Handle(GetAllByExpressionQuery<DelegateRequest> request, CancellationToken cancellationToken)
        {
            var result = await PersistentService.GetCollection<DelegateRequest>()
                .Find(request.Filter)
                .ToListAsync(cancellationToken);

            return Result(result);
        }

        public async Task<Result<List<DelegateRequestGroup>>> Handle(SearchQuery<DelegateRequest, DelegateRequestGroup> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var searchText = normalizer.NormalizeName(request.Text);
            var result = string.IsNullOrEmpty(searchText)
                ? await PersistentService.GetCollection<DelegateRequest>()
                    .Find(x => x.MeetingId.Equals(request.Id) && ((x.IsOnline && x.Delegation.RequestedDate != null) || !x.IsOnline))
                    .Skip(request.Skip).Limit(request.Size)
                    .ToListAsync(cancellationToken)
                : await PersistentService.GetCollection<DelegateRequest>()
                    .Find(x => x.MeetingId.Equals(request.Id) && ((x.IsOnline && x.Delegation.RequestedDate != null) || !x.IsOnline)
                                                              && (x.Mandator.NormalizeIdentityNumber.StartsWith(searchText)
                                                                  || x.Delegation.NormalizeIdentityNumber.StartsWith(searchText)))
                    .Skip(request.Skip).Limit(request.Size)
                    .ToListAsync(cancellationToken);

            var grouping = result.GroupBy(x => x.Mandator, new IdEqualityComparer<Holder>())
                .Select(x =>
            {
                x.Key.BlockedVotes = x.Where(r => r.Delegation.ApprovedDate != null).Sum(r => r.Delegation.Votes);
                x.Key.AvailableVotes = x.Key.OwnedVotes - x.Key.BlockedVotes;
                return new DelegateRequestGroup(x.Key, x.ToList());
            });
            return Result(grouping.ToList());
        }
    }
}
