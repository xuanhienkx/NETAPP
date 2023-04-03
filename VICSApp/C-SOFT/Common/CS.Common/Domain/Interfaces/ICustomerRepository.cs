using System;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;

namespace CS.Common.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Guid, CustomerModel>
    {
        Task<CustomerModel> UpdateStatus(string customerNumber, CustomerStatus status, string notes);
        Task<bool> UpdateStatus(Guid id, CustomerStatus status);
        Task<bool> ValidateVersion(Guid customerId, int customerVersion);
        Task<string> GenerateCustomerAccount(CustomerModel customer);
    }
}
