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

namespace CS.CoreApi.Controllers
{
    [Route("exchange")]
    public class ExchangeStockController : ApiControllerBase
    {
        private readonly IDomainService<long, ExchangeStockModel, ExchangeStock> service;

        public ExchangeStockController(IDomainDataHandler domainDataHandler,
            ILogger<ExchangeStockController> logger,
            IStringLocalizer<ExchangeStockController> localizer,
            IDomainService<long, ExchangeStockModel, ExchangeStock> service,
            IMapper mapper) : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string filter)
        {
            return await ResultAsync(() =>
                    service.Query.FilterAsync(x =>
                        string.IsNullOrEmpty(filter)
                        || x.ShortName.StartsWith(filter.ToUpper(), StringComparison.CurrentCultureIgnoreCase))
                , false);
        }
    }
}