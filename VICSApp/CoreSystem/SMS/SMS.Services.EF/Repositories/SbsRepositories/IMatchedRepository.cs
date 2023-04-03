using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SbsRepositories
{
    public interface IMatchedRepository
    {
        List<TradingResult> GetSbsTradings();
        List<TradingResult> GetSbsTradings(List<string> cusId);
        Task<List<TradingResult>> GetSbsTradingsAsync();
        decimal OrderVolum(string orderNo);
        Task<decimal> OrderVolumAsync(string orderNo);
    }
}