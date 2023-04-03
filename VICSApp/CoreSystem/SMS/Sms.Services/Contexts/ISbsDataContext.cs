using System.Data.Entity;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Contexts
{
    public interface ISbsDataContext
    {
        IDbSet<Balance> Balances { get; set; }
        IDbSet<BalanceHist> BalanceHists { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Security> Securities { get; set; }
        IDbSet<StockOrder> StockOrders { get; set; }
        IDbSet<TradingOrder> TradingOrders { get; set; }
        IDbSet<TradingResult> TradingResults { get; set; }
        IDbSet<TradingResultHist> TradingResultHists { get; set; }
        IDbSet<TransactionDay> TransactionDays { get; set; }
        IDbSet<TransactionHist> TransactionHists { get; set; }
        IDbSet<TransDate> TransDates { get; set; }
        IDbSet<TransDateHist> TransDateHists { get; set; }
        IDbSet<SecuritiesHist> SecuritiesHists { get; set; }
    }
}