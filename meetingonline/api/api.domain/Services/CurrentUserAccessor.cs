using api.common.Models;
using api.common.Shared;
using api.common.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain.Services
{
    public class CurrentUserAccessor : ICurrentUser
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IPersistentService<DomainPersistentService> persistentService;
        private readonly ILogger<CurrentUserAccessor> logger;
        private readonly ILocalizer localizer;
        private readonly IHubContext<ApplicationStateHub> hubContext;

        public CurrentUserAccessor(
            IHttpContextAccessor contextAccessor,
            UserManager<IdentityUser> userManager,
            IPersistentService<DomainPersistentService> persistentService,
            ILogger<CurrentUserAccessor> logger,
            ILocalizer localizer,
            IHubContext<ApplicationStateHub> hubContext)
        {
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.persistentService = persistentService ?? throw new ArgumentNullException(nameof(persistentService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public ClaimsIdentity ClaimsIdentity => contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

        public IdentityUser User { get; private set; }

        public bool IsAuthenticated => ClaimsIdentity.IsAuthenticated;
        public string UserId => ClaimsIdentity.Claims.Single(x => x.Type == JwtTokenIssuer.UserIdClaimType).Value;

        public async Task<bool> HasMeetingAccess(string meetingId, params string[] permissions)
        {
            if (await userManager.IsInRoleAsync(User, AccountRole.MODERATOR.ToString()))
                return true;

            var meetingAccess = User.MeetingAccesses.Find(x => x.MeetingId == meetingId);
            if (meetingAccess == null || meetingAccess.IsOwner)
                return true;

            var query = Builders<MeetingRole>.Filter.And(
                Builders<MeetingRole>.Filter.In(x => x.Id, meetingAccess.MeetingRoles),
                Builders<MeetingRole>.Filter.Eq(x => x.DisabledDate, null)
            );
            var roles = await persistentService.GetCollection<MeetingRole>()
                .Find(query)
                .ToListAsync();
            var allPermissions = new HashSet<string>(roles.SelectMany(x => x.Permissions));

            return new HashSet<string>(permissions).IsSubsetOf(allPermissions);
        }

        public async Task<bool> IsInRole(AccountRole role)
        {
            return await userManager.IsInRoleAsync(User, role.ToString());
        }

        public bool IsGroupExisted(string meetingGroupId)
        {
            return User.MeetingGroups == null || User.MeetingGroups.Any(x => x.Id == meetingGroupId);
        }

        public Task<IdentityResult> Update()
        {
            return userManager.UpdateAsync(User);
        }

        public Task SendLoginState(string userId, string loginTimeStamp, CancellationToken cancellation)
        {
            var message = new Message(userId, loginTimeStamp);
            return hubContext.Clients.All.SendAsync("login", message, cancellationToken: cancellation);
        }

        public bool CanAccessToMeeting(string meetingId)
        {
            if (User?.MeetingAccesses == null)
                return false;
            var canAccess = User.MeetingAccesses.Any(x => x.IsOwner || (x.MeetingId.Equals(meetingId) && x.IsLocked == false));

            logger.LogDebug("CanAccessToMeeting [{canAccess}] ", canAccess);
            return canAccess;
        }

        public async Task EnsureIdentityUser()
        {
            if (User == null)
            {
                logger.LogDebug(">>>>>>Load identity user: {userId} - [{path}]<<<<<<<", UserId, contextAccessor.HttpContext.Request.Path.Value);
                User = await persistentService.GetCollection<IdentityUser>()
                    .Find(x => x.Id.Equals(UserId) && x.DeletedDate == null && x.LockedDate == null)
                    .SingleOrDefaultAsync(CancellationToken.None);
            }
        }
    }
}
