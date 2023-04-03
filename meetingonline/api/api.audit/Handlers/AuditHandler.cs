using api.audit.Models;
using api.common.Events;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace api.audit.Handlers
{
    public class AuditHandler : 
        INotificationHandler<UserLoginEvent>,
        INotificationHandler<TokenVerifyEvent>,
        INotificationHandler<VoteSubmitEvent>
    {
        private readonly IAuditStore auditStore;
        private readonly IHttpContextAccessor contextAccessor;

        public AuditHandler(IAuditStore auditStore, IHttpContextAccessor contextAccessor)
        {
            this.auditStore = auditStore ?? throw new ArgumentNullException(nameof(auditStore));
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        }

        public Task Handle(UserLoginEvent notification, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var loginAudit = new UserLogin(notification.User, contextAccessor.HttpContext)
            {
                Action = notification.Action,
                ActionTime = notification.ActionTime,
                Result = notification.Result,
                LoginName = notification.LoginName
            };
            return auditStore.Audit(loginAudit, nameof(UserLoginEvent));   
        }

        public Task Handle(TokenVerifyEvent notification, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var loginAudit = new TokenVerify(notification.User, contextAccessor.HttpContext)
            {
                Token = notification.Token,
                VerifyType = notification.Type
            };
            return auditStore.Audit(loginAudit, nameof(TokenVerifyEvent));
        }


        public Task Handle(VoteSubmitEvent notification, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var voteAudit = new VoteSubmit(notification.User, contextAccessor.HttpContext)
            {
                MeetingId = notification.MeetingId,
                Attendee = notification.Attendee
            };
            return auditStore.Audit(voteAudit, nameof(VoteSubmitEvent));
        }
    }
}
