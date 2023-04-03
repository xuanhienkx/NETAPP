using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CS.Domain.Data
{
    public class CSoftDataInitializer : IDbInitializer
    {
        private readonly IConfigurationRoot configuration;
        private readonly ILogger<CSoftDataInitializer> logger;

        public CSoftDataInitializer(IConfigurationRoot configuration, ILogger<CSoftDataInitializer> logger)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string Name { get; } = "Core data context";

        public async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<CSoftDataContext>();

                var connection = db.Database.GetDbConnection();
                Console.WriteLine($"[{connection.Database}] connection string: {connection.ConnectionString}");

                await db.Database.MigrateAsync(CancellationToken.None);
                await Seed(db);
            }
        }

        private async Task Seed(CSoftDataContext context)
        {
            Console.WriteLine("Initialize data");

            var adminId = new Guid(GlobalConstantsProvider.CsAdminUniqueId);
            var user = await context.Set<User>().FirstOrDefaultAsync(x => x.Id == adminId);
            if (user != null)
                return;

            var admin = new User
            {
                Id = adminId,
                FullName = "Administrator",
                Email = configuration["security:superAdminEmail"],
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                AccountLogin = "admin",
                UserType = UserType.Manager,
                Branch = new Branch
                {
                    BranchName = "Root",
                    BranchCode = "---"
                }
            };

            context.Set<User>().Add(admin);
            await context.SaveChangesAsync();

            logger.LogInformation("Administrator is created!");

            var hashExchanges = await context.Set<ExchangeStock>().AnyAsync();
            if (hashExchanges)
                return;
            var exs = new List<ExchangeStock>
            {
                new ExchangeStock
                {
                    BoardType = BoardType.Hnx,
                    VsdBoardCode = BoardType.Hnx.DisplayName(),
                    ShortName = BoardType.Hnx.ToString().ToUpper(),
                    FullName = "HANOI STOCK EXCHANGE"
                },
                new ExchangeStock
                {
                    BoardType = BoardType.Hose,
                    VsdBoardCode = BoardType.Hose.DisplayName(),
                    ShortName = BoardType.Hose.ToString().ToUpper(),
                    FullName = "HOCHIMINH STOCK EXCHANGE"

                },
                new ExchangeStock
                {
                    BoardType = BoardType.Upcom,
                    VsdBoardCode = BoardType.Upcom.DisplayName(),
                    ShortName = BoardType.Upcom.ToString().ToUpper(),
                    FullName = "HANOI STOCK EXCHANGE (UNLISTED PUBLIC COMPANY TRADING PLATFORM) "

                },
                new ExchangeStock
                {
                    BoardType = BoardType.Dccny,
                    VsdBoardCode = BoardType.Dccny.DisplayName(),
                    ShortName = BoardType.Dccny.ToString().ToUpper(),
                    FullName = "OTC (sàn 0007-DCCNY)"
                }
            };
            context.Set<ExchangeStock>().AddRange(exs);
            await context.SaveChangesAsync();
            logger.LogInformation("ExchangeStock is created!");
        }
    }
}
