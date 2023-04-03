using DSoft.Common;
using DSoft.Common.Models;
using DSoft.Common.Queries;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSoft.Api.Controllers.V1
{
    [Authorize("ApiScope.read")]
    public class MarketInfoController : ApiV1Controller
    {
        public MarketInfoController(ILocalizer localizer,
            IHttpContextAccessor httpAccessor,
            IMediator mediator,
            ILogger<ApiControllerBase> logger)
            : base(localizer, httpAccessor, mediator, logger)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await QueryAsync(new GetByIdQuery<MarketInfo>(id));
        }

        /// <summary>
        ///   Get message  by InputSequenceNumber
        /// </summary>
        /// <param name="messageName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet("{messageName}/{begin}/{end}")]
        public async Task<IActionResult> GetByInputSequenceNumber([FromRoute] string messageName, [FromRoute] int begin = 0, [FromRoute] int end = 0)
        {
            if (begin <= 0 || end <= 0 || begin < end)
                return await ErrorAsync("Not valid Sequence Number");

            return await QueryAsync(
                       new GetAllByExpressionQuery<MarketInfo>(x =>
                           x.MessageName.Equals(messageName, StringComparison.InvariantCultureIgnoreCase)
                            && x.InputSequenceNumber >= begin && x.InputSequenceNumber <= end
                            && x.TradingDate.Equals(DateTime.Today.ToString("dd/MM/yyyy"))));

        }
    }
}
