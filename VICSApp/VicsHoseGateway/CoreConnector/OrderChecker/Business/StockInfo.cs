using System;

namespace OrderChecker.Business
{
    public class StockInfo
    {
        private long boardLot;
        private string delist;
        private long froom;
        private string halt;
        private string marketCode;
        private decimal par;
        private DateTime prevTradingDate;
        private decimal priceBasic;
        private decimal priceCeiling;
        private decimal priceFloor;
        private int priceStep;
        private long roomCurrent;
        private int securitynumber;
        private int securitynumberold;
        private string split;
        private string stockCode;
        private string stockName;
        private string stockType;
        private string suspension;
        private DateTime tradingDate;
        private long volumeLimit;

        public StockInfo()
        {
            this.prevTradingDate = DateTime.Now.AddDays(-1.0);
            this.delist = "";
            this.suspension = "";
            this.halt = "";
            this.stockName = "";
            this.stockCode = "";
            this.tradingDate = DateTime.Now;
            this.stockType = "S";
            this.marketCode = "A";
            this.priceStep = 1;
            this.boardLot = 10L;
        }

        public StockInfo(string stockcode, string stockname, DateTime tradingdate, DateTime prevtradingdate, string stocktype, string marketcode, decimal pricebasic, decimal priceceiling, decimal pricefloor, int pricestep, long volumelimit, long boardlot, string suspension, string halt, long froom, string delist, string split, decimal par, int securitynumber, int securitynumberold)
        {
            this.prevTradingDate = DateTime.Now.AddDays(-1.0);
            this.delist = "";
            this.suspension = "";
            this.halt = "";
            this.stockName = "";
            this.stockCode = "";
            this.tradingDate = DateTime.Now;
            this.stockType = "S";
            this.marketCode = "A";
            this.priceStep = 1;
            this.boardLot = 10L;
            this.stockCode = stockcode;
            this.stockName = stockname;
            this.marketCode = marketcode;
            this.stockType = stocktype;
            this.tradingDate = tradingdate;
            this.prevTradingDate = prevtradingdate;
            this.priceBasic = pricebasic;
            this.priceCeiling = priceceiling;
            this.priceFloor = pricefloor;
            this.priceStep = pricestep;
            this.volumeLimit = volumelimit;
            this.boardLot = boardlot;
            this.suspension = suspension;
            this.halt = halt;
            this.froom = froom;
            this.delist = delist;
            this.split = split;
            this.par = par;
            this.securitynumber = securitynumber;
            this.securitynumberold = securitynumberold;
        }

        public long BoardLot
        {
            get
            {
                return this.boardLot;
            }
            set
            {
                this.boardLot = value;
            }
        }

        public string Delist
        {
            get
            {
                return this.delist;
            }
            set
            {
                this.delist = value;
            }
        }

        public long Froom
        {
            get
            {
                return this.froom;
            }
            set
            {
                this.froom = value;
            }
        }

        public string Halt
        {
            get
            {
                return this.halt;
            }
            set
            {
                this.halt = value;
            }
        }

        public string MarketCode
        {
            get
            {
                return this.marketCode;
            }
            set
            {
                this.marketCode = value;
            }
        }

        public decimal Par
        {
            get
            {
                return this.par;
            }
            set
            {
                this.par = value;
            }
        }

        public DateTime PrevTradingDate
        {
            get
            {
                return this.prevTradingDate;
            }
            set
            {
                this.prevTradingDate = value;
            }
        }

        public decimal PriceBasic
        {
            get
            {
                return this.priceBasic;
            }
            set
            {
                this.priceBasic = value;
            }
        }

        public decimal PriceCeiling
        {
            get
            {
                return this.priceCeiling;
            }
            set
            {
                this.priceCeiling = value;
            }
        }

        public decimal PriceFloor
        {
            get
            {
                return this.priceFloor;
            }
            set
            {
                this.priceFloor = value;
            }
        }

        public int PriceStep
        {
            get
            {
                return this.priceStep;
            }
            set
            {
                this.priceStep = value;
            }
        }

        public long RoomCurrent
        {
            get
            {
                return this.roomCurrent;
            }
            set
            {
                this.roomCurrent = value;
            }
        }

        public int SecurityNumber
        {
            get
            {
                return this.securitynumber;
            }
            set
            {
                this.securitynumber = value;
            }
        }

        public int SecurityNumberOld
        {
            get
            {
                return this.securitynumberold;
            }
            set
            {
                this.securitynumberold = value;
            }
        }

        public string Split
        {
            get
            {
                return this.split;
            }
            set
            {
                this.split = value;
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

        public string StockName
        {
            get
            {
                return this.stockName;
            }
            set
            {
                this.stockName = value;
            }
        }

        public string StockType
        {
            get
            {
                return this.stockType;
            }
            set
            {
                this.stockType = value;
            }
        }

        public string Suspension
        {
            get
            {
                return this.suspension;
            }
            set
            {
                this.suspension = value;
            }
        }

        public DateTime TradingDate
        {
            get
            {
                return this.tradingDate;
            }
            set
            {
                this.tradingDate = value;
            }
        }

        public long VolumeLimit
        {
            get
            {
                return this.volumeLimit;
            }
            set
            {
                this.volumeLimit = value;
            }
        }
    }
}

