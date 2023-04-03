using DO.Common;

namespace DO.Market.Service;

public interface IBusinessActionHandler
{
    string BussinessId { get; }
    Task<bool> ProcessMessageReceived(CsBag bag);
    Task<bool> ProcessMessageInformed(CsBag bag);
    Task<bool> ValidateModelContent(object contentModel);
    Task UpdateContentStatus(object contentModel, bool isRevertState);
}