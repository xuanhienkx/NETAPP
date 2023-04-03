using api.common.Models;
using api.common.Shared;
using api.common.Shared.Interfaces;
using api.domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.common.Shared.Base;

#pragma warning disable 1591

namespace api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : BaseController
    {
        private readonly IHubContext<ApplicationStateHub> hubContext;
        private readonly IPersistentDataProvider dataProvider;
        private readonly ICurrentUser currentUser;

        public AuthenticationController(
            IMediator mediator, IHubContext<ApplicationStateHub> hubContext, IHttpContextAccessor httpContext,
            ILocalizer localizer,
            IPersistentDataProvider dataProvider, ICurrentUser currentUser, ILogger<BaseController> logger)
            : base(mediator, httpContext, localizer, logger)
        {
            this.hubContext = hubContext ?? throw new System.ArgumentNullException(nameof(hubContext));
            this.dataProvider = dataProvider ?? throw new System.ArgumentNullException(nameof(dataProvider));
            this.currentUser = currentUser ?? throw new System.ArgumentNullException(nameof(currentUser));
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public Task<IActionResult> SignUp([FromBody] AccountRegisterCommand registerAccount)
        {
            return CommandAsync(registerAccount);
        }

        [AllowAnonymous]
        [HttpGet("reset-passcode/{userId}")]
        public Task<IActionResult> ResetCode([FromRoute] string userId)
        {
            return CommandAsync(new IdentityRequestCommand(IdentityRequestType.RESET_LOGINCODE) { IdentityID = userId });
        }

        [AllowAnonymous]
        [HttpPut("verify")]
        public Task<IActionResult> Verify([FromBody] AccountVerifyCommand verifyAccount)
        {
            return CommandAsync(verifyAccount);
        }

        [AllowAnonymous]
        [HttpPut("reset-password")]
        public Task<IActionResult> ResetPassword([FromBody] AccountResetPasswordCommand resetPassword)
        {
            return CommandAsync(resetPassword);
        }

        [HttpPut("change-password")]
        public Task<IActionResult> Verify([FromBody] AccountChangePasswordCommand resetPassword)
        {
            return CommandAsync(resetPassword);
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public Task<IActionResult> SignIn([FromBody] AccountAuthenticateCommand authentication)
        {
            return CommandAsync(authentication);
        }

        [AllowAnonymous]
        [HttpPost("oauth-sign-in")]
        public Task<IActionResult> OAuthSignIn([FromBody] OAuthAuthenticationCommand authentication)
        {
            return CommandAsync(authentication);
        }

        [HttpDelete("sign-out")]
        public Task<IActionResult> SignOut()
        {
            return CommandAsync(new IdentityRequestCommand(IdentityRequestType.LOGOUT));
        }

        [HttpGet("ping/{connectionId}")]
        public async Task<IActionResult> Ping(string connectionId)
        {
            Logger.LogInformation("Ping reach here");

            // from now on, do 2 stuffs: 1) check login status; 2) check permission reset
            var connection = HttpContext.Connection;

            await hubContext.Clients.Client(connectionId).SendAsync("ping", $"Send to client: {connectionId}");


            //var loginTimestamp = memoryCache.TryGetValue<long>(HttpContext.User.Claims)
            return Ok(new
            {
                lang = Thread.CurrentThread.CurrentCulture.DisplayName,
                localization = Text("Test"),
                isModerator = await currentUser.IsInRole(AccountRole.MODERATOR),
                isAdmin = await currentUser.IsInRole(AccountRole.ADMIN),
                userClaims = HttpContext.User.Claims.Select(x => new { type = x.Type, value = x.Value }),
                connectionAddress = $"{connection.LocalIpAddress}:{connection.RemoteIpAddress.MapToIPv4()}",
                message = dataProvider.Get<Message>(HttpContext.User.Claims.First(x => x.Type == JwtTokenIssuer.UserIdClaimType).Value),
                userAgent = HttpContext.Request.Headers["User-Agent"].ToString(),
                identityUser = currentUser.User
            });
        }
    }
}