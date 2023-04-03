using api.common.Models;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using api.domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Queries;

namespace api.Controllers
{
    /// <inheritdoc />
    public class MeetingController : BaseController
    {
        private readonly ICurrentUser currentUser;
        private readonly ILookupNormalizer normalizer;

        /// <inheritdoc />
        public MeetingController(IMediator mediator, ICurrentUser currentUser,
            ILocalizer localizer, IHttpContextAccessor httpAccessor,
            ILookupNormalizer normalizer, ILogger<BaseController> logger)
            : base(mediator, httpAccessor, localizer, logger)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
        }

        /// <summary>
        /// Get all meeting for login user
        /// </summary>
        /// <param name="isAll">True to include deleted one</param>
        /// <returns></returns>
        [HttpGet("all/{isAll}")]
        public async Task<IActionResult> GetAll([FromRoute] bool isAll = false)
        {
            return await QueryAsync(new GetAllQuery<Meeting> { IsGetAll = isAll });
        }

        /// <summary>
        /// Create new meeting
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IActionResult> Post([FromBody] MeetingCreateCommand meeting)
        {
            return CommandAsync(meeting);
        }

        /// <summary>
        /// Update meeting
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        [HttpPut]
        public Task<IActionResult> Put([FromBody] MeetingUpdateCommand meeting)
        {
            return CommandAsync(meeting);
        }

