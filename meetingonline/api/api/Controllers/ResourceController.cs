using api.common;
using api.common.Models;
using api.common.Shared;
using api.common.Shared.Interfaces;
using api.resources;
using api.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.common.Commands;
using api.common.Shared.Base;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
#pragma warning disable 1591

namespace api.Controllers
{
    public class ResourceController : BaseController
    {
        private readonly IMultipartConsumer multipartConsumer;

        public ResourceController(IMultipartConsumer multipartConsumer, IMediator mediator, ILocalizer localizer, IHttpContextAccessor httpContext, ILogger<BaseController> logger)
            : base(mediator, httpContext, localizer, logger)
        {
            this.multipartConsumer = multipartConsumer ?? throw new ArgumentNullException(nameof(multipartConsumer));
        }

        [HttpPost("upload")]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> Upload()
        {

            if (!multipartConsumer.IsMultipartContentType(Request.ContentType))
                return Ok(Result.Error(Text("resource.contenTypeInvalid")));

            var boundary = multipartConsumer.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType));
            if (!boundary.Succeeded)
                return Ok(boundary);

            var reader = new MultipartReader(boundary.Value, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);
            if (hasContentDispositionHeader && multipartConsumer.HasFileContentDisposition(contentDisposition))
            {
                var streamResult = await Mediator.Send(new UploadFileCommand(section.Body, contentDisposition.FileName.Value));
                return Ok(streamResult);
            }

            return Ok(Result.Error(Text("resource.uploadFailed")));
        }

        [HttpPost("upload/many")]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> UploadMany()
        {
            if (!multipartConsumer.IsMultipartContentType(Request.ContentType))
                return Ok(Result.Error(Text("resource.contenTypeInvalid")));

            var boundary = multipartConsumer.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType));
            if (!boundary.Succeeded)
                return Ok(boundary);

            var reader = new MultipartReader(boundary.Value, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            var result = new List<MediaResource>();

            while (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader && multipartConsumer.HasFileContentDisposition(contentDisposition))
                {
                    var streamResult = await Mediator.Send(new UploadFileCommand(section.Body, contentDisposition.FileName.Value));
                    if (streamResult.Succeeded)
                        result.Add(streamResult.Value);
                }

                // Drain any remaining section body that hasn't been consumed and
                // read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }

            return Value(result);
        }


        [HttpDelete("{id}")]
        public Task<IActionResult> Delete([FromRoute] string id)
        {
            return CommandAsync(new DeleteByIdCommand<MediaResource>(id));
        }
    }
}
