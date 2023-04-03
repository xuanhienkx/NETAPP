using System;

namespace CS.UI.Common.Service
{
    public class ServicelocatorProvider : IServiceProvider
    {
        private readonly Func<Type, object> getInstance;

        public ServicelocatorProvider(Func<Type, object> getInstance)
        {
            this.getInstance = getInstance ?? throw new ArgumentNullException(nameof(getInstance));
        }

        public object GetService(Type serviceType)
        {
            return getInstance(serviceType);
        }
    }
}
