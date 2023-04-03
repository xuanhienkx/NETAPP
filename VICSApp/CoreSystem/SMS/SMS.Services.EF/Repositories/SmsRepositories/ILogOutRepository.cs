using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ILogOutRepository : IRepository<SmsLogOut>, IRepositoryAsync<SmsLogOut>
    {
    }
}