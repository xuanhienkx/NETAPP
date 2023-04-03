using System.Threading.Tasks;

namespace api.common.Shared.Interfaces
{
    public interface IEmailService
    {
        Task SendMail(string email, string displayName, string subject, string body);
    }
}