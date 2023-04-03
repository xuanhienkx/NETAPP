using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CS.Common.Contract.Models;

namespace CS.Common.Domain.Interfaces
{
    public interface IGroupRepository : IRepository<Guid, GroupModel>
    {
        Task<IList<PermissionAccess>> GetAccessRights(IList<Guid> ids);
        Task<bool> SetAccessRights(Guid id, IList<PermissionAccess> permissions);
        Task<IList<GroupMemberModel>> GetMembers(Guid requestId);
    }
}