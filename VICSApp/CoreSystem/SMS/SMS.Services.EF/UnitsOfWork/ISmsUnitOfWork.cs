using SMS.Data.Services.EF.Repositories.SmsRepositories;

namespace SMS.Data.Services.EF.UnitsOfWork
{
    public interface ISmsUnitOfWork : IUnitOfWork, IUnitOfWorkAsync
    {
        ICustomerRepository CustomerRepository { get; }
        ITradingResultRepository TradingResultRepository { get; }
        IRequestRepository RequestRepository { get; }
        ILogOutRepository LogOutRepository { get; }
        ITransactionDayRepository TransactionDayRepository { get; } 
        ILogOutHistRepository LogOutHistRepository { get; }
        IRequestHistRepository RequestHistRepository { get; }
        ITradingResultHistRepository TradingResultHistRepository { get; }
        ITransactionDayHistRepository TransactionDayHistRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        IStatusResultRepository StatusResultRepository { get; }
    }
}