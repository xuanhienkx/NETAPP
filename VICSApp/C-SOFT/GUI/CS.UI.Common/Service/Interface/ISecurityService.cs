using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.Common.Std;

namespace CS.UI.Common.Service.Interface
{
    public interface ISecurityService
    {
        Task<IList<string>> Authenticate(CredentialLoginModel credential);
        Task<IUserLogin> GetLoginUser();
        Task<RequestResult<bool>> Register(CredentialRegisterModel credential);
        Task SignOut();
        void StartNotificator();
    }
}