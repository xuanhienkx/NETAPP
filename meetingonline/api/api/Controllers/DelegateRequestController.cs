using api.common.Models;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Queries;

namespace api.Controllers
{
    /// <inheritdoc />
    public class DelegateRequestController : BaseController
    {
        private readonly ICurrentUser currentUser;
        private readonly ILookupNormalizer normalizer;

        /// <inheritdoc />
        public DelegateRequestController(IMediator mediator, ICurrentUser currentUser, ILookupNormalizer normalizer, 
            IHttpContextAccessor httpAccessor, ILocalizer localizer, ILogger<BaseController> logger)
            : base(mediator, httpAccessor, localizer, logger)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            this.normalizer = normalizer ?? throw new ArgumentNullException(nameof(normalizer));
        }

        /// <summary>
        /// User submit to get approval of all his requested delegations for a specific meeting
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] DelegateRequestUpdateCommand request)
        {
            if (!request.Mandator.NormalizeIdentityNumber.Equals(currentUser.User.NormalizeIdentityNumber))
                return Ok(Result.Error(Text("delegationRequest.invalidMandator")));

            request.Delegation.NormalizedEmail = normalizer.NormalizeEmail(request.Delegation.Email);
            request.Delegation.NormalizeIdentityNumber = normalizer.NormalizeName(request.Delegation.IdentityNumber);

            return await CommandAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] string id)
        {
            return await CommandAsync(new DeleteByIdCommand<DelegateRequest>(id));
        }

        [HttpPatch("{id}/submit")]
        public async Task<IActionResult> SubmitRequest([FromRoute] string id)
        {
            return await CommandAsync(new DelegateRequestCommand(id));
        }

        /// <summary>
        /// Admin submit list of request approval/reject
        /// </summary>
        [HttpPatch("admin-response")]
        public Task<IActionResult> RequestDelegate([FromBody] DelegateRequestResponseCommand requestResponse)
        {
            return CommandAsync(requestResponse);
        }

        /// <summary>
        /// Get all delegations for a meeting for administrator who review before doing approve or reject the request
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="size"></param>
        /// <param name="index"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/admin/{index}/{size}")]
        public Task<IActionResult> GetAllDelegate([FromRoute] string meetingId, [FromRoute] int size, [FromRoute] int index, [FromQuery] string searchText)
        {
            return CommandAsync(new SearchQuery<DelegateRequest, DelegateRequestGroup>(meetingId, searchText, size, index));
        }

        /// <summary>
        /// Get delegation for a mandator when checkin
        /// </summary>
        /// <param name="meetingId"></param>
        /// <param name="delegationId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/mandator/{delegationId}")]
        public Task<IActionResult> RequestDelegate([FromRoute] string meetingId, [FromRoute] string delegationId)
        {
            return CommandAsync(new GetAllByExpressionQuery<DelegateRequest>(x => x.MeetingId.Equals(meetingId) && x.Delegation.Id.Equals(delegationId) && x.Delegation.ApprovedDate != null));
        }

        /// <summary>
        /// Get all delegation request for current login user where user is mandator or delegation
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        [HttpGet("{meetingId}/current-user")]
        public async Task<IActionResult> CurrentDelegate([FromRoute] string meetingId)
        {
            var currentIdentity = currentUser.User.IdentityNumber;
            if (string.IsNullOrEmpty(currentIdentity))
                return Ok(Result.Error(Text("delegationRequest.invalidCurrentUser")));

            currentIdentity = normalizer.NormalizeName(currentIdentity);
            return await CommandAsync(new GetAllByExpressionQuery<DelegateRequest>(
                x => x.MeetingId.Equals(meetingId) &&
                     (x.Delegation.NormalizeIdentityNumber.Equals(currentIdentity) ||
                      x.Mandator.NormalizeIdentityNumber.Equals(currentIdentity))
            ));
        }
    }
}