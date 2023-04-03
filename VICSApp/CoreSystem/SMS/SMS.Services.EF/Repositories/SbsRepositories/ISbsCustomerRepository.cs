using SMS.DataAccess.Models;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SbsRepositories
{
    public interface ISbsCustomerRepository
    {
        SmsCustomer GetById(string id);
    }
}