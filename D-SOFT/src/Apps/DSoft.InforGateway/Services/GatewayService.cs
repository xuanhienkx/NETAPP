using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser;
using DSoft.MarketParser.Common;      
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace DSoft.InforGateway.Services;

public interface IGatewayService
{
    Task<bool> Process(PrsBag bag);
    Task<bool> ProcessRequest(string command, string data);
}

public class GatewayService : BaseService, IGatewayService
{
    private readonly IConfigurationRoot configuration;                             
    private DateTime currentDate;
    private long sessionNumber;
    private long inputSequenceNumber;
    private const string DateFormatString = "yyyyMMdd";

    private static readonly object LockObj = new object();

    public GatewayService(IConfigurationRoot configuration,             
        ILogger<GatewayService> logger,  IHttpClientFactory httpClientFactory, ITokenService tokenService)
        : base(httpClientFactory, tokenService , logger)
    {
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));  
        // ensure path created             

        // read all sequence number from config file
        ParseCurrentSequenceNumbers();
    }

    public async Task<bool> Process(PrsBag bag)
    {
        ValidateTransactionDate();
        // else POST to process the bag
        var version = configuration.GetValue<string>("CoreApi:version");
        var postPath = $"/api/{version}/Market/{bag.MessageName}";
        bag[$"{bag.MessageName}[-1].{ProviderConstants.SessionNumber}"] = sessionNumber;
        bag[$"{bag.MessageName}[-1].{ProviderConstants.InputSequenceNumber}"] = inputSequenceNumber;

        var result = await PostAsync<IList<CsBagItem>, bool>(postPath, bag.Items, true);
        if (result is not null && !result.Succeeded)
        {
            Logger.LogError("Error:{0} ", string.Join("|", result.Errors));

        }
        UpdateSystemSequenceNumber();
        return true;
    }

    public Task<bool> ProcessRequest(string command, string data)
    {
        throw new NotImplementedException();
    }
    private void ParseCurrentSequenceNumbers()
    {
        var session = configuration.GetSection("gateway:session");
        var currentDateString = session["currentDate"];
        if (string.IsNullOrEmpty(currentDateString))
        {
            currentDate = DateTime.Today;
            sessionNumber = 1;
            inputSequenceNumber = 1;
        }
        else
        {
            if (!DateTime.TryParseExact(currentDateString, DateFormatString, CultureInfo.CurrentUICulture, DateTimeStyles.None, out currentDate)
                || currentDate.DayOfYear != DateTime.Today.DayOfYear)
            {
                currentDate = DateTime.Today;
                sessionNumber = 1;
                inputSequenceNumber = 1;
            }
            else
            {
                if (!long.TryParse(session[ProviderConstants.SessionNumber], out sessionNumber))
                    sessionNumber = 1;
                if (!long.TryParse(session[ProviderConstants.InputSequenceNumber], out inputSequenceNumber))
                    inputSequenceNumber = 1;
            }
        }
    }
    private void UpdateSystemSequenceNumber()
    {
        lock (LockObj)
        {
            inputSequenceNumber += 1;
            sessionNumber += 1;
        }   
    }
    private void ValidateTransactionDate()
    {
        if (currentDate.DayOfYear == DateTime.Today.DayOfYear)
            return;

        lock (LockObj)
        {
            currentDate = DateTime.Today;
            sessionNumber = 1;
            inputSequenceNumber = 1;
        }
    }


}
