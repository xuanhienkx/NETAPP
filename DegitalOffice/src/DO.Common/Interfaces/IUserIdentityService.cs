using DO.Common.Contract;
using DO.Common.Contract.Enums;
using DO.Common.Domain.Interfaces;

namespace DO.Common.Interfaces;

public interface IUserIdentityService
{
    Task<IApplicationUser> CreateUser(IUserLogin model, UserRoleType loginRole = UserRoleType.User, string password = null);
    Task<IApplicationUser> GetUserNameById(Guid id);
    Task<bool> LockoutUser(Guid id, bool isLocked = true);
    Task<bool> ResetPassword(Guid id, string password = null);
    Task<bool> Delete(Guid id);
}
