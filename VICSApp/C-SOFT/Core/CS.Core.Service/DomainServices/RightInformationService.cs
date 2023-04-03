using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;

namespace CS.Core.Service.DomainServices
{
    public class RightInformationService : CommonServiceBase<long, RightInformationModel, RightInformation>
    {
        public RightInformationService(IDataFactory dataFactory, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
        }
        protected override bool ValidateInsert(RightInformationModel model)
        {

            return true;
        }

        protected override bool ValidateUpdate(RightInformationModel model)
        {

            return true;
        }

        protected override bool ValidateDelete(RightInformation deletedEntity)
        {
            return true;
        }

        protected override bool UseCache => false;
    }
}