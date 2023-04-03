using AutoMapper;
using CS.Common;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Std.Extensions;

namespace CS.VSD.Service.Controllers
{
    /// <summary>
    /// This controller is only used by internal service
    /// </summary>
    [Route("vsd/gateway")]
    [Authorize(Policy = "Service")]
    public class GatewayController : ApiControllerBase
    {
        private readonly INotificationPublisher notificationPublisher;
        private readonly IDomainService<long, CustodyRequestModel, CustodyRequest> service;
        private readonly IEnumerable<IBusinessActionHandler> handlers;

        public GatewayController(IEnumerable<IBusinessActionHandler> handlers,
            IDomainService<long, CustodyRequestModel, CustodyRequest> service,
            IDomainDataHandler domainDataHandler,
            ILogger<GatewayController> logger,
            IStringLocalizer<GatewayController> localizer,
            IMapper mapper,
            INotificationPublisher notificationPublisher)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.notificationPublisher = notificationPublisher ?? throw new ArgumentNullException(nameof(notificationPublisher));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        [HttpPost("{businessId}")]
        public async Task<IActionResult> Create(string businessId, [FromBody] IList<CsBagItem> bagItems)
        {
            if (!CheckModelStateValidation())
                return Result(false);

            var handler = handlers.SingleOrDefault(h => h.BussinessId.Equals(businessId));

            if (handler == null)
            {
                DomainDataHandler.RaiseError($"Cannot find the handler for business #ID: {businessId}");
                return Result(false);
            }

            return await ResultAsync(() => handler.ProcessMessageReceived(new CsBag(bagItems)));
        }


        [HttpPut("{requestRefId}")]
        public IActionResult Inform(string requestRefId, [FromBody] IList<CsBagItem> bagItems)
        {
            if (!CheckModelStateValidation())
                return Result(false);

            if (!long.TryParse(requestRefId, out var requestId))
            {
                DomainDataHandler.RaiseError($"CustodyRequest Id is not correct. Value for #ID: {requestRefId}");
                return Result(false);
            }

            var request = service.Query.Get(requestId);
            if (request == null)
            {
                DomainDataHandler.RaiseError($"Cannot find the CustodyRequest for #ID: {requestRefId}");
                return Result(false);
            }
            var handler = handlers.SingleOrDefault(h => h.BussinessId.Equals(request.BusinessId));

            if (handler == null)
            {
                DomainDataHandler.RaiseError($"Cannot find the handler for business #ID: {requestRefId}");
                return Result(false);
            }

            return Result(async () =>
            {
                var result = await handler.ProcessMessageInformed(new CsBag(bagItems));

                if (result)
                {
                    var content = service.Query.Get(requestId);
                    await notificationPublisher.Send(new NotificationMessage
                        {
                            Type = NotificationType.Content,
                            Content = content.Base64ProtoBufSerialize()
                        },
                        context =>
                        {
                            if (!context.Data.TryGetValue($"CustodyRequest_{request.Id}", out string reqId))
                                return false;

                            context.RequestedId = reqId;
                            return true;
                        });
                }
                else
                {
                    await notificationPublisher.Send(new NotificationMessage
                    {
                        Type = NotificationType.Inform,
                        Content = $"An response for resquest {requestRefId} has been received.",
                    }, context => context.Data.ContainsKey($"CustodyRequest_{request.Id}"));
                }

                return result;
            });
        }
    }
}
