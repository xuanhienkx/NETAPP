using CS.Common.Contract.Enums;

namespace CS.Common.Contract.Models
{ 
    public class StockPriceModel : AssetModel
    {                                        
        public int StockNo { get; set; }
        public StockType StockType { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal BasicPrice { get; set; }
        public decimal CeilingPrice { get; set; }
        public decimal FloorPrice { get; set; }
        public decimal AveragePrice { get; set; }      
        public StockStatus Status { get; set; }

        public StockPriceModel(AssetType type) : base(type)
        {
        }
    }
}