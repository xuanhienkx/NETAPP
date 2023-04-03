using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.Data.Services.EF.Models;

namespace SMS.Data.Services.EF.Repositories.SbsRepositories
{
    public interface IFirstDayRepository
    {
        IList<BalanceModel> GetCurrenBalance(List<string> customerIds);
        IList<SecurityModel> GetSecurities(List<string> customerIds);
        IList<string> CustomerTradingOnMonth { get; }
        DateTime GetCurrentWorkDay { get; }
        DateTime GetLastWorkDay { get; }
    }
}