using System;
using System.Linq;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SbsRepositories;
using SMS.DataAccess.Models;
using SMS.SBSAccess;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Repositories.SbsRepositories
{
    public class SbsCustomerRepository : ISbsCustomerRepository
    {
        private readonly ISbsDataContext context;

        public SbsCustomerRepository(ISbsDataContext context)
        {
            if(context==null) throw new ArgumentNullException("context");
            this.context = context;
        }

        public SmsCustomer GetById(string id)
        {
            var cus = context.Customers.FirstOrDefault(x => x.CustomerId == id);
            if (cus == null) return null;
            var smsCus = new SmsCustomer
            {
                Id = cus.CustomerId,
                CustomerName = cus.CustomerName,
                BranchCode = cus.BranchCode,
                Mobile = cus.Mobile,
                OpenDate = DateTime.Now,
                Email = cus.Email,
                CustomerType = cus.CustomerType,
                DomesticForeign = cus.DomesticForeign,
                Sex = cus.Sex == "M" ? true : false,
                CloseDate = DateTime.Now.AddYears(100), 
                IsAccountStatus = true,
                IsInfo = true,
                IsOrder = true,
                IsResult = true
            };
            return smsCus;
        }
    }
}