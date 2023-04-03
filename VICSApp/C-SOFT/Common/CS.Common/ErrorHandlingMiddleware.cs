using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Std;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Localization;

namespace CS.Common
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IStringLocalizer<ErrorHandlingMiddleware> localizer;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IStringLocalizer<ErrorHandlingMiddleware> localizer)
        {
            this.next = next;
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var cultureFeature = context.Features.Get<IRequestCultureFeature>();
                if (cultureFeature != null)
                {
                    CultureInfo.CurrentCulture = cultureFeature.RequestCulture.Culture;
                    CultureInfo.CurrentUICulture = cultureFeature.RequestCulture.UICulture;
                }

                logger.LogError(ex, ex.Message);
                HandleException(context, localizer);
            }
        }

        private static void HandleException(HttpContext context, IStringLocalizer localizer)
        {
            context.Response.ContentType = "application/x-protobuf";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProtoBuf.Serializer.Serialize(context.Response.Body, new RequestResult<string>(null, false)
            {
                ErrorMessages = new List<string> { $"{localizer["UnexpectedExceptionHappend"]}"  }
            });
        }
    }
}
