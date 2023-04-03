using DO.Common;
using DO.Common.Std;
using DO.Common.Std.Configuration;
using DO.MarketParser.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;

namespace DO.MarketParser.MessageBuilder;

public abstract class MessageConverter
{
    protected readonly ILogger<MessageConverter> Logger;
    protected readonly PrsSetting Setting;
    protected MessageConverter(
        ILogger<MessageConverter> logger, PrsSetting setting)
    {

        this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        Setting = setting ?? throw new ArgumentNullException(nameof(setting));
    }
    protected async Task<CsBag> ParseToBag(Stream stream, PrsMessage messageSetting, CsBag mgsBagResult)
    {
        var fileLength = stream.Length;
        int count = 0;
        while (fileLength > 0)
        {
            var fieldReader = new ItemReader<PrsPart>(messageSetting?.Parts);
            var bytes = new byte[fileLength];
            var bagResult = new CsBag();
            while (fieldReader.MoveNext())
            {

                var part = fieldReader.Current;
                if (string.IsNullOrEmpty(part.Name))
                    continue;

                int numberbyte = await stream.ReadAsync(bytes, 0, part.Length); // bắt đầu đọc 
                if (numberbyte <= 0)
                    break;

                object partValue = part.Type switch
                {
                    CSValueType.Integer => BitConverter.ToInt64(bytes, 0),
                    CSValueType.Decimal => BitConverter.ToDouble(bytes, 0),
                    _ => Encoding.UTF8.GetString(bytes, 0, part.Length)
                };
                bagResult[$"{messageSetting.MessageName}[{count}].{part.Name}"] = partValue;

            }
            mgsBagResult.AddRange(bagResult);
            count++;
            fileLength -= messageSetting.PartSize;

        }
        return mgsBagResult;
    }
}