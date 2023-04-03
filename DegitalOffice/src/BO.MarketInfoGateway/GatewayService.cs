using DO.Common;
using DO.Common.FileTransfer;
using DO.Common.Interfaces;
using DO.Common.Std;
using DO.MarketParser;
using DO.MarketParser.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace BO.MarketInfoGateway;

public interface IGatewayService
{
    Task<bool> Process(PrsBag bag);
    Task<bool> ProcessRequest(string command, string data);
}

public class GatewayService : IGatewayService
{
    private readonly IFileService fileService;
    private readonly PrsSetting prsSetting;
    private readonly IConfigurationRoot configuration;
    private readonly ILogger<GatewayService> logger;

    private DateTime currentDate;
    private long sessionNumber;
    private long inputSequenceNumber;
    private const string DateFormatString = "yyyyMMdd";

    private static readonly object LockObj = new object();

    public GatewayService(IFileService fileService,
        PrsSetting prsSetting, IConfigurationRoot configuration,
        ILogger<GatewayService> logger)
    {
        this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        this.prsSetting = prsSetting ?? throw new ArgumentNullException(nameof(prsSetting));
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        // ensure path created


        // read all sequence number from config file
        ParseCurrentSequenceNumbers();
    }

    public async Task<bool> Process(PrsBag bag)
    {

        logger.LogInformation($"Process with MessageName : {bag.MessageName}");
        // else POST to process the bag
        var postPath = $"market/gateway/{bag.MessageName}";
        var result = await ApiProvider.Instance.
            GetAsync(
            api => api.PostAsync<CsBag, bool>(postPath, bag),
            e => logger.LogError(e, "Request to vsd api failure"));

        logger.LogInformation("POST to {0}: {1}", postPath, result.IsSuccess);

        if (result.HasResult && result.Value)
        {
            return true;
        }
        return false;
        throw new NotImplementedException();
    }

    public Task<bool> ProcessRequest(string command, string data)
    {
        throw new NotImplementedException();
    }
    private void ParseCurrentSequenceNumbers()
    {
        var session = configuration.GetSection("vsd:session");
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
                if (!long.TryParse(session["sessionNumber"], out sessionNumber))
                    sessionNumber = 1;
                if (!long.TryParse(session["inputSequenceNumber"], out inputSequenceNumber))
                    inputSequenceNumber = 1;
            }
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
