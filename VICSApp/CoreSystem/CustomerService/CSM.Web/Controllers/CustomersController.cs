using CSM.Common;
using CSM.Common.Interfaces;
using CSM.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CSM.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPut("filter")]
        public ResultList<CustomerModel> GetFilter([FromBody] Filter filter)
        {
            return customerService.GetFilter(filter);
        }

        [HttpGet("{customerId}")]
        public CustomerModel Get(string customerId)
        {
            return customerService.GetById(customerId);
        }

        [HttpPost]
        public CustomerModel Create([FromBody]CustomerModel customer)
        {
            return customerService.Create(customer);
        }

        [HttpPut]
        public CustomerModel Update([FromBody]CustomerModel customer)
        {
            return customerService.Update(customer);
        }

        [HttpDelete("{customerId}")]
        public bool Delete(string customerId)
        {
            return customerService.Delete(customerId);
        }
    }
}