using api.common.Models;
using api.common.Shared;
using api.domain.Commands;
using api.domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Queries;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;

#pragma warning disable 1591

namespace api.Controllers
{
    [ApiController]
    public class MeetingRoleController : BaseController
    {
        public MeetingRoleController(IMediator mediator, IHttpContextAccessor httpContext, ILocalizer localizer, ILogger<BaseController> logger)
            : base(mediator, httpContext, localizer, logger)
        {
            EnsureNotInRole(AccountRole.USER);
        }

        /// <summary>
        /// Get meeting role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await QueryAsync(new GetByIdQuery<MeetingRole>(id));
        }

        /// <summary>
        /// Get all meeting role
        /// </summary>
        /// <param name="isGetAll">True to get all, including deleted</param>
        /// <returns></returns>
        [HttpGet("all/{isGetAll?}")]
        public async Task<IActionResult> GetAll([FromRoute] bool isGetAll = false)
        {
            return await QueryAsync(new GetAllQuery<MeetingRole> { IsGetAll = isGetAll });
        }

        /// <summary>
        /// Get all for a specific meeting type
        /// </summary>
        /// <param name="meetingType"></param>
        /// <param name="isGetAll"></param>
        /// <returns></returns>
        [HttpGet("{meetingType}/{isGetAll?}")]
        public async Task<IActionResult> GetByType([FromRoute] MeetingType meetingType, [FromRoute] bool isGetAll = false)
        {
            return await QueryAsync(new GetAllQuery<MeetingRole>(meetingType) { IsGetAll = isGetAll });
        }

        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IActionResult> Post([FromBody] MeetingRoleCreateCommand meeting)
        {
            return CommandAsync(meeting);
        }

        /// <summary>
        /// Update a role
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        [HttpPut]
        public Task<IActionResult> Put([FromBody] MeetingRoleUpdateCommand meeting)
        {
            return CommandAsync(meeting);
        }

        /// <summary>
        /// Lock the role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isBlock"></param>
        /// <returns></returns>
        [HttpPatch("{id}/lock/{isBlock}")]
        public async Task<IActionResult> Block([FromRoute]string id, [FromRoute] bool isBlock)
        {
            var patchBlock = new UpdateFieldByIdCommand<MeetingRole>(id, x => x.DisabledDate, isBlock ? new Occurrence() : null);
            return await CommandAsync(patchBlock);
        }

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            return await CommandAsync(new DeleteByIdCommand<MeetingRole>(id, true));
        }
    }
}