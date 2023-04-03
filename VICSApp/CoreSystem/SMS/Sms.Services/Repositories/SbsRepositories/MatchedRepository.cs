using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SMS.Common.Configuration;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SbsRepositories;
using SMS.DataAccess.Models;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Repositories.SbsRepositories
{
    public class MatchedRepository : IMatchedRepository
    {
        private readonly ISbsDataContext _db;
        private readonly ISmsDataContext _sms;

        public MatchedRepository(ISbsDataContext sbsDataContext, ISmsDataContext smsDataContext)
        {
            if (sbsDataContext == null) throw new ArgumentNullException("sbsDataContext");
            if (smsDataContext == null) throw new ArgumentNullException("smsDataContext");
            _db = sbsDataContext;
            _sms = smsDataContext;
        }

        private List<string> _customers = new List<string>();
        Dictionary<List<Guid>, List<TradingResult>> _sbsTradings = new Dictionary<List<Guid>, List<TradingResult>>();
        public List<TradingResult> GetSbsTradings()
        {
            var listTime = ExistsTradings;
            if (_sbsTradings.ContainsKey(listTime))
            {
                return _sbsTradings[listTime];
            } 
            var list = _db.TradingResults.Where(x => !listTime.Contains(x.Id)).ToList();
            if (!_customers.Any())
            {
                _customers = _sms.Customers.Where(c => c.IsClose == false).Select(x => x.Id).ToList();
            }

            var listResut = list.Where(t => _customers.Contains(t.CustomerId)).ToList();
            _sbsTradings.Add(listTime, listResut);
            return listResut;
        }

        public List<TradingResult> GetSbsTradings(List<string> customerIds)
        {
            var listTime = ExistsTradings;
            if (_sbsTradings.ContainsKey(listTime))
            {
                return _sbsTradings[listTime];
            }
            var list = _db.TradingResults.Where(x => !listTime.Contains(x.Id)).ToList();
            var listResut = list.Where(t => customerIds.Contains(t.CustomerId)).ToList();
            _sbsTradings.Add(listTime, listResut);
            return listResut;

        }

        public async Task<List<TradingResult>> GetSbsTradingsAsync()
        {
            return await _db.TradingResults.Where(x => !ExistsTradings.Contains(x.Id)).ToListAsync();
        }

        private IDictionary<string, TradingOrder> _tradingOrder = new Dictionary<string, TradingOrder>();
        public decimal OrderVolum(string orderNo)
        {
            TradingOrder order;
            if (_tradingOrder.Any() && _tradingOrder.TryGetValue(orderNo, out order))
                return order.OrderVolume;

            order = _db.TradingOrders.FirstOrDefault(x => x.OrderNo == orderNo);
            if (order == null) return 0;
            _tradingOrder.Add(orderNo, order);
            return order.OrderVolume;
        }

        public async Task<decimal> OrderVolumAsync(string orderNo)
        {
            TradingOrder order;
            if (_tradingOrder.Any() && _tradingOrder.TryGetValue(orderNo, out order))
                return order.OrderVolume;

            order =  await _db.TradingOrders.FirstOrDefaultAsync(x => x.OrderNo == orderNo);
            if (order == null) return 0;
            _tradingOrder.Add(orderNo, order);
            return order.OrderVolume;
        }

        private List<Guid> ExistsTradings
        {
            get
            { 
                return _sms.TradingResults.Select(x => x.SbsResultId).ToList();
            }
        }


    }
}