using System.Collections.Generic;
using CSM.Common.Models;

namespace CSM.Common.Interfaces
{
    public interface ICustomerService
    {
        ResultList<CustomerModel> GetFilter(Filter filter);
        CustomerModel GetById(string customerId);
        CustomerModel Create(CustomerModel customer);
        CustomerModel Update(CustomerModel customer);
        bool Delete(string customerId);
    }
}
