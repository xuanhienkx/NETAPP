using DO.Common;

namespace DO.MarketParser;

public class PrsBag : CsBag
{
    public PrsBag(string messageName)
    {
        MessageName = messageName;
    }
    public DateTime TradingDate { get; set; }
    public string MessageName { get; }

}