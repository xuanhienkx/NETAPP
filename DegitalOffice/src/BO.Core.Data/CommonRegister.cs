using AutoMapper;
using BO.Core.DataCommon.AutoMapper;
using BO.Core.DataCommon.Settings;
using BO.Core.DataCommon.Shared;
using BO.Core.DataCommon.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BO.Core.DataCommon
{
    public static class CommonRegister
    {
        public static void Register(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPersistentDataProvider, PersistentDataProvider>();
            services.AddSingleton<IWebSocketService, WebSocketService>();

            // auto mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntityToModelMappingProfile());
                mc.AddProfile(new ModelToEntityMappingProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            // configuration
            services.Configure<ApplicationSettings>(config.GetSection(nameof(ApplicationSettings)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IJwtTokenIssuer, JwtTokenIssuer>();
            services.AddSingleton<ICipherService, AesCipherService>();

            // Scope
            services.AddScoped<IMultipartConsumer, MultipartConsumer>();
        }
    }
}
