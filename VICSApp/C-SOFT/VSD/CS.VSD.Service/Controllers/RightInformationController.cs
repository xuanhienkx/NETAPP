using AutoMapper;
using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CS.VSD.Service.Controllers
{
    [Route("vsd/Informations")]
    public class RightInformationController :  ApiControllerBase
    {
        private readonly IDomainService<long, RightInformationModel, RightInformation> service;

        public RightInformationController(IDomainDataHandler domainDataHandler, 
                                ILogger<ApiControllerBase> logger, 
                                IStringLocalizer<RightInformationController> localizer,
                                IDomainService<long, RightInformationModel, RightInformation> service,
                                IMapper mapper) 
        : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ResultAsync(async () => await service.Query.GetAllAsync(), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await ResultAsync(async () => await service.Query.GetAsync(id), false);
        }
    }
}