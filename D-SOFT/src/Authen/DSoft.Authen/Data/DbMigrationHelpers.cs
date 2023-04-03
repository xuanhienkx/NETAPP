using Microsoft.EntityFrameworkCore;

namespace DSoft.Authen.Data
{
    public static class DbMigrationHelpers
    {
        public static async Task<bool> EnsureDatabasesMigratedAsync<TIdentityDbContext, TConfigurationDbContext, TPersistedGrantDbContext, TLogDbContext, TAuditLogDbContext, TDataProtectionDbContext>(IServiceProvider services)
            where TIdentityDbContext : DbContext
            where TPersistedGrantDbContext : DbContext
            where TConfigurationDbContext : DbContext
            where TLogDbContext : DbContext
            where TAuditLogDbContext : DbContext
            where TDataProtectionDbContext : DbContext
        {
            int pendingMigrationCount = 0;
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<TPersistedGrantDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TIdentityDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TConfigurationDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TLogDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TAuditLogDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }

                using (var context = scope.ServiceProvider.GetRequiredService<TDataProtectionDbContext>())
                {
                    await context.Database.MigrateAsync();
                    pendingMigrationCount += (await context.Database.GetPendingMigrationsAsync()).Count();
                }
            }

            return pendingMigrationCount == 0;
        }

    }
}
