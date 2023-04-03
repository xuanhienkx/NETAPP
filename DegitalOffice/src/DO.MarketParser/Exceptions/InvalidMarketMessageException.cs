using DO.Common.Std;

namespace DO.MarketParser.Exceptions;

public class InvalidMarketMessageException : CsException
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
public class RequiredDataException : CsException
{
    private readonly string fieldKey;

    public RequiredDataException(string fieldKey)
    {
        this.fieldKey = fieldKey;
    }

    protected override string Detail()
    {
        return $"Field [{fieldKey}] does not find in value bag while building message";
    }
}
public class MessageConfigurationNotFoundException : CsException
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