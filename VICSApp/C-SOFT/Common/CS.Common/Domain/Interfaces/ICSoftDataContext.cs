using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CS.Common.Domain.Interfaces
{
    public interface ICSoftDataContext : IDisposable
    {
        Task<IDbContextTransaction> StartTransaction();
        DbSet<T> Set<T>() where T : class;
    }
}