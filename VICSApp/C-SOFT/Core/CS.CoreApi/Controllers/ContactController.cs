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
    [Route("contacts")]
    public class ContactController : ApiControllerBase
    {
        private readonly IDomainService<long, ContactModel, Contact> service;
        public ContactController(IDomainDataHandler domainDataHandler, 
            ILogger<ApiControllerBase> logger,
            IStringLocalizer<ContactController> localizer,
            IDomainService<long, ContactModel, Contact> service, IMapper mapper) 
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(Guid customerId)
        {
            Logger.LogDebug("GET");
            return await ResultAsync(async () => await service.Query.FilterAsync(x=>x.CustomerId==customerId), false);
        }     
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return await ResultAsync(async () => await service.Query.GetAsync(id), false);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ContactModel model)
        {
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => service.Insert(model));
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody]ContactModel model)
        {
            model.Id = id;
            if (!CheckModelStateValidation(model))
                return Result(model);

            return await ResultAsync(() => service.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ResultAsync(async () => await service.Delete(id));
        }
    }
}