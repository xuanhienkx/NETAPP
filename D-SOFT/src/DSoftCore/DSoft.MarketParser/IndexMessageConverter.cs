using DSoft.Common.Extensions;
using DSoft.Common.Shared.Base;
using DSoft.MarketParser.Common;
using DSoft.MarketParser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DSoft.MarketParser;

public class IndexMessageConverter : MessageConverter, IHoseMessageConverter
{
    private MarketSetting prsSetting;
    public IndexMessageConverter(ILogger<MessageConverter> logger, IConfigurationRoot settings)
        : base(logger)
    {
        var configFile = Path.Combine(settings["gateway:settingPath"], "IndexSetting.json");
        prsSetting = ObjectLoader.FromFile<MarketSetting>(configFile);
        if (prsSetting == null)
            throw new ArgumentNullException($"PrsSetting", $"Cannot load IndexSetting Setting  from path: {configFile}");

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
        var messageType = GetMesageType(fileName);
        var msgSetting = prsSetting.Messages?.FirstOrDefault(x =>
                           messageType.Equals(x.Name, StringComparison.OrdinalIgnoreCase));

        if (msgSetting == null)
        {
            Logger.LogError("Cannot find the message configuration setting for messageType: [{messageName}]", messageType);
            throw new ArgumentNullException($"MessagesSetting", $"Cannot load  message setting off file:{fileName}");
        }
        msgSetting.PatternFormat = fileName;
        return msgSetting;
    }
    public bool CanParse(string fileName, DateTime dateProcess)
    {
        base.DateProcess = dateProcess;

        return (fileName.Contains("CS_") || fileName.Contains($"{dateProcess:yyyyMMdd}_"));
    }
    private string GetMesageType(string fileName)
    {
        var msgType = "CS_VNX";
        if (fileName.StartsWith("CS_"))
            return msgType;

        var prefix = DateProcess.ToString("yyyyMMdd");
        var listTypes = prsSetting.FileMapName.Split(',');
        var msg = listTypes.FirstOrDefault(x => fileName.ToUpperInvariant().Equals($"{prefix}_{x}.DAT".ToUpperInvariant(), StringComparison.OrdinalIgnoreCase));
        return string.IsNullOrEmpty(msg) ? "VNX" : msg;

    }
}
