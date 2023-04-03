using api.common.Settings;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using api.common.Shared.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace api.resources.Services
{
    public class DefaultEmailService : IEmailService
    {
        private readonly EmailProviderSettings settings;
        private readonly ILogger<DefaultEmailService> logger;
        private readonly ApplicationSettings appSettings;
        private readonly IWebHostEnvironment env;

        public DefaultEmailService(EmailProviderSettings settings, ILogger<DefaultEmailService> logger, ApplicationSettings appSettings, IWebHostEnvironment env)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            this.env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public async Task SendMail(string email, string displayName, string subject, string body)
        {
            if (!appSettings.UseDefaultEmailProvider)
            {
                logger.LogWarning("Attempt to send email to {to} for {subject} --> FAILED DUE TO DEFAULT EMAIL PROVIDER NOT ENABLED", email, subject);
                return;
            }

            logger.LogDebug($"MailServer: {JsonConvert.SerializeObject(settings)}");

            if (string.IsNullOrEmpty(settings.EmailServer))
                return;

            using var mailMessage = new MailMessage();

            // FIX THIS LINE MAY DAMAGE THE SENDING EMAIL
            // ReSharper disable once UseObjectOrCollectionInitializer
            using var client = new SmtpClient(settings.EmailServer, settings.Port);

            //provide credentials
            client.Credentials = new NetworkCredential(settings.UserName, settings.Password);
            client.EnableSsl = true;

            // DebugSendEmail 
            if (!env.IsProduction())
                email = appSettings.SecuritySettings.SuperAdminEmail;
            
            Console.WriteLine("email to: {0}", email);
            // configure the mail message
            mailMessage.From = new MailAddress(settings.FromEmail, settings.FromName);
            mailMessage.To.Insert(0, new MailAddress(email, displayName));
            mailMessage.Subject = subject;

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            //send email
            await client.SendMailAsync(mailMessage);
        }
    }
}
