using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ITransactionDayHistRepository : IRepository<SmsTransactionDayHist>,
        IRepositoryAsync<SmsTransactionDayHist>
    {
    }
}