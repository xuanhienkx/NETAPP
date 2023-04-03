using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class RequestRepository : Repository<SmsRequest>, IRequestRepository
    {
        private readonly ISmsDataContext _smsDataContext;
        private readonly ILogger _logger;

        public RequestRepository(ISmsDataContext smsDataContext, ILogger logger)
            : base(smsDataContext as DbContext)
        {
            if (smsDataContext == null) throw new ArgumentNullException("smsDataContext");
            if (logger == null) throw new ArgumentNullException("logger");
            this._smsDataContext = smsDataContext;
            _logger = logger;
        }

        public IList<SmsRequest> GetAllNeedSend()
        {
            var list = _smsDataContext.Requests.Where(x => x.IsSent == false).OrderBy(r => r.CreatedTime).Include(x => x.Customers).Take(150).ToList();
            return list;
        }

        public async Task<IList<SmsRequest>> GetAllNeedSendAsync()
        {
            var list = await _smsDataContext.Requests.Where(x => x.IsSent == false).OrderBy(r => r.CreatedTime).Include(x => x.Customers).ToListAsync();
            return list;
        }

        public void SetSended(IList<SmsRequest> list)
        {
            foreach (var request in list)
            {
                request.IsSent = true;
                Update(request);
            }
        }

        public void InsertRequest(SmsRequest entity)
        {
            try
            {
                string sub = ";";
                var message = entity.Message;
                if (entity.Type == (short) SmsType.ThongBao || entity.Type == (short) SmsType.Normal)
                {
                    Insert(entity);
                    
                }
                else
                {
                    while (message.Length > 160)
                    {
                        string temp = message.Substring(0, 160);
                        int indexOf = !temp.Trim().EndsWith(sub) ? temp.LastIndexOf(sub, System.StringComparison.Ordinal) + 1 : temp.Length;
                        entity.Message = message.Substring(0, indexOf);
                        Insert(entity);
                        message = message.Remove(0, indexOf);
                    }
                    if (message.Length >0 && message.Length <= 160)
                    {
                        entity.Message = message;
                        Insert(entity);
                    }
                } 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
        }
    }
}