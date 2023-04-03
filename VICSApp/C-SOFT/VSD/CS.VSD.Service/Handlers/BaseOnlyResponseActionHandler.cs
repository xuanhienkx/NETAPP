using System;
using System.Threading.Tasks;
using CS.Common;

namespace CS.VSD.Service.Handlers
{
    public abstract class BaseOnlyResponseActionHandler : IBusinessActionHandler
    {
        public abstract string BussinessId { get; }
        public abstract Task<bool> ProcessMessageReceived(CsBag bag);
        public Task<CsBag> PrepareBagToBuildMessage(object model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProcessMessageInformed(CsBag bag)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateModelContent(object contentModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContentStatus(object contentModel, bool isRevertState)
        {
            throw new NotImplementedException();
        }
    }
}