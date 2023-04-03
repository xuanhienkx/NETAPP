using DSoft.Common.Shared.Base;

namespace DSoft.MarketParser.Commands
{

    public abstract class MarketInfoCommandBase : BaseCommand<bool>
    {
        public MarketInfoCommandBase(PrsBag marketMessageData) => (MarketMessageData) = (marketMessageData);

        public DateTime ProcessTime => DateTime.Now;
        public PrsBag MarketMessageData { get; set; }
    }

    public class MarketInfoCreateCommand : MarketInfoCommandBase
    {
        public MarketInfoCreateCommand(PrsBag marketMessageData) : base(marketMessageData)
        {
        }

        public bool IsOverride { get; set; }
    }

    public class MarketUpdateCreateCommand : MarketInfoCommandBase
    {
        public MarketUpdateCreateCommand(PrsBag marketMessageData) : base(marketMessageData)
        {
        }

        public string Id { get; set; }
        public bool IsOverride { get; set; }
    }
}
