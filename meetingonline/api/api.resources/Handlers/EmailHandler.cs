using api.common.Events;
using api.common.Shared.Interfaces;
using Hangfire;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace api.resources.Handlers
{
    public class EmailHandler : INotificationHandler<SendEmailEvent>
    {
        private readonly IEmailService emailService;
        private readonly IBackgroundJobClient backgroundJobs;

        public EmailHandler(IEmailService emailService, IBackgroundJobClient backgroundJobs)
        {
            this.emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            this.backgroundJobs = backgroundJobs ?? throw new ArgumentNullException(nameof(backgroundJobs));
        }

        public Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
        {
            // send email
            if (!string.IsNullOrEmpty(notification.Email))
            {
                backgroundJobs.Enqueue(() => emailService.SendMail(notification.Email, notification.Name,
                    notification.Content.Title, notification.Content.Body));
            }


            return Task.CompletedTask;
        }
    }
}
