using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DO.Common.Domain.Interfaces;

public interface IDODataContext : IDisposable
{
    Task<IDbContextTransaction> StartTransaction();
    DbSet<T> Set<T>() where T : class;
}
