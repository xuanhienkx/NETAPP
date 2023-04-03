using CSM.Common.Models;

namespace CSM.Common.Interfaces
{
    public interface IMessageService
    {
        bool SendEmail(string customerId, string content);
        int SendEmail(Message message);
        bool SendSms(string customerId, string content);
        int SendSms(Message message);
        void Register(string customerId);
        void UnRegister(string customerId);
    }
}