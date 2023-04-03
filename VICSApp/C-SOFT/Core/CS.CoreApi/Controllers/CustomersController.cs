using AutoMapper;
using CS.Common;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Core.Service.DomainHandlers.Commands;
using CS.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.Common.Contract;

namespace CS.CoreApi.Controllers
{
    [Route("customers")]
    public class CustomersController : ApiControllerBase
    {
        private readonly IDataCommandBuilder<Guid, CustomerModel> commandBuilder;
        private readonly Lazy<IQuery<Guid, CustomerModel, Customer>> query;

        public CustomersController(IDataCommandBuilder<Guid, CustomerModel> commandBuilder,
            ILogger<CustomersController> logger,
            IDomainDataHandler domainDataHandler,
            IDataFactory dataFactory,
            IStringLocalizer<CustomersController> localizer, IMapper mapper)
            : base(domainDataHandler, logger, localizer, mapper)
        {
            this.commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
            this.query = new Lazy<IQuery<Guid, CustomerModel, Customer>>(
                dataFactory.CreateQuery<Guid, CustomerModel, Customer>(
                    x => x.Branch, 
                    x => x.CreatedBy, 
                    x => x.ModifiedBy, 
                    x => x.Contacts,
                    x => x.Broker));
        }

        [HttpGet]
        public async Task<IActionResult> GetFilter(string filter)
        {
            return await ResultAsync(
                () => query.Value.FilterAsync(x => string.IsNullOrEmpty(filter) || x.CustomerNumber.Contains(filter) || x.CardIdentity.Contains(filter),
                    c => c.SignatureImage2, c => c.SignatureImage1, c => c.PinCode),
                false);
        }

        [HttpPost("filter")]
        public IActionResult PostFilter([FromBody] IDictionary<string, string> filter)
        {
            if (filter == null)
            {
                NotifyError(Localizer["DataContractIsNull"]);
                return Result(false);
            }
            
            var result = query.Value.FilterAsync(filter, c => c.SignatureImage2, c => c.SignatureImage1, c => c.PinCode);
            return Result(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await ResultAsync(() => query.Value.GetAsync(id), false);
        }

        [HttpGet("{customerNumber}")]
        public async Task<IActionResult> GetByAccountName(string customerNumber)
        {
            return await ResultAsync(async () =>
            {
                var data = await query.Value.FilterAsync(x => x.CustomerNumber.Equals(customerNumber)); 
                return data?.FirstOrDefault();
            }, false);
        }

        /// <summary>
        /// Create new customer and given a flag to publish the message to vsd for register online
        /// </summary>
        /// <param name="customer"></param>         
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostInsert([FromBody] CustomerModel customer)
        {
            if (!CheckModelStateValidation(customer))
                return Result(customer);
            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildInsert(customer)));
        }

        /// <summary>
        /// Change the customer information. This changes will be publish the messsage to VSD when essential information was changed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>       
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdate(Guid id, [FromBody] CustomerModel customer)
        {
            customer.Id = id;
            if (!CheckModelStateValidation(customer))
                return Result(customer);
            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildUpdate(customer)));
        }

        [HttpPut("updateSattus/{id}")]
        public async Task<IActionResult> PutUpdateSattus(Guid id, [FromBody] CustomerModel customer)
        {
            customer.Id = id;
            if (!CheckModelStateValidation(customer))
                return Result(customer);
            return await ResultAsync(() => DomainDataHandler.SendCommand(new CustomerStatusUpdateCommand(customer)));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{active}")]
        public async Task<IActionResult> Close(Guid id, bool active)
        {
            return await ResultAsync(() => DomainDataHandler.SendCommand(commandBuilder.BuildDelete(id)));
        }

        [HttpGet("{id}/signature")]
        public async Task<IActionResult> GetSignatures(Guid id)
        {
            var result = new List<byte[]>();
            var customer = await query.Value.GetAsync(id);
            if (customer != null)
            {
                result.Add(customer.SignatureImage1);
                result.Add(customer.SignatureImage2);
            }
            return Result(result);
        }
    }
}
