using AutoMapper;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Core.Service;
using CS.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using CS.Common.Contract;
using xUnit.CSCommon;
using Xunit.Abstractions;

namespace XUnit.CS.Domain.Data
{
    public abstract class BaseDataTest : TestBase<CoreDataFixtureSetup>
    {
        protected IDomainDataHandler DataHandler;
        protected BaseDataTest(CoreDataFixtureSetup fixtureSetup, ITestOutputHelper output)
            : base(fixtureSetup, output)
        {
            // fixture 
            Fixture.Register(services =>
            {

                DependencyInjectorBootstrapper.Register(services);
                var efServiceProvider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                services.AddDbContext<CSoftDataContext>(b => b.UseInMemoryDatabase("CSBase")
                                                            .UseInternalServiceProvider(efServiceProvider)
                                                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

                services.AddScoped<ICSoftDataContext, CSoftDataContext>();
                services.AddScoped<IDomainDataHandler, DomainDataHandler>();

                Debug.WriteLine("Auto mapper initializing...");
                services.AddAutoMapper();
                services.AddSingleton(Mapper.Configuration);
                services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

                Debug.WriteLine("Mediator initializing...");
                services.AddMediatR();
                services.AddScoped<IMediator, Mediator>();

                services.AddTransient<SingleInstanceFactory>(sp => t => sp.GetService(t));
                services.AddTransient<MultiInstanceFactory>(sp => t => sp.GetServices(t));

                //domain event
                services.AddScoped<IDomainEventHandler<NotificationMessage>, DomainEventNotificationHandler>();

            });
            DataHandler = Fixture.Resolve<IDomainDataHandler>();
        }
    }
}