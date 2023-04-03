using System; 
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using SMS.Business.Service.Services;
using SMS.Common;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Exceptions;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.Data.Services.EF.UnitsOfWork; 

namespace SMS.Data.Services.UnitsOfWork
{
    public class SmsUnitOfWork : UnitOfWork, ISmsUnitOfWork
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITradingResultRepository _tradingResultRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly ILogOutRepository _logOutRepository;
        private readonly ITransactionDayRepository _transactionDayRepository; 
        private readonly ILogOutHistRepository _logOutHistRepository;
        private readonly IRequestHistRepository _requestHistRepository;
        private readonly ITradingResultHistRepository _tradingResultHistRepository;
        private readonly ITransactionDayHistRepository _transactionDayHistRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly IStatusResultRepository _statusResultRepository;
        private readonly ILogger _logger;

        public SmsUnitOfWork(ISmsDataContext smsContext, ICustomerRepository customerRepository,
            ITradingResultRepository tradingResultRepository,
            IRequestRepository requestRepository, ILogOutRepository logOutRepository,
            ITransactionDayRepository transactionDayRepository, 
            ILogOutHistRepository logOutHistRepository, IRequestHistRepository requestHistRepository,
            ITradingResultHistRepository tradingResultHistRepository,
            ITransactionDayHistRepository transactionDayHistRepository, IHistoryRepository historyRepository,
            IStatusResultRepository statusResultRepository, ILogger logger)
            : base(smsContext as DbContext)
        {
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");
            if (tradingResultRepository == null) throw new ArgumentNullException("tradingResultRepository");
            if (requestRepository == null) throw new ArgumentNullException("requestRepository");
            if (transactionDayRepository == null) throw new ArgumentNullException("transactionDayRepository"); 
            if (logOutHistRepository == null) throw new ArgumentNullException("logOutHistRepository");
            if (requestHistRepository == null) throw new ArgumentNullException("requestHistRepository");
            if (tradingResultHistRepository == null) throw new ArgumentNullException("tradingResultHistRepository");
            if (transactionDayHistRepository == null) throw new ArgumentNullException("transactionDayHistRepository");
            if (historyRepository == null) throw new ArgumentNullException("historyRepository");
            if (statusResultRepository == null) throw new ArgumentNullException("statusResultRepository");
            if (logger == null) throw new ArgumentNullException("logger");

            _customerRepository = customerRepository;
            _tradingResultRepository = tradingResultRepository;
            _requestRepository = requestRepository;
            _logOutRepository = logOutRepository;
            _transactionDayRepository = transactionDayRepository; 
            _logOutHistRepository = logOutHistRepository;
            _requestHistRepository = requestHistRepository;
            _tradingResultHistRepository = tradingResultHistRepository;
            _transactionDayHistRepository = transactionDayHistRepository;
            _historyRepository = historyRepository;
            _statusResultRepository = statusResultRepository;
            _logger = logger;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                _logger.LogError(concurrencyException);
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                _logger.LogError(updateException);
                throw new UpdateException(updateException.Message,
                    updateException);
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                _logger.LogError(concurrencyException);
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                _logger.LogError(updateException);
                throw new UpdateException(updateException.Message,
                    updateException);
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository; }
        }

        public ITradingResultRepository TradingResultRepository
        {
            get { return _tradingResultRepository; }
        }

        public IRequestRepository RequestRepository
        {
            get { return _requestRepository; }
        }

        public ILogOutRepository LogOutRepository
        {
            get { return _logOutRepository; }
        }

        public ITransactionDayRepository TransactionDayRepository
        {
            get { return _transactionDayRepository; }
        }

        
        public ILogOutHistRepository LogOutHistRepository
        {
            get { return _logOutHistRepository; }
        }

        public IRequestHistRepository RequestHistRepository
        {
            get { return _requestHistRepository; }
        }

        public ITradingResultHistRepository TradingResultHistRepository
        {
            get { return _tradingResultHistRepository; }
        }

        public ITransactionDayHistRepository TransactionDayHistRepository
        {
            get { return _transactionDayHistRepository; }
        }


        public IHistoryRepository HistoryRepository
        {
            get { return _historyRepository; }
        }

        public IStatusResultRepository StatusResultRepository { get { return _statusResultRepository; }}
    }
}