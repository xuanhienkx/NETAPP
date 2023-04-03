using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class RequestHistRepository : Repository<SmsRequestHist>, IRequestHistRepository
    {
        private readonly ISmsDataContext _smsDataContext;

        public RequestHistRepository(ISmsDataContext smsDataContext)
            : base(smsDataContext as DbContext)
        {
            _smsDataContext = smsDataContext;
        }

        public List<SmsSummary> Summary(DateTime fromDate, DateTime toDate)
        { 
            var query = GetAll(x =>
                x.CreatedTime >= fromDate && x.CreatedTime <= toDate && x.IsSent &&
                !string.IsNullOrEmpty(x.SmsIdResponse)); 
            var hist = query.GroupBy(x => x.Mobile).Select(x => new
                            {
                                mobile = x.Key.GePhoneType(),
                                count = x.Sum(m => (Math.Ceiling(m.Message.Length / 160.0)))
                            }).ToList();

            var summarys = hist.GroupBy(x => x.mobile).Select(mo => new SmsSummary
            {
                Type = mo.Key,
                Quantity =(int) mo.Sum(x => x.count)
            }).ToList();

            return summarys;

        }
    }
}