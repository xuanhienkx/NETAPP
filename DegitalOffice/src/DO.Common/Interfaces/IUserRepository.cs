using DO.Common.Contract.Models;
using DO.Common.Domain.Interfaces;

namespace DO.Common.Interfaces;

public interface IUserRepository : IRepository<Guid, UserModel>
{
    Task<bool> UpdateStatus(Guid id, bool isActive);
}
