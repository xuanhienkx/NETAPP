using CS.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using CS.Common.Std;

namespace VSDGateway
{
    class Program
    {
        private static string environmemt;

        static void Main(string[] args)
        {
            var process = Process.GetCurrentProcess();
            Console.Title = $"VSD gateway - PID: {process.Id}";

            // register all compoments
            var serviceProvider = BuildServiceProvider();
            if (serviceProvider == null)
            {
                Console.ReadKey();
                return;
            }

            // start the gateway.
            var gateway = serviceProvider.GetService<GatewayFactory>();

            try
            {
                gateway.Start().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            // just running the main process
            while (true)
            {
                var keyPress = Console.ReadKey();

                if (keyPress.Key != ConsoleKey.Escape)
                    continue;

                if (HandleKeyCommand(gateway) == false)
                    break;
            }

        }

        private static IServiceProvider BuildServiceProvider()
        {
            try
            {
                environmemt = Environment.GetEnvironmentVariable(GlobalConstantsProvider.AspNetEnvironment);
                ConsoleHelper.WriteLine("Environment: {0}", ConsoleColor.Yellow, environmemt);

                var services = new ServiceCollection()
                    .AddLogging();

                var config = Bootstrapper.Init(environmemt);

                var logConfig = config.GetSection("Logging");
                var loggerFactory = new LoggerFactory()
                    .AddConsole(logConfig)
                    .AddFile(logConfig);

                services.AddSingleton(loggerFactory);
                services.ConfigureWritable<SessionConfigurationSection>(
                    "gateway:session", 
                    Directory.GetCurrentDirectory(),
                    string.IsNullOrEmpty(environmemt) ? GlobalConstantsProvider.ApplicationSettingFile : $"appsettings.{environmemt}.json");

                Bootstrapper.RegisterComponents(services, config);
                return services.BuildServiceProvider();
            }
            catch (Exception exception)
            {
                ConsoleHelper.WriteLine("Error: {0}", ConsoleColor.Red, exception.Message);
                return null;
            }
        }

        private static bool HandleKeyCommand(GatewayFactory gateway)
        {
            ConsoleHelper.WriteLine("Enter command for executing: [Q] to quit, [R] to reset the application", ConsoleColor.Green);
            ConsoleHelper.Write("Command: ", ConsoleColor.Yellow);

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Q)
            {
                ConsoleHelper.WriteLine("Manually exit the application...", ConsoleColor.Yellow);
                gateway.Stop(() => Console.Read());
                return false;
            }

            if (key.Key == ConsoleKey.R)
            {
                ConsoleHelper.WriteLine("Manually reset the application...", ConsoleColor.Yellow);
                gateway.Stop(async () => await gateway.Start());
            }
            return true;
        }
    }
}