using CS.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using CS.Common.Std;

namespace CS.Domain.Identity
{
    public class IdentityLoginDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private IConfigurationRoot configuration;

        public IdentityLoginDbContext(IConfigurationRoot configuration)
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

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(GlobalConstantsProvider.SecurityConnectionString));
        }
    }
}
