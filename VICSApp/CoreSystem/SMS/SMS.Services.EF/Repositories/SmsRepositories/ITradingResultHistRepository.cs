using System;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface ITradingResultHistRepository : IRepository<SmsTradingResultHist>,
        IRepositoryAsync<SmsTradingResultHist>
    {
        
    }
}