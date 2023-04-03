using CS.Application.Views.Custody.Base;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;

namespace CS.Application.Services.Interfaces
{
    public interface ICustodyBusinessHandler
    {
        RequestPublishViewModel CreateViewModel(string businessId, CustodyRequestModel custodyRequestModel);
        AccessRight RequiredAccessRight(string businessId);
    }
}
