using CS.Common.Domain;
using System;
using System.Threading.Tasks;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Domain.Interfaces;

namespace CS.Common.Interfaces
{
    public interface IUserIdentityService
    {
        Task<IApplicationUser> CreateUser(IUserLogin model, UserRoleType loginRole = UserRoleType.User, string password = null);
        Task<IApplicationUser> GetUserNameById(Guid id);
        Task<bool> LockoutUser(Guid id, bool isLocked = true);
        Task<bool> ResetPassword(Guid id, string password = null);
        Task<bool> Delete(Guid id);
    }
}