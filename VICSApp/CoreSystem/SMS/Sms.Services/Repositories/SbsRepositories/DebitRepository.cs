using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SbsRepositories;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Repositories.SbsRepositories
{
    public class DebitRepository : IDebitRepository
    {
        private readonly ISbsDataContext _db;
        private readonly ISmsDataContext _sms;
        private readonly ILogger _logger;
        DateTime transactionDate = SmsConfiguration.Current.TimeExecuteConfig.TransactionDate;


        public DebitRepository(ISbsDataContext sbsDataContext, ISmsDataContext smsDataContext, ILogger logger)
        {
            if (sbsDataContext == null) throw new ArgumentNullException("sbsDataContext");
            if (smsDataContext == null) throw new ArgumentNullException("smsDataContext");
            if (logger == null) throw new ArgumentNullException("logger");
            _db = sbsDataContext;
            _sms = smsDataContext;
            _logger = logger;
        }

        public List<TransactionDay> GetAllSbsDebit()
        {
            var bankGl = SmsConfiguration.Current.BaseConfig.BankGl;
            var lastTime = LastTimeInsert;
            var transactionNumbers =
            _db.TransactionDays.Where(
                x =>
                   x.TransactionTime.HasValue && x.TransactionTime.Value >= lastTime && bankGl.Contains(x.BankGl.Substring(0, 3)) &&
                    x.SectionGl.Equals("9999") && x.Approved != "X").Select(x => x.TransactionNumber).ToList();
            if (!transactionNumbers.Any())
                return null;
            var exitsNumbers = ExistsTransactionNumber;
            transactionNumbers = transactionNumbers.Where(x => !exitsNumbers.Contains(x)).ToList();
            var listDb = _db.TransactionDays.Where(x => transactionNumbers.Contains(x.TransactionNumber) && x.Approved != "X" && x.TransactionTime.Value >= lastTime).ToList();
            return listDb;

        } 
        public decimal CurrentBalance(string customerId)
        {
            var balance = _db.Balances.FirstOrDefault(x => x.AccountId.Equals(customerId)
                                                           &&// x.LastDate.Value == transactionDate &&
                                                           x.BankGl.Equals("324111"));
            if (balance != null)
                return balance.CurrentBalance;
            _logger.Log("Not found balance to day of customer :" + customerId);
            return 0M;
        }

        private DateTime LastTimeInsert
        {
            get
            {
                var smsTransactionDay = _sms.TransactionDays.OrderByDescending(x => x.TransactionTime).FirstOrDefault(x => x.TransactionDate == transactionDate);
                if (smsTransactionDay != null)
                {
                    transactionDate = smsTransactionDay.TransactionTime;
                }
                return transactionDate;
            }
        }

        private List<string> ExistsTransactionNumber
        {
            get { return _sms.TransactionDays.Select(x => x.TransactionNumber).ToList(); }
        }
    }
}