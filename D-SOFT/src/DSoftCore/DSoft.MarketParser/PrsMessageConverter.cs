using DSoft.Common.Extensions;
using DSoft.Common.Shared.Base;
using DSoft.MarketParser.Common;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DSoft.MarketParser;

public class PrsMessageConverter : MessageConverter, IHoseMessageConverter
{
    private MarketSetting prsSetting;

    public PrsMessageConverter(ILogger<MessageConverter> logger, IConfigurationRoot settings)
        : base(logger)
    {
        var configFile = Path.Combine(settings["gateway:settingPath"], "PrsSetting.json");
        prsSetting = ObjectLoader.FromFile<MarketSetting>(configFile);
        if (prsSetting == null)
            throw new ArgumentNullException($"PrsSetting", $"Cannot load PrsSetting Setting  from path: {configFile}");

    }

    public async Task<T?> Read<T>(byte[] stream, string fileName) where T : CsBag
    {
        var msgSetting = Msgetting(fileName);
        var bag = new PrsBag(msgSetting.PatternFormat);
        bag[$"{bag.MessageName}[-1].{ProviderConstants.UpdateType}"] = msgSetting.UpdateType.ToString();

        var result = await Executor.TryAsync(
           async () => await ParseToBag(stream, msgSetting, bag),
           (ex) => Logger.LogError(ex, $"Parser message {msgSetting.PatternFormat}")
           , true);
        return result as T;
    }
    private BlockMessage Msgetting(string fileName)
    {
        var msgetting = prsSetting.Messages.FirstOrDefault(x =>
                           fileName.ToLowerInvariant().Equals(x.Name.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase));

        if (msgetting == null)
        {
            Logger.LogError("Cannot find the message configuration setting for messageType: [{messageName}]", fileName);
            throw new ArgumentNullException($"MessagesSetting", $"Cannot load  message setting off file:{fileName}");

        }
        msgetting.PatternFormat = fileName;
        return msgetting;
    }

    public bool CanParse(string fileName, DateTime dateProcess)
    {
        base.DateProcess = dateProcess;
        return !(fileName.Contains("CS_") || fileName.Contains($"{dateProcess:yyyyMMdd}_"));
    }
}
