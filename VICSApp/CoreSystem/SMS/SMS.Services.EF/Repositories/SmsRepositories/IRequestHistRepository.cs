using System;
using System.Collections.Generic;
using SMS.Data.Services.EF.Models;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface IRequestHistRepository : IRepository<SmsRequestHist>, IRepositoryAsync<SmsRequestHist>
    {
        List<SmsSummary> Summary(DateTime fromDate, DateTime toDate);
    }
}