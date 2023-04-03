using CSM.Common.Interfaces;
using CSM.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSM.Web.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IMessageService service;

        public ServicesController(IMessageService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPut("{customerId}")]
        public void Register(string customerId)
        {
            service.Register(customerId);
        }

        [HttpDelete("{customerId}")]
        public void UnRegister(string customerId)
        {
            service.UnRegister(customerId);
        }

        [HttpPost("mail/{customerId}")]
        public bool SendEmail(string customerId, [FromBody] string content)
        {
            return service.SendEmail(customerId, content);
        }

        [HttpPost("mail")]
        public int SendEmail([FromBody]Message message)
        {
            return message == null ? 0 : service.SendEmail(message);
        }

        [HttpPost("sms/{customerId}")]
        public bool SendSms(string customerId, [FromBody] string content)
        {
            return service.SendSms(customerId, content);
        }

        [HttpPost("sms")]
        public int SendSms([FromBody]Message message)
        {
            return message == null ? 0 : service.SendSms(message);
        }
    }
}