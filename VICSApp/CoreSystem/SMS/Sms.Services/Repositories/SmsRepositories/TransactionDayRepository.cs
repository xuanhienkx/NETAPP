using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class TransactionDayRepository : Repository<SmsTransactionDay>, ITransactionDayRepository
    {
        private readonly ISmsDataContext _smsDataContext;

        public TransactionDayRepository(ISmsDataContext smsDataContext)
            : base(smsDataContext as DbContext)
        {
            _smsDataContext = smsDataContext;
        }


        public async Task<IList<SmsTransactionDay>> GetAllNeedBuildAsync()
        {
            return await _smsDataContext.TransactionDays.Where(x => x.IsBuild == false).ToListAsync();
        }

        public IList<SmsTransactionDay> GetAllNeedBuild()
        {
           return _smsDataContext.TransactionDays.Where(x => x.IsBuild == false).ToList();
        }

        public void SetBuilded(IList<SmsTransactionDay> list)
        {
            foreach (var trans in list)
            {
                trans.IsBuild = true;
                Update(trans);
            }
        }
    }
}