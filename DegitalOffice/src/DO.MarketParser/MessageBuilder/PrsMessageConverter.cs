using DO.Common;
using DO.Common.Interfaces;
using DO.Common.Std.Extensions;
using DO.MarketParser.Configuration;
using DO.MarketParser.Exceptions;
using Microsoft.Extensions.Logging;

namespace DO.MarketParser.MessageBuilder;

public class PrsMessageConverter : MessageConverter, IMarketMessageConverter
{
    public PrsMessageConverter(ILogger<MessageConverter> logger, PrsSetting setting)
        : base(logger, setting)
    {
    }

    public async Task<T?> Read<T>(Stream stream, string messsage) where T : CsBag
    {

        var bag = new PrsBag(messsage) { TradingDate = DateTime.Today };

        var messageSetting = Setting.Messages.FirstOrDefault(x =>
            bag.MessageName.ToUpper().Contains(x.MessageName.ToUpper(), StringComparison.CurrentCultureIgnoreCase));


        if (messageSetting == null)
            throw new MessageConfigurationNotFoundException($"Not found config off message {bag.MessageName}");

        var result = await Executor.TryAsync<CsBag>(
           async () => await base.ParseToBag(stream, messageSetting, bag),
           (ex) => Logger.LogError(ex, $"Parser message {messsage}")
           , true);
        return result as T;
    }


    public void CollectLiteralData(CsBag messsageBag)
    {
        throw new NotImplementedException();
    }

}