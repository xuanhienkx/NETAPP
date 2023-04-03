using CSM.Common;
using CSM.Common.Interfaces;
using CSM.Common.Models;
using System;
using System.Collections.Generic;

namespace CSM.Components
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public ResultList<CustomerModel> GetFilter(Filter filter)
        {
            return repository.Filter(filter);
        }

        public CustomerModel GetById(string customerId)
        {
            return repository.Get(customerId);
        }

        public CustomerModel Create(CustomerModel customer)
        {
            return repository.Create(customer);
        }

        public CustomerModel Update(CustomerModel customer)
        {
            return repository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return repository.Delete(customerId);
        }
    }
}
