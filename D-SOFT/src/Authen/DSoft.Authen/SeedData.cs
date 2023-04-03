using DSoft.Authen.Data;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DSoft.Authen;

public class SeedData
{
    public static async Task EnsureSeedData(string connectionString)
    {

        var services = new ServiceCollection();
        services.AddLogging();
        services.AddDbContext<AdminIdentityDbContext>(
            options => options.UseSqlServer(connectionString)
        );

        services
            .AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AdminIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddOperationalDbContext(
            options =>
            {
                options.ConfigureDbContext = db =>
                    db.UseSqlServer(
                        connectionString,
                        sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
                    );
            }
        );
        services.AddConfigurationDbContext(
            options =>
            {
                options.ConfigureDbContext = db =>
                    db.UseSqlServer(
                        connectionString,
                        sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
                    );
            }
        );

        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

        await scope.ServiceProvider.GetRequiredService<AdminIdentityDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();
        var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        await context.Database.MigrateAsync();

        await EnsureSeedData(context);

        await EnsureUsers(scope);
    }

    private static async Task EnsureUsers(IServiceScope scope)
    {
        var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var admin = await userMgr.FindByNameAsync("admin");
        if (admin == null)
        {
            admin = new IdentityUser
            {
                UserName = "admin",
                Email = "dsoft@email.com",
                EmailConfirmed = true
            };
            var result = userMgr.CreateAsync(admin, "Phap@1234").Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            result =
                userMgr.AddClaimsAsync(
                    admin,
                    new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, "Xuan Phap"),
                        new Claim(JwtClaimTypes.GivenName, "Nguyen"),
                        new Claim(JwtClaimTypes.FamilyName, "XuanPhap"),
                        new Claim(JwtClaimTypes.WebSite, "http://dsoft.com"),
                        new Claim("location", "somewhere")
                    }
                ).Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }

    private static async Task EnsureSeedData(ConfigurationDbContext context)
    {
        if (!context.Clients.Any())
        {
            foreach (var client in Config.Clients.ToList())
            {
                await context.Clients.AddAsync(client.ToEntity());
            }


            await context.SaveChangesAsync();
        }

        if (!context.IdentityResources.Any())
        {
            foreach (var resource in Config.IdentityResources.ToList())
            {
                await context.IdentityResources.AddAsync(resource.ToEntity());
            }


            await context.SaveChangesAsync();
        }

        if (!context.ApiScopes.Any())
        {
            foreach (var resource in Config.ApiScopes.ToList())
            {
                await context.ApiScopes.AddAsync(resource.ToEntity());
            }


            await context.SaveChangesAsync();
        }

        if (!context.ApiResources.Any())
        {
            foreach (var resource in Config.ApiResources.ToList())
            {
                await context.ApiResources.AddAsync(resource.ToEntity());
            }

            await context.SaveChangesAsync();
        }
    }
}
