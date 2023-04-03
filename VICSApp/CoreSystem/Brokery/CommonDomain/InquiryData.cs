namespace CommonDomain
{
    public enum OrderSide
    {
        B, S
    }

    public sealed class InquiryData
    {
        // Fields
        public decimal AvaiableBalance;
        public decimal BlockBalance;
        public decimal BoughtCash;
        public decimal CurrentLimitValue;
        public decimal CustomerLimitDebit;
        public bool IsActive;
        public decimal LitmitValue;

        public long BeginStock;
        public long MortageStock;
        public long SoldStock;
        public long SoldStockNoPost;

        public decimal TradingValue;
        public decimal TradingFee;

        public string TradingStockPriceType;
        public int Session;
        public string AlertCode = "N";
        public string Notes;

        public int? TradingStockVolume;
        public decimal? TradingStockPrice;

        public int? IcebergVolume;
        public decimal? StopPrice;

        public GLStockCode TradingStock;
        public OrderSide OrderSide;
        public Customer Customer;
        public CustomerBalance CustomerBalance;

        public InquiryData() { }

        public InquiryData(OrderSide orderSide)
        {
            this.OrderSide = orderSide;
        }

        
    }
}
