using AutoMapper;
using BO.Core.DataCommon.Entities;
using DO.Common;
using DO.Common.Contract.Models;
using DO.Common.Domain.Interfaces;
using DO.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace DO.Market.Service.Controllers;
/// <summary>
/// This controller is only used by internal service
/// </summary>
[Route("market/gateway")]
[Authorize]
public class MarketController : ApiControllerBase
{
    private readonly INotificationPublisher notificationPublisher;
    private readonly IDomainService<long, MarketInfoRequestModel, MarketInfoRequest> service;
    private readonly IEnumerable<IBusinessActionHandler> handlers;
    public MarketController(
        IDomainDataHandler domainDataHandler,
        ILogger<ApiControllerBase> logger,
        IStringLocalizer localizer, IMapper mapper, INotificationPublisher notificationPublisher, IDomainService<long, MarketInfoRequestModel, MarketInfoRequest> service, IEnumerable<IBusinessActionHandler> handlers)
        : base(domainDataHandler, logger, localizer, mapper)
    {

        this.notificationPublisher = notificationPublisher ?? throw new ArgumentNullException(nameof(notificationPublisher));
        this.service = service ?? throw new ArgumentNullException(nameof(service));
        this.handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    }
    [HttpPost("{messageName}")]
    public async Task<IActionResult> Create(string messageName, [FromBody] CsBag bagItems)
    {
        if (!CheckModelStateValidation())
            return Result(false);

        var handler = handlers.SingleOrDefault(h => h.BussinessId.Equals(messageName));

        if (handler == null)
        {
            DomainDataHandler.RaiseError($"Cannot find the handler for business #ID: {messageName}");
            return Result(false);
        }

        return await ResultAsync(() => handler.ProcessMessageReceived(bagItems));
    }

}
