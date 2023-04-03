using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.Common;
using CS.Common.MessageQueue;

namespace CS.VSD.Service
{
    public interface IBusinessActionHandler
    {
        string BussinessId { get; }
        Task<bool> ProcessMessageReceived(CsBag bag); 
        Task<CsBag> PrepareBagToBuildMessage(object model);
        Task<bool> ProcessMessageInformed(CsBag bag);
        Task<bool> ValidateModelContent(object contentModel);
        Task UpdateContentStatus(object contentModel, bool isRevertState);
    }
}
