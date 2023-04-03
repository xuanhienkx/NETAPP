using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Models;

namespace CS.Common.Domain.Interfaces
{
    public interface IUserRepository : IRepository<Guid, UserModel>
    {
        Task<bool> UpdateStatus(Guid id, bool isActive);
    }
}
