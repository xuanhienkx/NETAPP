namespace HoseStockTrader.Models
{
    public class PutExec
    {
        public string StockId { get; set; }

        public int ConfirmNo { get; set; }

        public double Volume { get; set; }

        public double Price { get; set; }

        public string Board { get; set; }
    }
}
