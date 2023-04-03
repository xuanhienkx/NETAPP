using System;
using System.Threading.Tasks;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;

namespace CS.Common.Interfaces
{
    public interface IApplicationUserAccessor
    {
        Task<IApplicationUser> GetUser();
        Guid? GetUserId();
    }
}