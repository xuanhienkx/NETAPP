using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ITransactionDayRepository : IRepository<SmsTransactionDay>, IRepositoryAsync<SmsTransactionDay>
    {
        IList<SmsTransactionDay> GetAllNeedBuild();
        Task<IList<SmsTransactionDay>> GetAllNeedBuildAsync();
        void SetBuilded(IList<SmsTransactionDay> list);
    }
}