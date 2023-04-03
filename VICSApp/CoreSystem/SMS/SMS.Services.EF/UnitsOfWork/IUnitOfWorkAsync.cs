using System.Threading;
using System.Threading.Tasks;

namespace SMS.Data.Services.EF.UnitsOfWork
{
    public interface IUnitOfWorkAsync
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}