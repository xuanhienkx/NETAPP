using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Reflection;
using System.Resources;
namespace DO.Common
{
    public class LocalizationFactory : IStringLocalizerFactory
    {
        private const string LocalizedResourceBaseName = "CS.Common.Resources.LocalizedText";
        private readonly ILogger<LocalizationFactory> logger;

        private readonly Assembly assembly = typeof(LocalizationFactory).Assembly;
        private readonly IResourceNamesCache resourceNamesCache = new ResourceNamesCache();
        private readonly ConcurrentDictionary<string, IStringLocalizer> localizerCache = new ConcurrentDictionary<string, IStringLocalizer>();

        public LocalizationFactory(ILogger<LocalizationFactory> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            return localizerCache.GetOrAdd(LocalizedResourceBaseName, _ =>
                new ResourceManagerStringLocalizer(
                    new ResourceManager(LocalizedResourceBaseName, assembly),
                    assembly,
                    LocalizedResourceBaseName,
                    resourceNamesCache,
                    logger)
            );
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            if (baseName == null)
                throw new ArgumentNullException(nameof(baseName));

            return localizerCache.GetOrAdd(baseName, _ => new ResourceManagerStringLocalizer(
                new ResourceManager(baseName, assembly),
                assembly,
                baseName,
                resourceNamesCache,
                logger));
        }
    }
}
