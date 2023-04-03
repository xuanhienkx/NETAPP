using System.Data.Entity;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class LogOutRepository : Repository<SmsLogOut>, ILogOutRepository
    {
        private readonly ISmsDataContext _smsDataContext;

        public LogOutRepository(ISmsDataContext smsDataContext):base(smsDataContext as DbContext)
        {
            _smsDataContext = smsDataContext;
        }
    }
}