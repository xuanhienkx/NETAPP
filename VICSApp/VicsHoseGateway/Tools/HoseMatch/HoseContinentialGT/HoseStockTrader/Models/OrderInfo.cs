using System;

namespace HoseStockTrader.Models
{
    public class OrderInfo
    {
        public string StockId { get; set; }

        public string OrderNo { get; set; }

        public DateTime Date { get; set; }

        public int OrderType { get; set; }

        public int TransactionType { get; set; }

        public bool IsForeignOrder { get; set; }


        public double Price { get; set; }

        public double Quantity { get; set; }
    }
}
