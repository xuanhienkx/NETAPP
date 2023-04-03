using DSoft.Common.Exceptions;

namespace DSoft.MarketParser.Exceptions;

public class MessageConfigurationNotFoundException : DSoftException
{
    private readonly string messageName;
    public MessageConfigurationNotFoundException(string messageName)
    {
        this.messageName = messageName;
    }

    protected override string Detail()
    {
        return $"Cannot find the message configuration setting for messageName: [{messageName}]";
    }
}
public class InvalidMarketMessageException : DSoftException
{
    private readonly string rawData;

    public InvalidMarketMessageException(string rawData)
    {
        this.rawData = rawData;
    }

    protected override string Detail()
    {
        return $"Rawdata: {rawData}";
    }
}