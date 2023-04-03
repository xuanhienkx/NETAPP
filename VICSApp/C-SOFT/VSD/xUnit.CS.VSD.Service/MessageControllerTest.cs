using AutoMapper;
using CS.Common;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data;
using CS.VSD.Service.Controllers;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using SemanticComparison.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using xUnit.CSCommon;
using Xunit;
using Xunit.Abstractions;
using CSCoreServiceBootstrapper = CS.Core.Service.DependencyInjectorBootstrapper;
using CSVSDServiceBootstrapper = CS.VSD.Service.DependencyInjectorBootstrapper;
using Entities = CS.Domain.Data.Entities;
namespace xUnit.CS.VSD.Service
{
    public class MessageControllerTest : TestBase<VSDServiceFixtureSetup>
    {
        public MessageControllerTest(VSDServiceFixtureSetup fixture, ITestOutputHelper output)
            : base(fixture, output)
        {
            Fixture.Register(services =>
            {
                // register all repositories
                CSCoreServiceBootstrapper.Register(services);
                // register VSD gateway service
                CSVSDServiceBootstrapper.Register(services);

                // register ApI core services
                //var connectionString = ApplicationSetting.Current.Settings.GetConnectionString("coreDbConnection");
                //services.AddDbContext<CSoftDataContext>(o => o.UseSqlServer(connectionString));

                var efServiceProvider = services.AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddSingleton(Logger);
                services.AddDbContext<CSoftDataContext>(b => b.UseInMemoryDatabase("CSBaseTEST")
                    .UseInternalServiceProvider(efServiceProvider)
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

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

                // controler
                services.AddScoped<GatewayController>();
            });
        }

        [Theory]
        [InlineData("MT598_Thong bao dang ky ma ck moi 2081.json")]
        [InlineData("MT598_Thong bao dang ky ma ck moi 2081ISIN.json")]
        public async void CreateMessageAssetTest(string fileData)
        {

            // fixture setup
            var data = Fixture.LoadTestData<IDictionary<string, object>>(fileData);
            var bag = new CsBag(data);
            var businessId = bag["BusinessId"].ToString();

            // exercice
            var sut = Fixture.Resolve<GatewayController>();
            var result = await sut.Create(businessId, new List<CsBagItem>(bag));
            // assert 
            Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<AssetModel>(((OkObjectResult)result).Value);        
            var mapper = Fixture.Resolve<IMapper>();

            var memContext = Fixture.Resolve<CSoftDataContext>();
            var dbModel = mapper.Map<AssetModel>(memContext.Set<Entities.Asset>().Single(x => x.Id == model.Id));

            dbModel.AsSource().OfLikeness<AssetModel>()                              
                .ShouldEqual(model);
            // teardown
        }

        [Theory]
        [InlineData("MT598_XacnhanMo tai khoan.json")]
        public async void CreateMessageOpenCloseTest(string fileData)
        {
            var memContext = Fixture.Resolve<CSoftDataContext>();
            var cus = new Entities.Customer()
            {
                Id = Guid.NewGuid(),   
                Status = CustomerStatus.Open,
                CardType = CardType.DomesticIdentity,
                Type = 0,
                CustomerNumber = "076C066788",
                FullNameLocal = "Nguyen xuan phap",
                FullName = "nguyen xuan phap",
                CardIdentity = "183522865",
                CardIssuer = "HA TINH",

            };
            memContext.Set<Entities.Customer>().Add(cus);
            memContext.SaveChanges();                                                                 
            // fixture setup
            var data = Fixture.LoadTestData<IDictionary<string, object>>(fileData);
            var bag = new CsBag(data);
            var businessId = bag["BusinessId"].ToString();

            // exercice
            var sut = Fixture.Resolve<GatewayController>();
            var result =await sut.Create(businessId, new List<CsBagItem>(bag));
            // assert 
            Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<CustomerModel>(((OkObjectResult)result).Value);
            var mapper = Fixture.Resolve<IMapper>();

            var dbModel = mapper.Map<CustomerModel>(memContext.Set<Entities.Customer>().Single(x => x.Id == model.Id));

            dbModel.AsSource().OfLikeness<CustomerModel>()                     
                .ShouldEqual(model);
            // teardown
        }
    }
}