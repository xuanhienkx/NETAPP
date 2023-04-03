using DSoft.Common;
using DSoft.Common.Shared;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser;
using DSoft.MarketParser.Commands;
using DSoft.MarketParser.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace DSoft.Api.Controllers.V1
{

    [Authorize("ApiScope")]
    public class MarketController : ApiV1Controller
    {
        public MarketController(ILocalizer localizer,
            IHttpContextAccessor httpAccessor,
            IMediator mediator,
            ILogger<ApiControllerBase> logger)
            : base(localizer, httpAccessor, mediator, logger)
        {
        }



        /// <summary>
        /// GW post message parser
        /// </summary>
        /// <param name="messageName"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost("{messageName}")]
        public Task<IActionResult> Post(string messageName, [FromBody] IList<CsBagItem> items)
        {
            return CommandAsync(new MarketInfoCreateCommand(new PrsBag(messageName) { Items = items }));
        }
    }
}
