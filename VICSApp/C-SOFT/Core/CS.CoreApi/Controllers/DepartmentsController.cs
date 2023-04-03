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
    [Route("departments")]
    public class DepartmentsController :  ApiControllerBase
    {
        private readonly IDomainService<long, DepartmentModel, Department> service;

        public DepartmentsController(IDomainDataHandler domainDataHandler,
            ILogger<ApiControllerBase> logger, IStringLocalizer<DepartmentsController> localizer,
            IDomainService<long, DepartmentModel, Department> service,
            IMapper mapper) 
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Logger.LogDebug("GET");
            return await ResultAsync(async () => await service.Query.GetAllAsync(), false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(long id)
        {
            return await ResultAsync(async () => await service.Query.GetAsync(id), false);
        }

        [HttpPost]
        public async Task<IActionResult> PostInsert([FromBody]DepartmentModel model)
        {
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => service.Insert(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(long id, [FromBody]DepartmentModel model)
        {
            model.Id = id;
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => service.Update(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ResultAsync(async () => await service.Delete(id));
        }
    }
}