using BO.Core.DataCommon.Shared;
using BO.Core.DataCommon.Shared.Interfaces;
using DO.Common.Contract.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Core.DataDomain.Services
{
    public class CurrentUserAccessor : ICurrentUser
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IPersistentService<DomainPersistentService> persistentService;
        private readonly ILogger<CurrentUserAccessor> logger;
        private readonly ILocalizer localizer;
        private readonly IHubContext<ApplicationStateHub> hubContext;

        public CurrentUserAccessor(IHttpContextAccessor contextAccessor,
            IPersistentService<DomainPersistentService> persistentService,
            ILogger<CurrentUserAccessor> logger,
            ILocalizer localizer,
            IHubContext<ApplicationStateHub> hubContext)
        {
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            this.persistentService = persistentService ?? throw new ArgumentNullException(nameof(persistentService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            this.hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public bool IsAuthenticated => throw new NotImplementedException();

        public string UserId => throw new NotImplementedException();

        public bool CanAccessToMeeting(string meetingId)
        {
            throw new NotImplementedException();
        }

        public Task EnsureIdentityUser()
        {
            throw new NotImplementedException();
        }

        public bool IsGroupExisted(string meetingGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRole(AccountRole role)
        {
            throw new NotImplementedException();
        }

        public Task SendLoginState(string userId, string loginTimeStamp, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
