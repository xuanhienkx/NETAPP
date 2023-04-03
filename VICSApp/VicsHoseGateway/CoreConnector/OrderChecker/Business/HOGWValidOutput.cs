namespace OrderChecker.Business
{
    public class HOGWValidOutput
    {
        private int errCode;
        private string errDesc;
        private bool isOK;
        private string pcFlag;
        private double room;
        private string stockType;
        private int traderID;

        public HOGWValidOutput()
        {
            this.pcFlag = "C";
            this.stockType = "S";
            this.errDesc = "";
            this.isOK = true;
        }

        public HOGWValidOutput(string pcflag, string stocktype, int errcode, string errdesc, double room, int traderid, bool isok)
        {
            this.pcFlag = "C";
            this.stockType = "S";
            this.errDesc = "";
            this.isOK = true;
            this.pcFlag = pcflag;
            this.stockType = stocktype;
            this.errCode = errcode;
            this.errDesc = errdesc;
            this.room = room;
            this.traderID = traderid;
            this.isOK = isok;
        }

        public int ErrCode
        {
            get
            {
                return this.errCode;
            }
            set
            {
                this.errCode = value;
            }
        }

        public string ErrDesc
        {
            get
            {
                return this.errDesc;
            }
            set
            {
                this.errDesc = value;
            }
        }

        public bool IsOK
        {
            get
            {
                return this.isOK;
            }
            set
            {
                this.isOK = value;
            }
        }

        public string PCFlag
        {
            get
            {
                return this.pcFlag;
            }
            set
            {
                this.pcFlag = value;
            }
        }

        public double Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
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
    }
}

