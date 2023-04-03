using SMS.Data.Services.EF.Repositories.SbsRepositories;

namespace SMS.Data.Services.EF.UnitsOfWork
{
    public interface ISbsUnitOfWork 
    {
        IFirstDayRepository FirstDayRepository { get; }
        IMatchedRepository MatchedRepository { get; }
        IDebitRepository DebitRepository { get; }
        ISbsCustomerRepository CustomerReporsitory { get; }
    }
}