using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain.Interfaces;
using CS.Common.Exceptions;
using CS.Common.Extensions;
using CS.Common.Std.Extensions;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS.Domain.Data.Repositories
{
    public class CustomerSqlRepository : RepositoryBase<Guid, CustomerModel, Customer>, ICustomerRepository
    {
        private readonly ILogger<CustomerSqlRepository> logger;

        public CustomerSqlRepository(CSoftDataContext dataContext, IMapper mapper, ILogger<CustomerSqlRepository> logger)
            : base(dataContext, mapper)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override Customer StartPreparingForInsert(CustomerModel model)
        {
            var pin = Guid.NewGuid().ToString("N").Substring(0, 6);
            var byt = Encoding.UTF8.GetBytes(pin);
            model.PinCode = Convert.ToBase64String(byt);
            model.UserName = model.CustomerNumber;
            model.FullName = model.FullNameLocal.ConvertToUnSign();

            // entity
            var entity = new Customer
            {
                Id = Guid.NewGuid(),
                Status = CustomerStatus.Open
            };
            if (model.Contacts != null && model.Contacts.Any())
                InsertContactList(entity, model.Contacts);

            return entity;
        }

        protected override Customer StartPreparingForUpdate(CustomerModel customer)
        {
            var customerEntity = DataContext.Set<Customer>()
                .FirstOrDefault(x => x.Id == customer.Id);

            if (customerEntity == null)
                throw new EntityNotFoundException<CustomerModel>(customer);
            if (customerEntity.Version != customer.Version)
                throw new EntityNotSameVersionException<CustomerModel>(customer, customer.Version);

            customerEntity.ModifiedByUserId = customer.ModifiedBy?.Id;
            customerEntity.ModifiedDate = DateTime.UtcNow;
            customerEntity.Version += 1;

            CleanupBeforeDelete(customer.Id);

            if (customer.Contacts != null && customer.Contacts.Any())
                InsertContactList(customerEntity, customer.Contacts);

            return customerEntity;
        }

        private void InsertContactList(Customer customerEntity, IList<ContactModel> customerContacts)
        {
            customerEntity.Contacts = customerContacts.Select(x => Mapper.Map<Contact>(x)).ToList();
        }

        public async Task<CustomerModel> UpdateStatus(string customerNumber, CustomerStatus status, string notes)
        {
            logger.LogDebug("UpdateStatus {0} for customer {1}", status, customerNumber);
            var entity = await DataContext.Set<Customer>()
                .SingleOrDefaultAsync(x => x.CustomerNumber.Equals(customerNumber, StringComparison.OrdinalIgnoreCase));

            if (entity == null)
                throw new EntityNotFoundException<string>(customerNumber);

            entity.Status = status;
            entity.Notes = notes;
            entity.Version += 1;

            if (status == CustomerStatus.Closed)
                entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            var db = DataContext.Set<Customer>().Update(entity);
            await DataContext.SaveChangesAsync();
            return Mapper.Map<CustomerModel>(db.Entity);
        }

        public async Task<bool> UpdateStatus(Guid id, CustomerStatus status)
        {
            logger.LogDebug("UpdateStatus for customer id [{1}]: {0}", status, id);
            var entity = DataContext.Set<Customer>()
                .SingleOrDefault(x => x.Id == id);
            if (entity == null)
                throw new EntityNotFoundException<Guid>(id);

            entity.Status = status;
            entity.Version += 1;

            if (status == CustomerStatus.Closed || status == CustomerStatus.PendingClose)
                entity.IsActive = false;
            entity.ModifiedDate = DateTime.Now;

            DataContext.Set<Customer>().Update(entity);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public Task<bool> ValidateVersion(Guid customerId, int customerVersion)
        {
            return DataContext.Set<Customer>()
                 .AnyAsync(x => x.Id == customerId && x.Version == customerVersion);
        }

        public async Task<string> GenerateCustomerAccount(CustomerModel customer)
        {
            return await CircuitBreakerExtensions.CircuitBreakerExecuteAsync(async () =>
            {
                var sqlCommand = DataContext.Database.GetDbConnection().CreateCommand();
                sqlCommand.CommandText = "GenerateAccountNumber";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@customerId", SqlDbType.UniqueIdentifier) { Value = customer.Id });
                sqlCommand.Parameters.Add(new SqlParameter("@branchId", SqlDbType.BigInt) { Value = customer.Branch.Id });

                var result = await sqlCommand.ExecuteScalarAsync();
                customer.CustomerNumber = result as string;

                return customer.CustomerNumber;
            });
        }

        protected override void CleanupBeforeDelete(Guid id)
        {
            //Remore all contact of customer before update
            var contacts = DataContext.Set<Contact>().Where(x => x.CustomerId.Equals(id));
            DataContext.Set<Contact>().RemoveRange(contacts);
        }

        protected override void RecoveredModel(Customer db, CustomerModel resource)
        {
            resource.ModifiedBy = Mapper.Map<UserModel>(Get<User, Guid>(db.ModifiedByUserId.GetValueOrDefault()));
        }
    }
}
