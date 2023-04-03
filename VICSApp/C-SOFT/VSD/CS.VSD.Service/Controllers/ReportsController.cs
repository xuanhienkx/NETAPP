using AutoMapper;
using CS.Common;
using CS.Common.Contract.VsdModels;
using CS.Common.Domain.Interfaces;
using CS.Common.FileTransfer;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CS.VSD.Service.Controllers
{
    [Route("vsd/reports")]
    public class ReportsController : ApiControllerBase
    {
        private readonly IConfigurationRoot config;
        private readonly IFileService fileService;
        private readonly IDomainService<long, FileActModel, FileAct> service;

        public ReportsController(
            IFileService fileService,
            IConfigurationRoot config,
            IDomainDataHandler domainDataHandler,
            ILogger<ReportsController> logger,
            IStringLocalizer<ReportsController> localizer,
            IDomainService<long, FileActModel, FileAct> service,
            IMapper mapper)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> Get(string reportCode)
        {
            return await ResultAsync(() => service.Query.FilterAsync(x => string.IsNullOrEmpty(reportCode) || x.ReportCode.StartsWith(reportCode)), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await ResultAsync(() => service.Query.GetAsync(id), false);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var archivePath = config["endpoints:vsdGateway:archivePath"].Trim('/', '\\').ToLowerInvariant();

            var memStream = new MemoryStream();
            using (var stream = await fileService.Read($"{archivePath}/{fileName}"))
            {
                await fileService.Transfer(stream, memStream);
                memStream.Position = 0;
            }

            return File(memStream, "application/octet-streams");
        }
    }
}