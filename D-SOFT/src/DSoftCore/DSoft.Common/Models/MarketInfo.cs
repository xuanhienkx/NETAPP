using DSoft.Common.Shared.Interfaces;
namespace DSoft.Common.Models;

public class MarketInfo : BaseModel, IPersistentEntity
{
    public string MessageName { get; set; }
    public string Data { get; set; }
    public string Notes { get; set; }
    public bool IsOverride { get; set; }
    public string TradingDate { get; set; }
    public DateTime ProcessTime { get; set; } = DateTime.Now;
    public long SessionNumber { get; set; }
    public long InputSequenceNumber { get; set; }

}


