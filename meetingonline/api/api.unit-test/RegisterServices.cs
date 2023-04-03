using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using api.common;
using api.common.Models;
using api.common.Shared.Interfaces;
using Hangfire.Storage.Monitoring;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;
using IConfigurationRoot = Microsoft.Extensions.Configuration.IConfigurationRoot;
using ICurrentUser = api.common.Shared.Interfaces.ICurrentUser;
using IdentityUser = api.common.Models.Identity.IdentityUser;

namespace api.unit_test
{
    class MockWebHostEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; }
    }

    static class RegisterServices
    {
        public static ServiceCollection CreateServices()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(ProviderConstants.ApplicationSettingsFile, optional: true, reloadOnChange: true);
            var config = builder.Build();

            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSignalR();

            services.AddSingleton(config);
            services.AddTransient<IWebHostEnvironment, MockWebHostEnvironment>();
            common.CommonRegister.Register(services, config);

            // register all components from other resources
            resources.ComponentRegister.Register(services, config);
            domain.ComponentRegister.Register(services);
            audit.ComponentRegister.Register(services, config);

            return services;
        }

        public static ServiceCollection WithCurrentUser(this ServiceCollection services, Action<Mock<ICurrentUser>> setup = null)
        {
            var mock = new Mock<ICurrentUser>();
            mock.Setup(x => x.IsInRole(It.IsAny<AccountRole>())).ReturnsAsync(true);
            mock.Setup(x => x.CanAccessToMeeting(It.IsAny<string>())).Returns(true);
            setup?.Invoke(mock);

            services.AddScoped(provider => mock.Object);
            return services;
        }
    }
}
