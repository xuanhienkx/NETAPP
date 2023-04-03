using System;

namespace HoseContinentialGT.DAL
{

    public class GLStockCode
    {
        private int id = 0;
        private string stockCode = "";
        private string stockName = "";
        private string stockType = "";
        private Decimal parValue = new Decimal(10000);
        private string shortName = "";
        private string _boardType = string.Empty;
        private string[] errorText;
        private Decimal _ListedVolume;
        private Decimal _RoomForeigner;
        private string stockNameViet;
        private Decimal _ceilingPrice;
        private Decimal _floorPrice;
        private Decimal _basicPrice;
        private string _boardName;
        private int _boardLot;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
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

        public Decimal ParValue
        {
            get
            {
                return this.parValue;
            }
            set
            {
                this.parValue = value;
            }
        }

        public string ShortName
        {
            get
            {
                return this.shortName;
            }
            set
            {
                this.shortName = value;
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

        public Decimal ListedVolume
        {
            get
            {
                return this._ListedVolume;
            }
            set
            {
                this._ListedVolume = value;
            }
        }

        public Decimal RoomForeigner
        {
            get
            {
                return this._RoomForeigner;
            }
            set
            {
                this._RoomForeigner = value;
            }
        }

        public string StockNameViet
        {
            get
            {
                return this.stockNameViet;
            }
            set
            {
                this.stockNameViet = value;
            }
        }

        public Decimal CeilingPrice
        {
            get
            {
                return this._ceilingPrice;
            }
            set
            {
                this._ceilingPrice = value;
            }
        }

        public Decimal FloorPrice
        {
            get
            {
                return this._floorPrice;
            }
            set
            {
                this._floorPrice = value;
            }
        }

        public Decimal BasicPrice
        {
            get
            {
                return this._basicPrice;
            }
            set
            {
                this._basicPrice = value;
            }
        }

        public string BoardType
        {
            get
            {
                return this._boardType;
            }
            set
            {
                this._boardType = value;
            }
        }

        public string BoardName
        {
            get
            {
                return this._boardName;
            }
            set
            {
                this._boardName = value;
            }
        }

        public int BoardLot
        {
            get
            {
                return this._boardLot;
            }
            set
            {
                this._boardLot = value;
            }
        }

        public string BoardTypeViet
        {
            get
            {
                switch (this._boardType)
                {
                    case "M":
                        return "HOSE";
                    case "O":
                        return "OTC";
                    case "S":
                        return "HASE";
                    default:
                        return "Không xác định";
                }
            }
        }

        public string StockTypeViet
        {
            get
            {
                switch (this.stockType)
                {
                    case "D":
                        return "Trái phiếu";
                    case "S":
                        return "Cổ phiếu";
                    case "U":
                        return "Chứng chỉ quỹ";
                    case "E":
                        return "Sản phẩm ETF";
                    case "W":
                        return "Sản phẩm chứng quyền";
                    default:
                        return "Không xác định";
                }
            }
        }

        public GLStockCode()
        {
            this.errorText = new string[31];
        }

        public void SetError(int thongTinField, string error)
        {
            this.errorText[thongTinField] = error;
        }

        public string GetError(int thongTinField)
        {
            return this.errorText[thongTinField];
        }

        public enum GLStockCodeField
        {
            ID,
            StockCode,
            StockType,
            ParValue,
            ShortName,
            BoardType,
            StockName,
        }
    }

}