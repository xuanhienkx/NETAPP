using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ILogOutHistRepository : IRepository<SmsLogOutHist>, IRepositoryAsync<SmsLogOutHist>
    {
    }
}