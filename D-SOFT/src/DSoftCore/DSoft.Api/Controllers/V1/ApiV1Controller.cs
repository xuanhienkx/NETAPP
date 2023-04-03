using DSoft.Common;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DSoft.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]      
    public abstract class ApiV1Controller : ApiControllerBase
    {
        protected ApiV1Controller(ILocalizer localizer, IHttpContextAccessor httpAccessor, IMediator mediator, ILogger<ApiControllerBase> logger)
            : base(localizer, httpAccessor, mediator, logger)
        {
        }
    }
}
