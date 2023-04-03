using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SmsRepositories
{
    public interface IRequestRepository : IRepository<SmsRequest>, IRepositoryAsync<SmsRequest>
    {
        IList<SmsRequest> GetAllNeedSend();
        Task<IList<SmsRequest>> GetAllNeedSendAsync();
        void SetSended(IList<SmsRequest> list);
        void InsertRequest(SmsRequest entity);
    }
}