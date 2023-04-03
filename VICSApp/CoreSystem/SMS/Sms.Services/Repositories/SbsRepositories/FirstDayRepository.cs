using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Models;
using SMS.Data.Services.EF.Repositories.SbsRepositories;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Repositories.SbsRepositories
{
    public class FirstDayRepository : IFirstDayRepository
    {
        private readonly ISbsDataContext _db;
        private readonly ISmsDataContext _sms;
        private readonly ILogger _logger;
        private List<string> _customers = null;
        private DateTime? _lastWorkDate;
        private DateTime? _currentWorkDate;
        public FirstDayRepository(ISbsDataContext sbsDataContext, ISmsDataContext smsDataContext, ILogger logger)
        {
            if (sbsDataContext == null) throw new ArgumentNullException("sbsDataContext");
            if (smsDataContext == null) throw new ArgumentNullException("smsDataContext");
            if (logger == null) throw new ArgumentNullException("logger");
            this._db = sbsDataContext;
            _sms = smsDataContext;
            _logger = logger;
        }


       
        public DateTime GetCurrentWorkDay
        {
            get
            {
                if (_currentWorkDate != null) return _currentWorkDate.Value;
                var date = _db.TransDates.SingleOrDefault(x => x.BranchCode == "100");
                if (date != null)
                    _currentWorkDate = date.CurrentTransDate;
                else throw new SqlNullValueException("Not found current day of work");
                return _currentWorkDate.Value;
            }
        }

        public DateTime GetLastWorkDay
        {
            get
            {
                try
                {
                    if (_lastWorkDate != null) return _lastWorkDate.Value;
                    var date =
                        _db.TransDateHists
                            .OrderByDescending(x => x.TransDate).FirstOrDefault(x => x.BranchCode == "100" &&
                                                                                     !string.IsNullOrEmpty(x.EndUsername) &&
                                                                                     x.EndTime != null);
                    _lastWorkDate = date != null ? date.TransDate : DateTime.Today;
                    return _lastWorkDate.Value;
                }
                catch (InvalidOperationException ex)
                {
                    _logger.LogError(ex);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex);
                }
                return DateTime.Now;
            }
        }


        public IList<string> CustomerTradingOnMonth
        {
            get
            {
                if (_customers != null) return _customers;
                var preDate = GetLastWorkDay.AddMonths(-1);
                var customers =
                    _db.TradingResultHists.Where(
                        x => x.TransactionDate <= GetLastWorkDay &&
                             x.TransactionDate >= preDate &&
                             x.CustomerId.StartsWith("076C"))
                        .Select(x => x.CustomerId).Distinct().ToListAsync();
                customers.Wait();

                _customers = customers.Result.ToList();

                return _customers;
            }
        }

        private List<BalanceModel> _currenBalances;
        public IList<BalanceModel> GetCurrenBalance(List<string> customerIds)
        {
            if (_currenBalances != null && _currenBalances.Any())
                return _currenBalances;

            var day = GetLastWorkDay;
            var query = from bl in _db.Balances
                        join t in _db.TransactionHists on bl.AccountId equals t.AccountId
                        where t.TransactionDate == day && bl.SectionGl == "3241" && customerIds.Contains(bl.AccountId)
                        select new BalanceModel
                        {
                            AccountId = bl.AccountId,
                            CurrentBalance = bl.CurrentBalance,
                            TransactionDate = t.TransactionDate
                        };

            var list = query.Distinct().ToList();

            return list;
            /*  return _currenBalances =
           _db.Balances.Where(x => x.SectionGl == "3241" && customerIds.Contains(x.AccountId)).OrderBy(x => x.AccountId)
               .Join(_db.TransactionHists
                   .Where(x => x.TransactionDate == GetLastWorkDay), b => b.AccountId,
                   t => t.AccountId, (b, t) => new { Balance = b, TransactionHist = t })
               .Select(x => new BalanceModel
               {
                   AccountId = x.Balance.AccountId,
                   CurrentBalance = x.Balance.CurrentBalance,
                   TransactionDate = x.TransactionHist.TransactionDate
               }).Distinct().ToList();*/


        }

        private List<SecurityModel> _securities;
        public IList<SecurityModel> GetSecurities(List<string> customerIds)
        {
            if (_securities != null && _securities.Any()) return _securities;

            return _securities =
                _db.Securities.Where(x => x.SectionGl == "0121"
                    && customerIds.Contains(x.AccountId))
                    .Select(x => new SecurityModel
                    {
                        AccountId = x.AccountId,
                        StockCode = x.StockCode,
                        Quantity = x.Quantity
                    }).Distinct().ToList();

        }
    }
}