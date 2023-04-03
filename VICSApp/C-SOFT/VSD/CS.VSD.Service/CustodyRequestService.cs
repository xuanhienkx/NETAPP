using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Interfaces;
using CS.Domain.Data.Entities;

namespace CS.VSD.Service
{
    public class CustodyRequestService : CommonServiceBase<long, CustodyRequestModel, CustodyRequest>
    {
        public CustodyRequestService(IDataFactory dataFactory, ICacheService cacheService)
            : base(dataFactory, cacheService)
        {
        }

        protected override bool ValidateDelete(CustodyRequest custodyRequest)
        {
            return custodyRequest.Status == CustodyRequestStatus.FailureRejected
                   || custodyRequest.Status == CustodyRequestStatus.PublishedFailed
                   || custodyRequest.Status == CustodyRequestStatus.RequestRejected;
        }

        protected override bool UseCache => false;

        protected override bool ValidateInsert(CustodyRequestModel model)
        {
            return true;
        }

        protected override bool ValidateUpdate(CustodyRequestModel model)
        {
            return true;
        }
    }
}
