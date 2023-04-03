using DO.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DO.Domain.Audit
{
    public class AuditDataInitializer : IDbInitializer
    {
        public string Name { get; } = "Audit data context";

        public async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AuditDbContext>();

                var connection = db.Database.GetDbConnection();
                Console.WriteLine($"[{connection.Database}] connection string: {connection.ConnectionString}");

                await db.Database.MigrateAsync(CancellationToken.None);
            }
        }
    }
}
