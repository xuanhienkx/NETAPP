using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CSM.Common;
using CSM.Common.Interfaces;
using CSM.Common.Models;
using CSM.Components.DataAccess.Models;

namespace CSM.Components.DataAccess
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public SqlCustomerRepository(DataContext dataContext, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        private static CustomerModel Parse(Customer entity)
        {
            if (entity == null)
                return null;

            return new CustomerModel
            {
                CustomerId = entity.CustomerId,
                Name = entity.CustomerName,
                Email = entity.Email,
                Mobile = entity.Mobile,
                IsActive = entity.IsActive
            };
        }

        private IOrderedQueryable<Customer> BuildQuery(Filter filter)
        {
            var qr = dataContext.Customers.Where(filter.ToExpression<Customer>());
            return string.IsNullOrEmpty(filter.SortField.FieldName)
                ? qr.OrderBy(x => x.CustomerId)
                : qr.OrderBy(filter.SortField);
        }

        public ResultList<CustomerModel> Filter(Filter filter)
        {
            var query = BuildQuery(filter);
            var result = query.Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList()
                .ConvertAll(Parse);
            var count = query.Count();

            return new ResultList<CustomerModel>
            {
                Filter = filter,
                TotalCount = count,
                List = result
            };
        }

        public CustomerModel Get(string customerId)
        {
            var entity = dataContext.Customers.SingleOrDefault(x => x.CustomerId == customerId);
            return Parse(entity);
        }

        public CustomerModel Create(CustomerModel customer)
        {
            var entity = mapper.Map<Customer>(customer);
            var rs = dataContext.Set<Customer>().Add(entity).Entity;
            dataContext.SaveChanges();
            return mapper.Map<CustomerModel>(rs); 
        }

        public CustomerModel Update(CustomerModel customer)
        {
            var entity = mapper.Map<Customer>(customer);
            var rs = dataContext.Set<Customer>().Update(entity).Entity;
            dataContext.SaveChanges();
            return mapper.Map<CustomerModel>(rs);
        }

        public bool Delete(string customerId)
        {
            try
            {
                var entity = dataContext.Set<Customer>().Find(customerId);
                dataContext.Set<Customer>().Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch 
            { 
                return false;
            }
        }
    }
}
