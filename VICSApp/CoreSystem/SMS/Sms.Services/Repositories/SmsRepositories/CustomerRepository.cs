using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class CustomerRepository : Repository<SmsCustomer>, ICustomerRepository
    {
        private readonly ISmsDataContext _smsContext;

        public CustomerRepository(ISmsDataContext smsContext)
            : base(smsContext as DbContext)
        {
            this._smsContext = smsContext;
            GetCustomers(false);
        }

        IList<SmsCustomer> _customers = new List<SmsCustomer>();
        public IList<SmsCustomer> GetCustomers(Expression<Func<SmsCustomer, bool>> @where)
        {
            IList<SmsCustomer> customers = _smsContext.Customers.Where(@where).ToList();
            return customers;
        }

        public async Task<IList<SmsCustomer>> GetCustomersAsync(bool isClose)
        {
            IList<SmsCustomer> customers = await _smsContext.Customers.Where(x => x.IsClose==isClose).ToListAsync();
            return customers;
        }

        public async Task<IList<SmsCustomer>> GetCustomersAsync(Expression<Func<SmsCustomer, bool>> @where)
        {
            IList<SmsCustomer> customers = await _smsContext.Customers.Where(@where).ToListAsync();
            return customers;
        }

        public IList<SmsCustomer> GetCustomers(bool isClose)
        {
            if (_customers.Any())
            {
                return _customers;
            }
            IList<SmsCustomer> customers = _smsContext.Customers.Where(x => x.IsClose==isClose).ToList();
            _customers = customers;
            return customers;
        }

        IDictionary<string, SmsCustomer> existed = new Dictionary<string, SmsCustomer>();
        public SmsCustomer GetCustomerWork(string id)
        {
            if (existed.ContainsKey(id))
            {
                return existed[id];
            }
            var cus = _smsContext.Customers.FirstOrDefault(x => x.IsClose == false && x.Id == id);
            if (cus != null)
            {
                existed.Add(cus.Id, cus);
                return cus;
            }
            return null; 
        }

        public async Task<SmsCustomer> GetCustomerWorkAsync(string id)
        {
            if (existed.ContainsKey(id))
                return existed[id];
            var cus = await _smsContext.Customers.FirstOrDefaultAsync(x => x.IsClose == false && x.Id == id);
            if (cus == null) return null;
            existed.Add(cus.Id, cus);
            return cus;
        }
    }
}