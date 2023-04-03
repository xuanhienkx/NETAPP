using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Common
{
    public static class EmailService
    {
        public const string OnUserRegistered = "OnUserRegistered";
        public const string OnUserTrading = "OnUserTrading";
        public const string OnUserLevel = "OnUserLevel";

        public static void SendEmail(string name, object emailOptions)
        {
            SendEmail(name,
                emailOptions.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(emailOptions, null)));
        }

        public static void SendEmail(string name, IDictionary<string, object> emailOptions)
        {
            EventManager.Trigger(name, emailOptions);
        }

        public static async Task SendEmailAsync(string name, object emailOptions)
        {
            await SendEmailAsync(name, emailOptions.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(emailOptions, null)));
        }

        public static async Task SendEmailAsync(string name, IDictionary<string, object> emailOptions)
        {
            await Task.Run(() => EventManager.Trigger(name, emailOptions));
        }
    }
}
