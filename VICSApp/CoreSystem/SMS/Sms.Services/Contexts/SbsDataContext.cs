using System.Data.Entity;
using System.Reflection;
using SMS.SBSAccess.Models;

namespace SMS.Data.Services.Contexts
{
    public partial class SbsDataContext : DbContext, ISbsDataContext
    {
        static SbsDataContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<SbsDataContext>());
            //System.Data.Entity.Database.SetInitializer();
        }

        public SbsDataContext()
            : base("name=SBSContext")
        { 
            Configuration.LazyLoadingEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public IDbSet<Balance> Balances { get; set; }
        public IDbSet<BalanceHist> BalanceHists { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Security> Securities { get; set; }
        public IDbSet<StockOrder> StockOrders { get; set; }
        public IDbSet<TradingOrder> TradingOrders { get; set; }
        public IDbSet<TradingResult> TradingResults { get; set; }
        public IDbSet<TradingResultHist> TradingResultHists { get; set; }
        public IDbSet<TransactionDay> TransactionDays { get; set; }
        public IDbSet<TransactionHist> TransactionHists { get; set; }
        public IDbSet<TransDate> TransDates { get; set; }
        public IDbSet<TransDateHist> TransDateHists { get; set; }
        public IDbSet<SecuritiesHist> SecuritiesHists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(SbsDataContext)));
        }
        partial void ModelCreating(DbModelBuilder modelBuilder);
    }
}