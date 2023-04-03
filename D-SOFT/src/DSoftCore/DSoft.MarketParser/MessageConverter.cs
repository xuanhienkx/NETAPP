using DSoft.Common.Extensions;
using DSoft.Common.Shared.Base;
using DSoft.Common.Shared.Interfaces;
using DSoft.MarketParser.Common;
using Microsoft.Extensions.Logging;
using System.Text;

namespace DSoft.MarketParser;

public abstract class MessageConverter
{
    protected readonly ILogger<MessageConverter> Logger;
    private IDictionary<string, int> msglastVisitLenght = new Dictionary<string, int>();

    private byte[] buffers = new byte[2 * 2048];

    protected MessageConverter(ILogger<MessageConverter> logger)
    {
        this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public virtual DateTime DateProcess { get; set; } = DateTime.Now;
    protected Task<CsBag> ParseToBag(byte[] streambytes, BlockMessage msgSetting, CsBag mgsBagResult)
    {                                          
        var fileLength = streambytes.Length;
        Logger.LogDebug("Full Length File:{0} has length: [{1:N0}]", msgSetting.PatternFormat, fileLength);

        Executor.Try(() => msglastVisitLenght[msgSetting.PatternFormat], out var lastVisitLenght);
        if (msgSetting.UpdateType == PrsUpdateType.Override)
            lastVisitLenght = 0;

        if (lastVisitLenght == fileLength)
            return Task.FromResult(mgsBagResult);

        if (lastVisitLenght > 0 && fileLength > lastVisitLenght)
            fileLength -= lastVisitLenght;


        this.buffers = new byte[fileLength];
        Buffer.BlockCopy(streambytes, lastVisitLenght, this.buffers, 0, fileLength);
        var currentLength = lastVisitLenght;
        Logger.LogInformation("Begin file message read {0} has last visit length [{1:N0}]", msgSetting.PatternFormat, lastVisitLenght);

        int count = 0;
        var msgRecodRead = 0;
        Logger.LogDebug("Processing setting Type:{0} the message: [{1}]", msgSetting.Name, msgSetting.PatternFormat);

        while (fileLength > 0)
        {
            var fieldReader = new ItemReader<Part>(msgSetting?.Parts);
            var bagResult = new CsBag();

            if (msgSetting.PartSize > fileLength)
            {
                Logger.LogError("Message:{msg} not valid length {length:N0}, partSize:{site}", msgSetting.PatternFormat, fileLength, msgSetting.PartSize);
                break;
            }

            byte[] bytes = new byte[msgSetting.PartSize];
            Buffer.BlockCopy(buffers, msgRecodRead, bytes, 0, msgSetting.PartSize);
            fileLength -= msgSetting.PartSize;
            var currentRecord = 0;
            while (fieldReader.MoveNext())
            {
                if (currentRecord > msgSetting.PartSize || bytes == null)
                    break;

                var part = fieldReader.Current;
                if (string.IsNullOrEmpty(part.Name))
                    continue;

                if (currentRecord > msgSetting.PartSize)
                    break;

                byte[] byteRead = new byte[part.Length];
                Buffer.BlockCopy(bytes, currentRecord, byteRead, 0, part.Length);
                currentRecord += part.Length;
                object partValue = partValue = part.Type switch
                {
                    CSValueType.Short => BitConverter.ToInt16(byteRead, 0),
                    CSValueType.Long or CSValueType.Integer => BitConverter.ToInt32(byteRead, 0),
                    CSValueType.Decimal => BitConverter.ToSingle(byteRead, 0),
                    CSValueType.Double => BitConverter.ToDouble(byteRead, 0),
                    _ => Encoding.UTF8.GetString(byteRead, 0, part.Length).Trim().Replace("\0", string.Empty),
                };
                bagResult[$"{msgSetting.PatternFormat}[{count}].{part.Name}"] = partValue;
            }
            lastVisitLenght += msgSetting.PartSize;
            mgsBagResult.AddRange(bagResult);
            count++;
        }

        msglastVisitLenght[msgSetting.PatternFormat] = lastVisitLenght;
        Logger.LogDebug("End file message read {0} has last visit length [{1:N0}]", msgSetting.PatternFormat, lastVisitLenght);
        return Task.FromResult(mgsBagResult);
    }


}
