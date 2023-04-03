using CS.Common.Contract.Enums;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CS.Domain.Identity
{
    public class IdentityLoginDataInitializer : IDbInitializer
    {
        private readonly ILogger<IdentityLoginDataInitializer> logger;
        private readonly IConfigurationRoot configuration;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;

        public IdentityLoginDataInitializer(IPasswordHasher<ApplicationUser> passwordHasher, IConfigurationRoot configuration, ILogger<IdentityLoginDataInitializer> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public string Name { get; } = "Identity data context";

        public async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<IdentityLoginDbContext>();

                var connection = db.Database.GetDbConnection();
                Console.WriteLine($"[{connection.Database}] connection string: {connection.ConnectionString}");

                await db.Database.MigrateAsync(CancellationToken.None);
                await Seed(db);
            }
        }

        private async Task Seed(IdentityLoginDbContext context)
        {
            var role = await CreateRoleClaims(context);
            await CreateUser(new Guid(GlobalConstantsProvider.CsAdminUniqueId), "admin", "csoft", configuration["security:superAdminEmail"], role, UserRoleType.Admin, context);
            //await CreateUser(new Guid(GlobalConstantsProvider.CsServiceUniqueId), "service", "P@ssw0rdDon0Tu$e", configuration["security:superAdminEmail"], IdentityUserRole.Service, context);
        }

        private async Task<ApplicationRole> CreateRoleClaims(IdentityLoginDbContext context)
        {
            // add application role
            var role = await context.Set<ApplicationRole>().FirstOrDefaultAsync(x => x.Name.Equals(ClaimTypes.Role, StringComparison.OrdinalIgnoreCase));
            if (role == null)
            {
                role = new ApplicationRole(ClaimTypes.Role) { NormalizedName = ClaimTypes.Role.ToUpper() };
                await context.Set<ApplicationRole>().AddAsync(role);
            }

            var roleValues = typeof(UserRoleType).GetEnumNames();
            foreach (var roleValue in roleValues)
            {
                if (context.Set<IdentityRoleClaim<Guid>>().Any(x => x.RoleId == role.Id && x.ClaimValue == roleValue))
                    continue;

                // add role values
                await context.Set<IdentityRoleClaim<Guid>>().AddAsync(new IdentityRoleClaim<Guid>()
                {
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = roleValue,
                    RoleId = role.Id
                });
            }

            return role;
        }

        private async Task CreateUser(Guid id, string userName, string password, string email, ApplicationRole role, UserRoleType roleType, IdentityLoginDbContext context)
        {
            var user = await context.Set<ApplicationUser>().FirstOrDefaultAsync(x => x.Id == id);

            // Add User
            if (user == null)
            {
                logger.LogInformation($"Starting to create default user: {userName} ...");
                
                user = new ApplicationUser
                {
                    Id = id,
                    UserName = userName,
                    NormalizedUserName = userName.ToUpperInvariant(),
                    Email = email,
                    SecurityStamp = id.ToString()
                };
                user.PasswordHash = passwordHasher.HashPassword(user, password);

                await context.Set<ApplicationUser>().AddAsync(user);
                await context.Set<IdentityUserClaim<Guid>>().AddAsync(new IdentityUserClaim<Guid>()
                {
                    ClaimType = role.Name,
                    ClaimValue = roleType.ToString(),
                    UserId = user.Id
                });

                await context.Set<IdentityUserRole<Guid>>().AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });

                if (await context.SaveChangesAsync() > 0)
                {
                    logger.LogInformation($"Created default user: {userName}/{password}");
                }
            }
        }
    }
}
