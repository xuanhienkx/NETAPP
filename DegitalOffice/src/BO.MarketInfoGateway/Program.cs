using BO.MarketInfoGateway;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;


using IHost host = Host.CreateDefaultBuilder(args)
                       .ConfigureHostConfiguration(hostConfig =>
                       {
                           hostConfig.SetBasePath(Directory.GetCurrentDirectory());
                           hostConfig.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                           hostConfig.AddEnvironmentVariables();
                           hostConfig.AddCommandLine(args);
                       })
                       .ConfigureServices((_, services) =>
                       {
                           var Configuration = (IConfigurationRoot)_.Configuration;
                           services.AddSingleton<IConfigurationRoot>(Configuration);
                           Bootstrapper.RegisterComponents(services, _.Configuration);

                       })
                       .Build();

// Invoke Worker                                                       
await Worker(host.Services);



await host.RunAsync();


static async Task Worker(IServiceProvider serviceProvider)
{
    var process = Process.GetCurrentProcess();
    Console.Title = $"VSD gateway - PID: {process.Id}";
    if (serviceProvider == null)
    {
        Console.ReadKey();
        return;
    }


    try
    {
        Console.WriteLine("==============================================");
        using IServiceScope serviceScope = serviceProvider.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        // start the gateway.
        var gateway = provider.GetService<GatewayFactory>();

        await gateway.Start();
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
    catch (Exception ex)
    {
        ConsoleHelper.WriteLine(ex.ToString(), ConsoleColor.Red);
        return;
    }


}
#region Helper

static bool HandleKeyCommand(GatewayFactory gateway)
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
#endregion