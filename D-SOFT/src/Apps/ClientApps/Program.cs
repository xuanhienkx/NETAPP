// See https://aka.ms/new-console-template for more information
//Set connection
using ClientApps;
using IdentityModel.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
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
                           var Configuration = (IConfigurationRoot)_.Configuration;
                           services.AddSingleton<IConfigurationRoot>(Configuration);
                           //Config Identity

                           services.AddAuthentication();
                           services.AddHttpClient("BackendApi", options =>
                           {
                               options.BaseAddress = new Uri(Configuration["CoreApi:apiUrl"]);
                           })
                                   .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                                   {
                                       ClientCertificateOptions = ClientCertificateOption.Manual,
                                       ServerCertificateCustomValidationCallback =
                                          (httpRequestMessage, cert, cetChain, policyErrors) =>
                                          {
                                              return true;
                                          }
                                   });

                       })
                       .Build();
// Invoke Worker                                                       
await Worker(host.Services);
await host.RunAsync();

static async Task Worker(IServiceProvider serviceProvider)
{
    var process = Process.GetCurrentProcess();
    Console.Title = $"Market Client - PID: {process.Id}";
    var islost = false;
    var curentDate = DateTime.Now;
    if (serviceProvider == null)
    {
        Console.ReadKey();
        return;
    }
    Console.WriteLine("==============================================");
    using IServiceScope serviceScope = serviceProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var config = provider.GetRequiredService<IConfigurationRoot>();
    var apiUrl = config["CoreApi:apiUrl"];
    var token = await GetToken(config);
    var hubConnection = new HubConnectionBuilder()
                            .WithUrl(apiUrl, option =>
                            {
                                option.AccessTokenProvider =  () =>  Task.FromResult(token);
                            })
                           .WithAutomaticReconnect()
                           .Build();

    try
    {
        hubConnection.On<Message>("hf", (ms) =>
        {
            Console.WriteLine($"Message from Id {ms.Id}");
            var data = JsonConvert.DeserializeObject<MarketInfo>(ms.Data);
            Console.WriteLine($"Message info: {data.MessageName} - SequenceNumber:{data.InputSequenceNumber}");
        });

        Console.WriteLine("start run................");
        await hubConnection.StartAsync();

        while (true)
        {
            var keyPress = Console.ReadKey();

            if (keyPress.Key != ConsoleKey.Escape)
                continue;

            //Get lost messess
            if(islost)
            {
                var listLost = GetLostMessageWithBeginEndInputSequenceNumber(provider, token, "security", 1, 10);
            }
            Console.WriteLine("Client started... Press Q key to close the connection");
            if (keyPress.Key == ConsoleKey.Q)
            {
                Console.WriteLine("You want stop client?..Press X key to close the connection");
                Console.ReadLine();
                await hubConnection.DisposeAsync();
                Console.WriteLine("Client is shutting down...");                    
                
            }
        }
    }
    catch (Exception ex)
    {
        //await hubConnection.DisposeAsync();
        Console.WriteLine(ex.ToString(), ConsoleColor.Red);
        return;
    }


}


static async Task<string> GetToken(IConfigurationRoot config)
{
    HttpClient httpClient = new HttpClient();
    var discoveryDocument = await httpClient.GetDiscoveryDocumentAsync(config["IdentitySettings:DiscoveryUrl"]);

    var clientRequets = new ClientCredentialsTokenRequest
    {
        Address = discoveryDocument.TokenEndpoint,
        ClientId = config["IdentitySettings:ClientId"],
        ClientSecret = config["IdentitySettings:ClientPassword"],
        Scope = config["IdentitySettings:Scope"]
    };

    var rs = await httpClient.RequestClientCredentialsTokenAsync(clientRequets);
    Console.WriteLine("Token is: {0}", rs.AccessToken);
    return rs.AccessToken;

}
static async Task<IEnumerable<MarketInfo>> GetLostMessageWithBeginEndInputSequenceNumber(IServiceProvider provider, string token, string messageName, int begin, int end)
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var client = httpClientFactory.CreateClient("BackendApi");
    client.SetBearerToken(token);
    // string url = $"/api/{version}/Market/{bag.MessageName}"
    if (begin > end) return null;
    string url = $"/api/v1/MarketInfo/{messageName}/{begin}/{end}";
    var result = await client.GetFromJsonAsync<Result<IEnumerable<MarketInfo>>>(url, new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    });

    if (result.Succeeded)
        return result.Value;
    else throw new Exception(String.Join("\n", result.Errors));
}