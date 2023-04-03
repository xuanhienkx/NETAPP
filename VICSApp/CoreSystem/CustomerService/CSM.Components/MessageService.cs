using System;
using System.Collections.Generic;
using System.Text;
using CSM.Common.Interfaces;
using CSM.Common.Models;

namespace CSM.Components
{
    public class MessageService : IMessageService
    {
        public bool SendEmail(string customerId, string content)
        {
            throw new NotImplementedException();
        }

        public int SendEmail(Message message)
        {
            throw new NotImplementedException();
        }

        public bool SendSms(string customerId, string content)
        {
            throw new NotImplementedException();
        }

        public int SendSms(Message message)
        {
            throw new NotImplementedException();
        }

        public void Register(string customerId)
        {
            throw new NotImplementedException();
        }

        public void UnRegister(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
