using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Data.Services.EF.Models;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ITradingResultRepository : IRepository<SmsTradingResult>, IRepositoryAsync<SmsTradingResult>
    {
        IList<SmsTradingResult> GetTradings(bool isBuilded);
        Task<IList<SmsTradingResult>> GetTradingsAsync(bool isBuilded);
        IList<MatchedMessageModel> GetAllNeedBuild();
        Task<IList<MatchedMessageModel>> GetAllNeedBuildAsync(); 
        void SetBuilded( IList<SmsTradingResult> list);
    }
}