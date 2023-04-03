using System;
using System.Collections.Generic;
using SMS.Data.Services.EF.Models;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface IStatusResultRepository : IRepository<SmsStatusResult>, IRepositoryAsync<SmsStatusResult>
    {
        void InsertStatus(SmsStatusResult entity);
        void UpdateStatus(SmsStatusResult entity);
        IList<SmsStatusResult> GetAllNeedSend();
        bool IsExisted(string smsId, string orderDate, string phone=null);
        List<SmsSummary> GeSummaries(DateTime fromDate, DateTime toDate);
    }
}