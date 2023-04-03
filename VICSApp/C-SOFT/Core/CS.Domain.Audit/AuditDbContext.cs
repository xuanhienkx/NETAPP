using CS.Domain.Audit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using CS.Common.Std;

namespace CS.Domain.Audit
{
    public class AuditDbContext : DbContext
    {
        private IConfigurationRoot configuration;

        public AuditDbContext(IConfigurationRoot configuration)
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

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(GlobalConstantsProvider.AuditConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventSource>().HasKey(x => x.Id).ForSqlServerIsClustered(false);
            builder.Entity<EventSource>().HasIndex(u => u.CreatedDate).ForSqlServerIsClustered();

            builder.Entity<LoginRequest>();
            builder.Entity<MessageQueue>();
            builder.Entity<CustomerAudit>();

            builder.Entity<CustodyRequestHistory>();
        }
    }
}
