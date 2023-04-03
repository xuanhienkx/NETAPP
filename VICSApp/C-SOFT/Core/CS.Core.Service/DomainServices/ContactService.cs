using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;

namespace CS.Core.Service.DomainServices
{
    public class ContactService : CommonServiceBase<long, ContactModel, Contact>
    {
        public ContactService(IDataFactory dataFactory, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
        }

        protected override bool ValidateInsert(ContactModel model)
        {
            return true;
        }

        protected override bool ValidateUpdate(ContactModel model)
        {
            return true;
        }

        protected override bool ValidateDelete(Contact deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => false;
    }
}