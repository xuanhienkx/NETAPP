using DSoft.MarketParser.Common;

namespace DSoft.MarketParser;

public class PrsBag : CsBag
{
    public PrsBag()
    {
        ProcessTime = DateTime.Now;
    }
    public PrsBag(string messageName) : this()
    {
        MessageName = messageName;
    }
    public string MessageName { get; }
    public DateTime ProcessTime { get; set; }

}
