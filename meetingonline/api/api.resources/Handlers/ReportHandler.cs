using api.common.Commands;
using api.common.Models;
using api.common.Settings;
using api.common.Shared;
using api.common.Shared.Base;
using api.common.Shared.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Path = System.IO.Path;

namespace api.resources.Handlers
{
    public class ReportHandler : BaseHandler,
        IRequestHandler<ReportGenerateCommand, Result<MediaResource>>
    {
        private readonly IFileService fileService;
        private readonly ApplicationSettings settings;
        private readonly IContentTransformerService transformerService;
        private readonly ILogger<ReportHandler> logger;
        private readonly string pathTemplate = ".data/ReportTemplate";

        public ReportHandler(IMediator mediator, ILocalizer localizer,
            IFileService fileService,
            ApplicationSettings settings,
            IContentTransformerService transformerService, ILogger<ReportHandler> logger
            )
            : base(mediator, localizer)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.transformerService = transformerService ?? throw new ArgumentNullException(nameof(transformerService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.pathTemplate = fileService.GetPath(pathTemplate);
        }


        public async Task<Result<MediaResource>> Handle(ReportGenerateCommand request, CancellationToken cancellationToken)
        {
            var reportTemplateFile = Path.Combine(pathTemplate, $"{request.ReportTemplateName}.html");
            var html = fileService.Load(reportTemplateFile);
            // add some common variables
            var style = fileService.Load(Path.Combine(pathTemplate, "report.css"));

            logger.LogDebug("CSS data string ==> {0}", style);
            request.PlaceHolder.TextPlaceHolders.Add("style", $"<style>{style}</style>");
            request.PlaceHolder.TextPlaceHolders.Add("day", $"{DateTime.Today.Day:D2}");
            request.PlaceHolder.TextPlaceHolders.Add("month", $"{DateTime.Today.Month:D2}");
            request.PlaceHolder.TextPlaceHolders.Add("year", $"{DateTime.Today.Year:D4}");


            logger.LogDebug("PlaceHolder ==> {0}", JsonConvert.SerializeObject(request.PlaceHolder));
            var qrCode = transformerService.TransformToQRCode(request.QrCodeData);
            request.PlaceHolder.ImagePlaceHolders.Add("qrcode", qrCode);

            logger.LogDebug("qrCode==> {0}", JsonConvert.SerializeObject(qrCode));
            // transform to html
            html = transformerService.Transform(html, request.PlaceHolder);
            logger.LogDebug("Html string data after Transform PlaceHolder==> {0}", html);
            var path = Path.Combine(settings.DataFileLocation, "reports");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            logger.LogDebug("path of report template", path);
            //TODO suu lai ten report 
            var fileId = $"{request.ReportId}_{Path.GetRandomFileName()}.pdf";
            var filePathName = Path.Combine(path, fileId);
            logger.LogInformation("File report name ==> {0}", filePathName);
            await transformerService.TransformHtmlToPdf(filePathName, html);

            var media = new MediaResource
            {
                Name = request.PlaceHolder.ReportName,
                FileId = fileId,
                Provider = "Report"
            };

            return await Mediator.Send(new CreateEntityCommand<MediaResource>(media), cancellationToken);
        }
    }
}
