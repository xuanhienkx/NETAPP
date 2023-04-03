using System.Data.Entity;
using SMS.SBSAccess.Models;

namespace SMS.SBSAccess
{
    public class SBSContext : DbContext
    {
        public SBSContext()
            : base("name=SBSContext")
        {
        }

        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<BalanceHist> BalanceHists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<StockOrder> StockOrders { get; set; }
        public virtual DbSet<TradingOrder> TradingOrders { get; set; }
        public virtual DbSet<TradingResult> TradingResults { get; set; }
        public virtual DbSet<TransactionDay> TransactionDays { get; set; }
        public virtual DbSet<TransactionHist> TransactionHists { get; set; }
        public virtual DbSet<TransDate> TransDates { get; set; }
        public virtual DbSet<TransDateHist> TransDateHists { get; set; }
        public virtual DbSet<SecuritiesHist> SecuritiesHists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.BeginCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.BeginDay)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.YearDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.YearCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.MonthDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.MonthCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.DayDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.DayCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Balance>()
                .Property(e => e.DebitOrCredit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Balance>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.BeginCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.BeginDay)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.YearDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.YearCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.MonthDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.MonthCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.DayDebit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.DayCredit)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.DebitOrCredit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BalanceHist>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ContractNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerId)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.DomesticForeign)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CardIdentity)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CardIssuer)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mobile2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AccountStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.AccountType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.OrderType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ReceiveReport)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ReceiveReportBy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MarriageStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.KnowledgeLevel)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Job)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.OfficeTel)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.OfficeFax)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.HusbandWifeCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.JoinStockMarket)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.InvestKnowledge)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.InvestedIn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.InvestTarget)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.RiskAccepted)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.InvestFund)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.DelegatePersonCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.DelegatePersonTel)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ChiefAccountancyCI)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ChiefAccountancyIssuer)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CaProxyCI)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CaProxyIssuer)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MobileSms)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MoneyDepositeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ParentCompanyTel)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<Security>()
                .Property(e => e.StockCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderTime)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderSide)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.BoardType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.StockCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderValue)
                .HasPrecision(28, 0);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.CustomerId)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.CustomerBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.CustomerTradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.ReceivedBy)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.ApprovedBy)
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.OrderStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.AlertCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.IcebergVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<StockOrder>()
                .Property(e => e.StopPx)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderTime)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderType)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderSide)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.BoardType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.StockCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.StockType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.CustomerId)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.CustomerBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.CustomerTradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.PcFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.OrderStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.MatchedVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.MatchedValue)
                .HasPrecision(28, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.FeeRate)
                .HasPrecision(10, 5);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.PublishedVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.PublishedPrice)
                .HasPrecision(18, 1);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.CancelledVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.IcebergVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingOrder>()
                .Property(e => e.StopPx)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.OrderDate)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.ConfirmNo)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.ConfirmTime)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.OrderSide)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.CustomerId)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.CustomerBranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.CustomerTradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.BoardType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.StockCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.StockType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.MatchedVolume)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.MatchedPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.MatchedValue)
                .HasPrecision(28, 0);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.FeeRate)
                .HasPrecision(10, 5);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.IsCross)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.ClearingCode)
                .IsUnicode(false);

            modelBuilder.Entity<TradingResult>()
                .Property(e => e.DeferredAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.BranchCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.TransactionNumber)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.TransactionCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.DebitOrCredit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.Approved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.Approver)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.DepartmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionDay>()
                .Property(e => e.ClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.TransactionNumber)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.TransactionCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.DebitOrCredit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.Approved)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.Approver)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.TradeCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.DepartmentCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHist>()
                .Property(e => e.ClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<TransDate>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransDateHist>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransDateHist>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransDateHist>()
                .Property(e => e.StartUsername)
                .IsUnicode(false);

            modelBuilder.Entity<TransDateHist>()
                .Property(e => e.EndUsername)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.BankGl)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.SectionGl)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<SecuritiesHist>()
                .Property(e => e.StockCode)
                .IsUnicode(false);
        }
    }
}