using api.common.Shared.Interfaces;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using api.common.Settings;
using Microsoft.Extensions.Logging;

namespace api.common.Shared.Base
{
    public abstract class PersistentService<TComponent> : IPersistentService<TComponent>, IDisposable where TComponent : IPersistentService<TComponent>
    {
        private readonly ILogger logger;
        private readonly Lazy<IMongoDatabase> dbLazy;
        private readonly Lazy<IMongoClient> clientLazy;
        private string requestPath;

        public bool HasSession => Session != null;
        public IClientSessionHandle Session { get; private set; }

        protected PersistentService(DatabaseSettings dbSettings, ILogger logger)
        {
            if (dbSettings == null) throw new ArgumentNullException(nameof(dbSettings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            logger.LogDebug($"[{dbSettings.DatabaseName}] -> {dbSettings.ConnectionString}");

            clientLazy = new Lazy<IMongoClient>(() => new MongoClient(new MongoUrl(dbSettings.ConnectionString)));
            dbLazy = new Lazy<IMongoDatabase>(() => clientLazy.Value.GetDatabase(dbSettings.DatabaseName));
        }

        public abstract IMongoCollection<T> GetCollection<T>() where T : IPersistentEntity;
        public IMongoDatabase Database => dbLazy.Value;

        public async Task StartSession(string path)
        {
            logger.LogDebug("[requestPath] - " + requestPath);

            if (Session != null)
                return;

            logger.LogInformation("[START SESSION] - " + path);
            requestPath = path;

            Session = await clientLazy.Value.StartSessionAsync();
            Session.StartTransaction();
        }

        public async Task Rollback(string path)
        {
            if (Session == null || !requestPath.Equals(path))
                return;

            logger.LogInformation("[ROLLBACK SESSION] - " + path);

            await Session.AbortTransactionAsync();
            Dispose();
        }

        public async Task Commit(string path)
        {
            if (Session == null || !requestPath.Equals(path))
                return;

            logger.LogInformation("[COMMIT SESSION] - " + path);

            await Session.CommitTransactionAsync();
            Dispose();
        }

        public void Dispose()
        {
            requestPath = string.Empty;
            if (Session == null)
                return;

            logger.LogDebug("Dispose");

            //Session?.Dispose();
            Session = null;
        }
    }
}
