namespace OrderChecker.Business
{
    public class HOGWValidInput
    {
        private string customerID;
        private string marketStatus;
        private string orderSession;
        private string orderSide;
        private string orderType;
        private decimal price;
        private string priceType;
        private int ptOrderType;
        private double publishedVolume;
        private string stockCode;
        private int traderID;
        private double volume;

        public HOGWValidInput()
        {
            this.customerID = "";
            this.stockCode = "";
            this.priceType = "LO";
            this.marketStatus = "P";
            this.orderSession = "P";
            this.orderType = "N";
        }

        public HOGWValidInput(string customerid, string stockcode, string pricetype, string marketstatus, string ordertype, string orderside, int traderid, decimal price, double volume, double publishedvolume, int ptordertype, string ordersession)
        {
            this.customerID = "";
            this.stockCode = "";
            this.priceType = "LO";
            this.marketStatus = "P";
            this.orderSession = "P";
            this.orderType = "N";
            this.customerID = customerid;
            this.stockCode = stockcode;
            this.priceType = pricetype;
            this.marketStatus = marketstatus;
            this.orderSession = ordersession;
            this.orderType = ordertype;
            this.orderSide = orderside;
            this.traderID = traderid;
            this.price = price;
            this.volume = volume;
            this.publishedVolume = publishedvolume;
            this.PTOrderType = ptordertype;
        }

        public string getDescription(string desHeader)
        {
            return ("[" + desHeader + "] Cust=" + this.customerID + ", Stock=" + this.stockCode + ", PriceType=" + this.priceType + ", OrderType=" + this.orderType + ", Vol=" + this.volume.ToString() + ", Price=" + this.price.ToString() + ", Trader=" + this.traderID.ToString() + ", MrkSts=" + this.marketStatus);
        }

        public string CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
            }
        }

        public string MarketStatus
        {
            get
            {
                return this.marketStatus;
            }
            set
            {
                this.marketStatus = value;
            }
        }

        public string OrderSession
        {
            get
            {
                return this.orderSession;
            }
            set
            {
                this.orderSession = value;
            }
        }

        public string OrderSide
        {
            get
            {
                return this.orderSide;
            }
            set
            {
                this.orderSide = value;
            }
        }

        public string OrderType
        {
            get
            {
                return this.orderType;
            }
            set
            {
                this.orderType = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string PriceType
        {
            get
            {
                return this.priceType;
            }
            set
            {
                this.priceType = value;
            }
        }

        public int PTOrderType
        {
            get
            {
                return this.ptOrderType;
            }
            set
            {
                this.ptOrderType = value;
            }
        }

        public double PublishedVolume
        {
            get
            {
                return this.publishedVolume;
            }
            set
            {
                this.publishedVolume = value;
            }
        }

        public string StockCode
        {
            get
            {
                return this.stockCode;
            }
            set
            {
                this.stockCode = value;
            }
        }

        public int TraderID
        {
            get
            {
                return this.traderID;
            }
            set
            {
                this.traderID = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
            }
        }
    }
}

