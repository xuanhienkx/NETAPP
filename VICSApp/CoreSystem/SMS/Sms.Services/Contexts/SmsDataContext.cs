using System.Data.Entity;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Contexts
{
    public partial class SmsDataContext : DbContext, ISmsDataContext
    {
        static SmsDataContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<SmsDataContext>());
        }

        public SmsDataContext()
            : base("name=SMSContext")
        { 
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;
        }


        public IDbSet<SmsCustomer> Customers { get; set; }
        public IDbSet<SmsLogOutHist> LogOutHists { get; set; }
        public IDbSet<SmsLogOut> LogOuts { get; set; }
        public IDbSet<SmsRequestHist> RequestHists { get; set; }
        public IDbSet<SmsRequest> Requests { get; set; }
        public IDbSet<SmsTradingResultHist> TradingResultHists { get; set; }
        public IDbSet<SmsTradingResult> TradingResults { get; set; } 
        public IDbSet<SmsTransactionDay> TransactionDays { get; set; }
        public IDbSet<SmsTransactionDayHist> TransactionDayHists { get; set; }
        public IDbSet<SmsStatusResult> SmsStatusResults { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(SmsDataContext)));
        }

        partial void ModelCreating(DbModelBuilder modelBuilder); 

    }
}