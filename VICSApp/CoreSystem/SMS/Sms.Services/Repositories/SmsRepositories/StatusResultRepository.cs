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
    public class StatusResultRepository : Repository<SmsStatusResult>, IStatusResultRepository
    {
        private readonly ISmsDataContext _smsDataContext;
        private readonly ILogger _logger;

        public StatusResultRepository(ISmsDataContext smsDataContext, ILogger logger)
            : base(smsDataContext as DbContext)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            this._smsDataContext = smsDataContext;
            _logger = logger;
        }

        public void InsertStatus(SmsStatusResult entity)
        {
            var phoneType = entity.Phone.GePhoneType();
            entity.MobileType = phoneType;
            Insert(entity);
        }

        public void UpdateStatus(SmsStatusResult entity)
        {
            var smsStatus =
                _smsDataContext.SmsStatusResults.FirstOrDefault(
                    x => x.SmsId == entity.SmsId && x.OrderDate == entity.OrderDate);
            var phoneType = entity.Phone.GePhoneType();
            if (smsStatus == null) return;
            smsStatus.MobileType = phoneType;
            smsStatus.IsSent = entity.IsSent;
            smsStatus.SentResult = entity.SentResult;
            smsStatus.IsAllSuccess = entity.IsAllSuccess;
            Update(smsStatus);
        }

        public IList<SmsStatusResult> GetAllNeedSend()
        {
            throw new NotImplementedException();
        }

        public bool IsExisted(string smsId, string orderDate, string phone = null)
        {
            return Any(x => x.SmsId == smsId && x.OrderDate == orderDate
                && (string.IsNullOrEmpty(phone) || x.Phone == phone));
        }



        public List<SmsSummary> GeSummaries(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var query = GetQuery(x =>
               x.Transdate >= fromDate && x.Transdate <= toDate && x.IsSent &&
               x.SentResult).Distinct().ToList();
                var request =
                    _smsDataContext.RequestHists.Where(
                        x => x.CreatedTime >= fromDate && x.CreatedTime <= toDate && x.IsSent &&
                             x.IsSent && !string.IsNullOrEmpty(x.SmsIdResponse)).Distinct().ToList();
                var join = from s in query
                           join r in request
                               on new { s.SmsId, RequestId = s.SmsRequestId, s.OrderDate } equals
                                  new { SmsId = r.SmsIdResponse, r.RequestId, r.OrderDate }
                           select new
                           {
                               SmsId = s.SmsId,
                               RequstId = r.RequestId,
                               OrderDate = r.OrderDate,
                               Phone = s.Phone,
                               MobileType = s.MobileType,
                               MsQty = (r.Message.Length <= 160) ? 1 : (Math.Floor(r.Message.Length / 160.0) + 1)
                           };
                var summarys = join.Distinct().GroupBy(x => x.MobileType).Select(x => new SmsSummary
                {
                    Type = x.Key,
                    Quantity = (int)x.Sum(g => g.MsQty)
                }).ToList();

                //var summarys = hist.GroupBy(x => x.mobile).Select(mo => new SmsSummary
                //{
                //    Type = mo.Key,
                //    Quantity = (int)mo.Sum(x => x.count)
                //}).ToList();

                return summarys;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex);
            }
            return null;

        }
    }
}