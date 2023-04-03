using System.Collections.Generic;
using System.Threading.Tasks;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.EF.Repositories.SbsRepositories
{
    public interface IDebitRepository
    {
        List<TransactionDay> GetAllSbsDebit();
        decimal CurrentBalance(string customerId);
    }
}