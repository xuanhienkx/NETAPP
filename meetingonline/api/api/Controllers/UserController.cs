using System;
using api.common.Models;
using api.domain.Commands;
using api.domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Models.Identity;
using api.common.Queries;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;

#pragma warning disable 1591

namespace api.Controllers
{
    public class UserController : BaseController
    {
        private readonly ICurrentUser currentUser;

        public UserController(IMediator mediator, IHttpContextAccessor httpAccessor, ICurrentUser currentUser,  ILocalizer localizer, ILogger<BaseController> logger) 
            : base(mediator, httpAccessor, localizer, logger)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        /// <summary>
        /// Search user by username or email
        /// </summary>
        /// <param name="userNameOrEmail"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        [HttpGet("search/{userNameOrEmail}/{top?}")]
        public Task<IActionResult> Search([FromRoute] string userNameOrEmail, [FromRoute] int top = 10)
        {
            var searchQuery = new SearchQuery<Account>(userNameOrEmail, top);
            return QueryAsync(searchQuery);
        }

        /// <summary>
        /// Get all the users who can access to a meeting,  including member or viewer
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        [HttpGet("access/{meetingId}/{top?}")]
        public Task<IActionResult> SearchByMeeting([FromRoute] string meetingId, [FromRoute] int top = 0)
        {
            return QueryAsync(new GetUsersAccessToMeeting(meetingId, false, false, top));
        }

        /// <summary>
        /// Get all the member access, who can manage the meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        [HttpGet("member-access/{meetingId}")]
        public Task<IActionResult> GetMeetingMemberAccess([FromRoute] string meetingId)
        {
            return QueryAsync(new GetUsersAccessToMeeting(meetingId, true));
        }

        /// <summary>
        /// User update the language that he wants to 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpPatch("{id}/language/{lang}")]
        public Task<IActionResult> Language([FromRoute] string id, [FromRoute] string lang)
        {
            return CommandAsync(new UpdateByIdCommand<IdentityUser>(id, account => account.Language, lang));
        }

        // Meeting Group

        /// <summary>
        /// User create his meeting group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPut("meeting-group")]
        public Task<IActionResult> MeetingGroup([FromBody] MeetingGroupUpdateCommand group)
        {
            return CommandAsync(group);
        }

        /// <summary>
        /// Delete a meeting group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("meeting-group/{id}")]
        public Task<IActionResult> MeetingGroup([FromRoute]string id)
        {
            return CommandAsync(new DeleteByIdCommand<IdentityUser, MeetingGroup>(null, id));
        }

        // Meeting Access

        /// <summary>
        /// Giving access for user to a meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="userId"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        [HttpPut("{userId}/meeting-access/{meetingId}")]
        public async Task<IActionResult> MeetingAccess([FromRoute]string meetingId, [FromRoute]string userId, [FromBody] MeetingAccessCommand access)
        {
            if (access.MeetingRoles == null || access.MeetingRoles.Count == 0)
                return Ok(Result.Error<bool>(Text("user.roleListRequiredNotEmpty")));

            if (currentUser.UserId == userId)
                return Ok(Result.Error(Text("account.grantAccessToYourself")));

            return await CommandAsync(new MeetingAccessActionCommand(meetingId, userId, isViewer: false, isGrantAccessRequest: true, content: access));
        }

        /// <summary>
        /// Remove access from user to a meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/meeting-access/{meetingId}")]
        public Task<IActionResult> DeleteMeetingAccess([FromRoute]string meetingId, [FromRoute]string userId)
        {
            return CommandAsync(new MeetingAccessActionCommand(meetingId, userId, isViewer: false, isGrantAccessRequest: true, requestFlag: true));
        }

        /// <summary>
        /// Lock the current access for user to meeting
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="userId"></param>
        /// <param name="isLocked"></param>
        /// <returns></returns>
        [HttpPatch("{userId}/meeting-access/{meetingId}/lock/{isLocked}")]
        public Task<IActionResult> BlockMeetingAccess([FromRoute]string meetingId, [FromRoute]string userId, [FromRoute] bool isLocked = true)
        {
            return CommandAsync(new MeetingAccessActionCommand(meetingId, userId, isViewer: false, isGrantAccessRequest: false, requestFlag: isLocked));
        }
    }
}