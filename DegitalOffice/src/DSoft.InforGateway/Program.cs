// See https://aka.ms/new-console-template for more information

using DSoft.InforGateway;
using DSoft.InforGateway.Helpers;
using DSoft.InforGateway.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

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
                               Bootstrapper.RegisterComponents(services, _.Configuration);

                           })
                       .Build();


await ExemplifyScoping(host.Services, "DSoftAPI.read");

await host.RunAsync();

static async Task ExemplifyScoping(IServiceProvider services, string scope)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("==============================================");
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    var tokenService = provider.GetRequiredService<ITokenService>();
    var tokenResponse = await tokenService.GetToken(scope);
    if (tokenResponse.IsError)
    {
        Console.WriteLine(tokenResponse.HttpStatusCode);
    }
    else
    {
        string jsonString = JsonSerializer.Serialize(tokenResponse);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(jsonString);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("==============================================");
    Console.ResetColor();
}

// Worker.cs
internal class Worker
{
    private readonly IConfiguration configuration;

    public Worker(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void DoWork()
    {
        var keyValuePairs = configuration.AsEnumerable().ToList();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==============================================");
        Console.WriteLine("Configurations...");
        Console.WriteLine("==============================================");
        foreach (var pair in keyValuePairs)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }
        Console.WriteLine("==============================================");
        Console.ResetColor();
    }
}
