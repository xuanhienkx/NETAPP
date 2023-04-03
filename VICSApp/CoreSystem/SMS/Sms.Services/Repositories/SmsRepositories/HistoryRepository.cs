using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SMS.Common;
using SMS.Common.Configuration;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ISmsDataContext _smsContext;
        private readonly ILogger _logger;
        private readonly DbContext _context;
        public HistoryRepository(ISmsDataContext smsContext, ILogger logger)
        {
            if (smsContext == null) throw new ArgumentNullException("smsContext");
            if (logger == null) throw new ArgumentNullException("logger");
            _smsContext = smsContext;
            _logger = logger;
            _context = (DbContext)_smsContext;
        }

        public int BackupToHistory()
        {
            try
            {
                return _context.Database.ExecuteSqlCommand("Backup_Firstday_Hist @OrderDate",
                      new SqlParameter("@OrderDate", DateTime.Today.ToString("dd/MM/yyyy")));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception);
                return 0;
            }
        }

        private void Backup()
        {

        }

        public bool IsNeedBackup
        {
            get
            {
                try
                {
                    var currentDate = SmsConfiguration.Current.TimeExecuteConfig.TransactionDate;
                    var orderDate = currentDate.ToString("dd/MM/yyyy");
                    var rq = _smsContext.Requests.Any(r => r.OrderDate != orderDate);
                    var tr = _smsContext.TradingResults.Any(r => r.OrderDate != orderDate);
                    var debit = _smsContext.TransactionDays.Any(r => r.TransactionDate != SmsConfiguration.Current.TimeExecuteConfig.TransactionDate);
                    return rq || tr || debit;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex);
                    throw;
                }
            }
        }
    }
}