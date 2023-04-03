using System;
using AutoMapper;
using CS.Common;
using CS.Common.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CS.CoreApi.Controllers
{
    [Route("hubs")]
    public class HubsController : ApiControllerBase
    {
        private readonly INotificationPublisher notificationPublisher;

        public HubsController(INotificationPublisher notificationPublisher, IDomainDataHandler domainDataHandler, ILogger<HubsController> logger, IStringLocalizer<HubsController> localizer, IMapper mapper) : 
            base(domainDataHandler, logger, localizer, mapper)
        {
            this.notificationPublisher = notificationPublisher ?? throw new ArgumentNullException(nameof(notificationPublisher));
        }

        [HttpGet("{message}")]
        public void SendMessage(string message)
        {
            notificationPublisher.Register(context => context.Data[message] = null);
            DomainDataHandler.Broadcast(message);
        }
    }
}