        /// <summary>
        /// Delete meeting
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute] string id)
        {
            EnsureMeetingAccessible(id);

            return CommandAsync(new DeleteByIdCommand<MeetingLite>(id));
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<IActionResult> Get([FromRoute] string id)
        {
            EnsureMeetingAccessible(id);

            return QueryAsync(new GetByIdQuery<Meeting>(id));
        }

        /// <summary>
        /// Set stats of a meeting. Ex: Started -> Lock -> Open -> Close
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPatch("{id}/state/{status}")]
        public async Task<IActionResult> StartMeeting([FromRoute] string id, [FromRoute] MeetingStatus status)
        {
            EnsureMeetingAccessible(id);

            return await CommandAsync(new MeetingStatusChangedCommand(id, status));
        }


        // Meeting Info

        /// <summary>
        /// Update meeting info to meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/info")]
        public Task<IActionResult> MeetingContent([FromRoute] string meetingId, [FromBody] MeetingInfo info)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new MeetingUpdateContentCommand<MeetingInfo>(meetingId, info));
        }

        /// <summary>
        /// Update meeting info with flag to update meeting election matter
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/info-with-election")]
        public async Task<IActionResult> MeetingContentWithElection([FromRoute] string meetingId, [FromBody] MeetingInfo info)
        {
            EnsureMeetingAccessible(meetingId);

            var meetingInfo = await Mediator.Send(new MeetingUpdateContentCommand<MeetingInfo>(meetingId, info));
            if (meetingInfo.Succeeded)
            {
                var matter = new ElectionMatter
                {
                    Name = info.Name,
                    Description = info.Description,
                    Attachments = info.Attachments
                };
                var election = await Mediator.Send(new MeetingUpdateContentCommand<ElectionMatter>(meetingId, matter));
                return Value(new[] { meetingInfo.Value, election.Value });
            }

            return Ok(meetingInfo);
        }

        /// <summary>
        /// Delete a meeting info
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/info/{id}")]
        public Task<IActionResult> MeetingContent([FromRoute] string meetingId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, MeetingInfo>(meetingId, id));
        }

        // media delete

        /// <summary>
        /// Delete a attachment for specific meeting info
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="contentId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/info/{contentId}/attachment/{id}")]
        public Task<IActionResult> MeetingContent([FromRoute] string meetingId, [FromRoute] string contentId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, MeetingInfo, MediaResource>(meetingId, contentId, id));
        }

        // Election matters

        /// <summary>
        /// Update election matter to meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/election-matter")]
        public Task<IActionResult> MeetingElectionMatter([FromRoute] string meetingId, [FromBody] ElectionMatter info)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new MeetingUpdateContentCommand<ElectionMatter>(meetingId, info));
        }

        /// <summary>
        /// Delete a election matter from meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/election-matter/{id}")]
        public Task<IActionResult> MeetingElectionMatter([FromRoute] string meetingId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, ElectionMatter>(meetingId, id));
        }

        /// <summary>
        /// Reorder the election matter
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="matterId"></param>
        /// <param name="newIndex"></param>
        /// <returns></returns>
        [HttpPatch("{meetingId}/election-matter/{matterId}/index/{newIndex}")]
        public Task<IActionResult> MeetingElectionMatter([FromRoute] string meetingId, [FromRoute] string matterId, [FromRoute] int newIndex)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new MeetingElectionMatterIndexedCommand(meetingId, matterId, newIndex));
        }

        // media delete

        /// <summary>
        /// Delete an attachment from election matter
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="matterId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/election-matter/{matterId}/attachment/{id}")]
        public Task<IActionResult> MeetingElectionMatterMedia([FromRoute] string meetingId, [FromRoute] string matterId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, ElectionMatter, MediaResource>(meetingId, matterId, id));
        }

        /// <summary>
        /// Delete an option from election matter
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="matterId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/election-matter/{matterId}/option/{id}")]
        public Task<IActionResult> MeetingElectionMatterOption([FromRoute] string meetingId, [FromRoute] string matterId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, ElectionMatter, ElectionOption>(meetingId, matterId, id));
        }

        // holders & delegate

        /// <summary>
        /// Get a holder from meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/holder/{id}")]
        public Task<IActionResult> GetHolder([FromRoute] string meetingId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new GetByIdFromSubSetQuery<Meeting, Holder>(meetingId, id));
        }

        /// <summary>
        /// Get all holder for a meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/current-holder")]
        public Task<IActionResult> GetCurrentHolder([FromRoute] string meetingId)
        {
            EnsureMeetingAccessible(meetingId);

            // let subId is empty to flag the query getting the Holder by current logged in user id
            return CommandAsync(new GetByIdFromSubSetQuery<Meeting, Holder>(meetingId, string.Empty));
        }

        /// <summary>
        /// Get or Search holder from meeting with paging
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/holder/{size}/{index}")]
        public async Task<IActionResult> GetAllHolder([FromRoute] string meetingId, [FromRoute] int size = 10, [FromRoute] int index = 0, [FromQuery] string searchText = default)
        {
            EnsureMeetingAccessible(meetingId);

            return await CommandAsync(new SearchQuery<Meeting, Holder>(meetingId, searchText, size, index));
        }

        /// <summary>
        /// Upload a file with all holders for a meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="fileResource"></param>
        /// <returns></returns>
        [HttpPost("{meetingId}/holder")]
        public Task<IActionResult> UploadHolders([FromRoute] string meetingId, [FromBody] MediaResource fileResource)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new MeetingHolderUploadCommand(meetingId, fileResource));
        }

        /// <summary>
        /// Update a holder for meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="holder"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/holder")]
        public Task<IActionResult> InsertOrUpdateHolder([FromRoute] string meetingId, [FromBody] Holder holder)
        {
            EnsureMeetingAccessible(meetingId);

            holder.NormalizedEmail = normalizer.NormalizeEmail(holder.Email);
            holder.NormalizeIdentityNumber = normalizer.NormalizeName(holder.IdentityNumber);

            return CommandAsync(new MeetingUpdateContentCommand<Holder>(meetingId, holder));
        }

        /// <summary>
        /// Delete a holder from meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/holder/{id}")]
        public Task<IActionResult> DeleteHolder([FromRoute] string meetingId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, Holder>(meetingId, id));
        }

        /// <summary>
        /// Admin set holder confirm status to attend a meeting (perhaps confirm via telephone)
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="holderId"></param>
        /// <param name="isConfirmed"></param>
        /// <returns></returns>
        [HttpPatch("{meetingId}/holder/{holderId}/attend/{isConfirmed}")]
        public Task<IActionResult> HolderConfirmAttend([FromRoute] string meetingId, [FromRoute] string holderId, [FromRoute] bool isConfirmed)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new MeetingAttendConfirmCommand(meetingId, holderId, isConfirmed));
        }

        /// <summary>
        /// User is a attend confirm to check out online
        /// </summary>
        /// <param name="meetingId"></param> 
        /// <returns></returns>
        /// attachments : This is option to face 2, allow attachments when admin setting required attachment when check-in online .
        /// 
        [HttpPatch("{meetingId}/check-out")]
        public Task<IActionResult> HolderCheckOut([FromRoute] string meetingId) // /*, [FromBody] IEnumerable<MediaResource> attachments = null*/)
        {
            EnsureMeetingAccessible(meetingId);
            return CommandAsync(new MeetingAttendeeCheckOutCommand(meetingId));
        }

        /// <summary>
        /// User is a holder confirm to check in online
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        /// attachments : This is option to face 2, allow attachments when admin setting required attachment when check-in online .
        /// 
        [HttpPatch("{meetingId}/check-in")]
        public Task<IActionResult> HolderCheckIn([FromRoute] string meetingId) // /*, [FromBody] IEnumerable<MediaResource> attachments = null*/)
        {
            EnsureMeetingAccessible(meetingId);
            return CommandAsync(new MeetingAttendeeCheckInCommand(meetingId));
        }
        // attendee

        /// <summary>
        /// Get/Search attendee for a meeting with paging
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/attendee/{size}/{index}")]
        public Task<IActionResult> GetAllAttendee([FromRoute] string meetingId, [FromRoute] int size = 10, [FromRoute] int index = 0, [FromQuery] string searchText = default)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new SearchQuery<Meeting, Attendee>(meetingId, searchText, size, index));
        }

        /// <summary>
        /// Get attendee who is selected as delegation
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/attendee-delegated")]
        public Task<IActionResult> GetAttendeeDelegated([FromRoute] string meetingId)
        {
            EnsureMeetingAccessible(meetingId);
            return CommandAsync(new MeetingAttendeeDelegatedQuery(meetingId));
        }

        /// <summary>
        /// Update an attendee for meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="attendee"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/attendee")]
        public Task<IActionResult> InsertOrUpdateAttendee([FromRoute] string meetingId, [FromBody] Attendee attendee)
        {
            EnsureMeetingAccessible(meetingId);

            var delegatedVotes = attendee.Mandators?.Sum(x => x.Votes) ?? 0;
            if (delegatedVotes != attendee.SharedVotes)
                return ErrorAsync("attendee.delegatedVotesInvalid");

            return CommandAsync(new MeetingUpdateContentCommand<Attendee>(meetingId, attendee));
        }

        /// <summary>
        /// Delete an attendee
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{meetingId}/attendee/{id}")]
        public Task<IActionResult> DeleteAttendee([FromRoute] string meetingId, [FromRoute] string id)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new DeleteByIdCommand<Meeting, Attendee>(meetingId, id));
        }

        /// <summary>
        /// Admin update vote result for a election matter
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="attendeeId"></param>
        /// <param name="votes"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/attendee/{attendeeId}/vote")]
        public Task<IActionResult> SubmitVotes([FromRoute] string meetingId, [FromRoute] string attendeeId, [FromBody] IEnumerable<ElectionVote> votes)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new AttendeeMeetingElectionVoteCommand(meetingId, attendeeId, votes.ToList(), isForceUpdated: true));
        }

        /// <summary>
        /// Get attendee info for current user if any
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/current-attendee")]
        public Task<IActionResult> CurrentAttendee([FromRoute] string meetingId)
        {
            EnsureMeetingAccessible(meetingId);
            // let subId is empty to flag the query getting the Holder by current logged in user id
            return CommandAsync(new GetByIdFromSubSetQuery<Meeting, Attendee>(meetingId, string.Empty));
        }

        /// <summary>
        /// Print all file for attendee check-in offline : confirm, card, election, master
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="attendeeId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/checkin-reports/{attendeeId}")]
        public Task<IActionResult> AttendeeOffLinePrint([FromRoute] string meetingId, [FromRoute] string attendeeId)
        {
            EnsureMeetingAccessible(meetingId);
            // let subId is empty to flag the query getting the Holder by current logged in user id
            return CommandAsync(new AttendeeMeetingCheckInReportCommand(meetingId, attendeeId));
        }

        /// <summary>
        /// Attendee submit a vote online
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="votes"></param>
        /// <returns></returns>
        [HttpPut("{meetingId}/vote")]
        public Task<IActionResult> AttendeeSubmitVotes([FromRoute] string meetingId, [FromBody] IEnumerable<ElectionVote> votes)
        {
            EnsureMeetingAccessible(meetingId);

            return CommandAsync(new AttendeeMeetingElectionVoteCommand(meetingId, string.Empty, votes.ToList()));
        }

        private void EnsureMeetingAccessible(string meetingId)
        {
            if (IsInRole(AccountRole.MODERATOR, AccountRole.ADMIN))
                return;

            if (!currentUser.CanAccessToMeeting(meetingId))
                throw new AccessViolationException(Text("meeting.accessLimit"));
        }

    }
}
