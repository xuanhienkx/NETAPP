using DO.Common.Std;
using DO.Domain.Audit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DO.Domain.Audit
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
            builder.Entity<EventSource>().HasKey(x => x.Id).IsClustered(false);
            builder.Entity<EventSource>().HasIndex(u => u.CreatedDate).IsClustered();

            builder.Entity<LoginRequest>();
            builder.Entity<MessageQueue>();
            builder.Entity<CustomerAudit>();

            builder.Entity<MarketRequestHistory>();
        }
    }
}
