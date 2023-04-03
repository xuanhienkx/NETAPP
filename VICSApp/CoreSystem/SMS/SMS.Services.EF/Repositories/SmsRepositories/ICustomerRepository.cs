using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ICustomerRepository : IRepository<SmsCustomer>, IRepositoryAsync<SmsCustomer>
    {
        IList<SmsCustomer> GetCustomers(bool isClose);
        IList<SmsCustomer> GetCustomers(Expression<Func<SmsCustomer, bool>> where);
        Task<IList<SmsCustomer>> GetCustomersAsync(bool isClose);
        Task<IList<SmsCustomer>> GetCustomersAsync(Expression<Func<SmsCustomer, bool>> where);
        SmsCustomer GetCustomerWork(string id);
        Task<SmsCustomer> GetCustomerWorkAsync(string id);
    }
}