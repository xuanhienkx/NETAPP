using System.Data.Entity;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Contexts
{
    public interface ISmsDataContext
    {
        IDbSet<SmsCustomer> Customers { get; set; }
        IDbSet<SmsLogOutHist> LogOutHists { get; set; }
        IDbSet<SmsLogOut> LogOuts { get; set; }
        IDbSet<SmsRequestHist> RequestHists { get; set; }
        IDbSet<SmsRequest> Requests { get; set; }
        IDbSet<SmsTradingResultHist> TradingResultHists { get; set; }
        IDbSet<SmsTradingResult> TradingResults { get; set; } 
        IDbSet<SmsTransactionDay> TransactionDays { get; set; }
        IDbSet<SmsTransactionDayHist> TransactionDayHists { get; set; }
        IDbSet<SmsStatusResult> SmsStatusResults { get; set; }
    }
}