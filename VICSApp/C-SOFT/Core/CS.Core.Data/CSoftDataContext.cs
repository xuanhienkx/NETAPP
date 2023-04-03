using CS.Common.Domain.Interfaces;
using CS.Common.Std;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace CS.Domain.Data
{
    public class CSoftDataContext : DbContext, ICSoftDataContext
    {
        private IConfigurationRoot configuration;

        public CSoftDataContext(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (optionsBuilder.IsConfigured)
                return;

            if (configuration == null)
            {
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(GlobalConstantsProvider.ApplicationSettingFile)
                    .Build();
            }

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(GlobalConstantsProvider.CoreConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasIndex(u => u.Code).IsUnique();
            builder.Entity<AccountBalance>().HasKey(x => x.Id).ForSqlServerIsClustered(false);
            builder.Entity<AccountBalance>().HasIndex(u => u.LastBalancedDate).ForSqlServerIsClustered();
            builder.Entity<AccountBalance>().HasIndex(x => x.AccountId);
            builder.Entity<AccountBalance>().HasIndex(x => x.CustomerAccountId);

            builder.Entity<AccountTransaction>().HasKey(x => x.Id).ForSqlServerIsClustered(false);
            builder.Entity<AccountTransaction>().HasIndex(u => u.TransactionDate).ForSqlServerIsClustered();
            builder.Entity<AccountBlockTransaction>().HasIndex(a => a.AccountBlanceId);

            builder.Entity<Asset>().HasIndex(u => u.Code).IsUnique();
            builder.Entity<Branch>().HasIndex(u => u.BranchCode).IsUnique();
            builder.Entity<BranchSetting>().HasKey(s => new { s.BranchId, s.Key });
            builder.Entity<BranchSetting>().HasOne(x => x.Branch).WithMany(x => x.Settings)
                .HasForeignKey(x => x.BranchId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>().HasIndex(x => x.BranchId);
            builder.Entity<User>().HasIndex(x => x.CreatedByUserId);
            builder.Entity<User>().HasIndex(x => x.ModifiedByUserId);
            builder.Entity<User>().HasIndex(x => x.DepartmentId);

            builder.Entity<BusinessAccountSetting>().HasKey(x => new { x.AccountId, x.BusinessId });
            builder.Entity<BusinessUnit>();

            builder.Entity<Contact>();

            builder.Entity<Customer>().HasIndex(u => u.CustomerNumber).IsUnique();
            builder.Entity<Customer>().HasIndex(u => u.CardIdentity);
            builder.Entity<Customer>().HasIndex(x => x.BranchId);
            builder.Entity<Customer>().HasIndex(x => x.CreatedByUserId);
            builder.Entity<Customer>().HasIndex(x => x.ModifiedByUserId);

            builder.Entity<CustomerAccount>().HasOne(x => x.Customer).WithMany(x => x.CustomerAccounts).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<CustodyRequest>();

            builder.Entity<Department>();
            builder.Entity<Source>();

            builder.Entity<StockPrice>().HasKey(x => x.Id).ForSqlServerIsClustered(false);
            builder.Entity<StockPrice>().HasIndex(e => e.Id).IsUnique(false);
            builder.Entity<StockPrice>().HasIndex(u => u.TradingDate).ForSqlServerIsClustered();

            builder.Entity<TradingDate>();

            builder.Entity<Group>();
            builder.Entity<RightInformation>();
            builder.Entity<Bank>();
            builder.Entity<FileAct>();
            builder.Entity<ExchangeStock>().HasIndex(u => u.VsdBoardCode).IsUnique();
            builder.Entity<ExchangeStock>().HasIndex(u => u.BoardType).IsUnique();
            builder.Entity<Permission>();

            builder.Entity<UserGroup>().HasKey(x => new { x.UserId, x.GroupId });
            builder.Entity<UserGroup>().HasOne(x => x.User).WithMany(x => x.Groups)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserGroup>().HasOne(x => x.Group).WithMany(x => x.Users)
                .HasForeignKey(x => x.GroupId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public async Task<IDbContextTransaction> StartTransaction()
        {
            return await Database.BeginTransactionAsync();
        }
    }
}
