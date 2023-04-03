using AutoMapper;
using CS.Common.Contract;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Core.Service;
using CS.Domain.Data;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using xUnit.CSCommon;
using Xunit.Abstractions;

namespace XUnit.CS.CoreApi
{
    public class BaseControllerTest : TestBase<CoreApiFixtureSetup>
    {
        public BaseControllerTest(CoreApiFixtureSetup fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
        }

        public void RegisterAll(IServiceCollection services)
        {
            // register all repositories
            DependencyInjectorBootstrapper.Register(services);

            // register ApI core services
            //var connectionString = ApplicationSetting.Current.Settings.GetConnectionString("coreDbConnection");
            // services.AddDbContext<CSoftDataContext>(o => o.UseSqlServer("Server=c-soft.vics.vn;Database=CSBase2;User ID=sa;Password=vics;MultipleActiveResultSets=true "));

            /* var efServiceProvider = services.AddEntityFrameworkInMemoryDatabase()
                 .BuildServiceProvider();

             services.AddSingleton(Logger);
             services.AddDbContext<CSoftDataContext>(b => b.UseInMemoryDatabase("CSBaseTEST")
                 .UseInternalServiceProvider(efServiceProvider)
                 .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));*/
            services.AddDbContext<CSoftDataContext>(ServiceLifetime.Scoped);
            services.AddScoped<ICSoftDataContext, CSoftDataContext>();
            services.AddScoped<IDomainDataHandler, DomainDataHandler>();

            services.AddMvc()
                .AddFluentValidation(cfg =>
                {
                    cfg.LocalizationEnabled = true;
                });

            Logger.WriteLine("Auto mapper initializing...");
            services.AddAutoMapper();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            Logger.WriteLine("Mediator initializing...");
            services.AddMediatR();
            services.AddScoped<IMediator, Mediator>();

            services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
            services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));

            //domain event
            services.AddScoped<IDomainEventHandler<NotificationMessage>, DomainEventNotificationHandler>();
        }
    }
}