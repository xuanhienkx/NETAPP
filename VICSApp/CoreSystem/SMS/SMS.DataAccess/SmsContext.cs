using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using SMS.DataAccess.Models;

namespace SMS.DataAccess
{
    public class SmsContext : DbContext
    {
        public SmsContext()
            : base("name=SMSContext")
        {
            //Database.SetInitializer<SmsContext>(new CreateDatabaseIfNotExists<SmsContext>());
             //Database.SetInitializer<SmsContext>(new DropCreateDatabaseIfModelChanges<SmsContext>());
            Database.SetInitializer<SmsContext>(new DropCreateDatabaseAlways<SmsContext>());
            // Database.SetInitializer<SmsContext>(new SmsDBInitializer());
             
        }

        public DbSet<SmsCustomer> Customers { get; set; }
        public DbSet<SmsTradingResult> TradingResults { get; set; }
        public DbSet<SmsRequest> Requests { get; set; }
        public DbSet<SmsLogOut> LogOuts { get; set; } 
        public DbSet<SmsRequestHist> RequestHists { get; set; }
        public DbSet<SmsLogOutHist> LogOutHists { get; set; }
        public DbSet<SmsTradingResultHist> TradingResultHists { get; set; }
        public DbSet<SmsTransactionDay> TransactionDays { get; set; }
        public DbSet<SmsTransactionDayHist> TransactionDayHists { get; set; }
        public DbSet<SmsStatusResult> StatusResults { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}