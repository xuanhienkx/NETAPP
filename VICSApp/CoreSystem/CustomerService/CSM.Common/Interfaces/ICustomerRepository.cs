using CSM.Common.Models;
using System.Collections.Generic;

namespace CSM.Common.Interfaces
{
    public interface ICustomerRepository
    {
        ResultList<CustomerModel> Filter(Filter filter);
        CustomerModel Get(string customerId);
        CustomerModel Create(CustomerModel customer);
        CustomerModel Update(CustomerModel customer);
        bool Delete(string customerId);
    }
}
