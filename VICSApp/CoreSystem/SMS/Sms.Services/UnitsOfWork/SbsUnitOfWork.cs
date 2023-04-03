using System; 
using SMS.Data.Services.EF.Repositories.SbsRepositories;
using SMS.Data.Services.EF.UnitsOfWork;

namespace SMS.Data.Services.UnitsOfWork
{
    public class SbsUnitOfWork : ISbsUnitOfWork
    {
        private readonly IFirstDayRepository _firstDayRepository;
        private readonly IMatchedRepository _matchedRepository;
        private readonly IDebitRepository _debitRepository;
        private readonly ISbsCustomerRepository _customerReporsitory;

        public SbsUnitOfWork(IFirstDayRepository firstDayRepository, IMatchedRepository matchedRepository, IDebitRepository debitRepository, ISbsCustomerRepository customerReporsitory)
        {
            if(firstDayRepository==null) throw new ArgumentNullException("firstDayRepository");
            if(matchedRepository==null) throw new ArgumentNullException("matchedRepository");
            if (debitRepository == null) throw new ArgumentNullException("debitRepository");
            if (customerReporsitory == null) throw new ArgumentNullException("customerReporsitory");
            this._firstDayRepository = firstDayRepository;
            _matchedRepository = matchedRepository;
            _debitRepository = debitRepository;
            _customerReporsitory = customerReporsitory;
        }


        public IFirstDayRepository FirstDayRepository
        {
            get { return _firstDayRepository; }
        }

        public IMatchedRepository MatchedRepository
        {
            get { return _matchedRepository; }
        }

        public IDebitRepository DebitRepository
        {
            get { return _debitRepository; }
        }

        public ISbsCustomerRepository CustomerReporsitory
        {
            get { return _customerReporsitory; }
        }
    }
}