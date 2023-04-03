using api.common.Models;
using api.common.Models.Identity;
using api.domain.Services;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using api.common;
using api.common.Settings;
using api.common.Shared.Interfaces;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.domain
{
    public class MigrationData
    {
        private static bool _initialized = false;
        private static object _initializationLock = new object();
        private static object _initializationTarget;
        private readonly UserManager<IdentityUser> userManager;
        private readonly DatabaseSettings dbSettings;

        private MigrationData(UserManager<IdentityUser> userManager, DatabaseSettings dbSettings)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }

        public static async Task SeedData(UserManager<IdentityUser> userManager, DatabaseSettings dbSettings)
        {
            // check if user exists
            var admin = await userManager.FindByNameAsync("admin");
            if (admin == null)
                await new MigrationData(userManager, dbSettings).EnsureSeedDataAsync();
        }

        private async Task EnsureSeedDataAsync()
        {
            var obj = LazyInitializer.EnsureInitialized(ref _initializationTarget, ref _initialized, ref _initializationLock, EnsureSeedDataImplAsync);

            if (obj != null)
            {
                var taskToAwait = (Task)obj;
                await taskToAwait.ConfigureAwait(false);
            }
        }

        private async Task EnsureSeedDataImplAsync()
        {
            var indexNames = new
            {
                UniqueEmail = "identity_email_unique",
                Login = "identity_logins_loginProvider_providerKey"
            };

            ConventionRegistry.Lookup(typeof(CamelCaseElementNameConvention));

            var emailKeyBuilder = Builders<IdentityUser>.IndexKeys.Ascending(user => user.Email.Value);
            var loginKeyBuilder = Builders<IdentityUser>.IndexKeys.Ascending("logins.loginProvider").Ascending("logins.providerKey");

            var usersCollection = new MongoClient(dbSettings.ConnectionString).GetDatabase(dbSettings.DatabaseName).GetCollection<IdentityUser>(ProviderConstants.UserCollectionName);

            var tasks = new[]
            {
                usersCollection.Indexes.CreateOneAsync(new CreateIndexModel<IdentityUser>(emailKeyBuilder, new CreateIndexOptions { Unique = true, Name = indexNames.UniqueEmail })),
                usersCollection.Indexes.CreateOneAsync(new CreateIndexModel<IdentityUser>(loginKeyBuilder, new CreateIndexOptions { Name = indexNames.Login })),
                SeedUsers()
        };

            await Task.WhenAll(tasks).ConfigureAwait(true);
        }

        private async Task SeedUsers()
        {
            var emailConfirm = new IdentityUserEmail("admin@skylar-tech.com");
            emailConfirm.SetNormalizedEmail(userManager.NormalizeEmail(emailConfirm.Value));
            emailConfirm.SetConfirmed();

            // create sa user
            var user = new IdentityUser(emailConfirm.Value, "Admin") {UserName = "admin"};
            var result = await userManager.CreateAsync(user, "P@ssw0rd");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, AccountRole.MODERATOR.ToString());
        }
    }
}
