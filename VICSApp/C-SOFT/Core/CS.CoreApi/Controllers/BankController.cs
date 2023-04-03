using AutoMapper;
using CS.Common;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CS.Common.Contract.Models;

namespace CS.CoreApi.Controllers
{
    [Route("banks")]
    public class BankController : ApiControllerBase
    {
        private readonly IDomainService<long, BankModel, Bank> service;
        public BankController(
            IDomainDataHandler domainDataHandler,
            ILogger<BankController> logger,
            IStringLocalizer<BankController> localizer,
            IMapper mapper,
            IDomainService<long, BankModel, Bank> service)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string filter)
        {
            return await ResultAsync(() =>
                                     service.Query.FilterAsync(x =>
                                                           string.IsNullOrEmpty(filter)
                                                           || x.BankPlRlCode.StartsWith(filter.ToUpper(), StringComparison.CurrentCultureIgnoreCase))
                                    , false);
        }

    }
}