using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;
using Console.App;
using HoseStockTrader.Messages;
using HoseStockTrader.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Newtonsoft.Json;
using IsolationLevel = System.Data.IsolationLevel;
using PutAd = HoseStockTrader.Messages.PutAd;
using PutExec = HoseStockTrader.Messages.PutExec;

namespace HoseStockTrader
{
    public class HosePriceTask : ITask
    {
        #region Properties 
        public static bool IsNewDay = false;
        private readonly HoseConfiguration config;
        private readonly string dealDataFile;
        private readonly string tradingDate;
        public static bool _isUpdatedOpenPrice = false;
        private static List<String> list_symbols = new List<string>();
        private static List<int> list_priceOpens = new List<int>();
        DateTime lastDay = DateTime.MinValue;
        private readonly MessageLoader<DataPath> datapathLoader;
        private readonly MessageLoader<DeList> deListLoader;
        private readonly MessageLoader<FRoom> fRoomLoader;
        private readonly MessageLoader<Le> leLoader;
        private readonly MessageLoader<Ls> lsLoader;
        private readonly MessageLoader<MarketStat> marketStatLoader;
        private readonly MessageLoader<NewList> newListLoader;
        private readonly MessageLoader<PutAd> putAdLoader;
        private readonly MessageLoader<PutExec> putExecLoader;
        private readonly MessageLoader<PutDc> putDcLoader;
        private readonly MessageLoader<Securities> securityLoader;
        private readonly MessageLoader<Totalmkt> totalmktLoader;
        public const string HOSTC_SECTYPE_S = "S";
        public const string HOSTC_SECTYPE_U = "U";
        public const string HOSTC_SECTYPE_D = "D";
        public const string HOSTC_SECTYPE_W = "W";
        public const string HOSTC_SECTYPE_E = "E";
        private bool isStop;
        private MarketSatus currenStatus;
        private long records = 0;
        private Database db;
        TimeSpan t1 = new TimeSpan(8, 45, 0);
        TimeSpan t2 = new TimeSpan(11, 30, 0);
        TimeSpan t3 = new TimeSpan(13, 0, 0);
        TimeSpan t4 = new TimeSpan(14, 45, 0);
        TimeSpan t5 = new TimeSpan(15, 00, 0);
        #endregion

        public HosePriceTask(HoseConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            this.config = config;
            this.tradingDate = DateTime.Today.ToString("dd/MM/yyyy");
            datapathLoader = new MessageLoader<DataPath>(config.PRSPath, "datapath.map");
            var dayDir = PrsDataPath();
            if (!string.IsNullOrEmpty(dayDir))
            {
                var prsDirPath = Path.Combine(config.PRSPath, dayDir);
                currenStatus = new MarketSatus() { Status = "A" };
                datapathLoader = new MessageLoader<DataPath>(prsDirPath, "SECURITY.DAT");
                fRoomLoader = new MessageLoader<FRoom>(prsDirPath, "FROOM.DAT");
                leLoader = new MessageLoader<Le>(prsDirPath, "LE.DAT");
                leLoader = new MessageLoader<Le>(prsDirPath, "LE.DAT");
                marketStatLoader = new MessageLoader<MarketStat>(prsDirPath, "MARKET_STAT.DAT");
                putAdLoader = new MessageLoader<PutAd>(prsDirPath, "PUT_AD.DAT");
                putExecLoader = new MessageLoader<PutExec>(prsDirPath, "PUT_EXEC.DAT");
                securityLoader = new MessageLoader<Securities>(prsDirPath, "SECURITY.DAT");
                totalmktLoader = new MessageLoader<Totalmkt>(prsDirPath, "TOTALMKT.DAT");
            }

        }

        private string PrsDataPath()
        {
            Logger.ConsoleLog("Process PrsDataPath...");
            var dir = string.Empty;
            if (datapathLoader.Open(18))
            {
                DataPath dataPath;
                while (datapathLoader.Read(out dataPath))
                {
                    dir = dataPath.FolderName;
                }

                datapathLoader.Close();
                if (!string.IsNullOrEmpty(dir))
                    return dir;
            }
            Logger.ConsoleLog("Kh\x00f4ng c\x00f3 thư mục dữ liệu cho ng\x00e0y " + DateTime.Now.ToString("dd/MM/yyyy"));
            Logger.LogError("Kh\x00f4ng c\x00f3 thư mục dữ liệu cho ng\x00e0y " + DateTime.Now.ToString("dd/MM/yyyy"));
            return string.Empty;
        }
        public void Run()
        {

            if (config.TimeUp.HasValue && config.TimeUp.Value < DateTime.Now.TimeOfDay)
            {
                Logger.ConsoleLog("Time up at {0}!", config.TimeUp.Value);
                return;
            }
            this.records = 0;
            #region Market Status  
            if (marketStatLoader.Open(5))
            {
                Logger.ConsoleLog("Process Market status...");
                MarketStat marketStatus;
                while (marketStatLoader.Read(out marketStatus))
                {
                    var t = marketStatus.Time.ToString("D6");
                    int seconds = int.Parse(t.Substring(4, 2));
                    int minutes = int.Parse(t.Substring(2, 2));
                    int hours = int.Parse(t.Substring(0, 2));
                    TimeSpan timeSpan = new TimeSpan(hours, minutes, seconds);
                    var itemStatus = new MarketSatus() { Status = marketStatus.Status, LastTime = timeSpan };
                    currenStatus = itemStatus;
                    Logger.ConsoleLog("-> Current market status: {0}", JsonConvert.SerializeObject(currenStatus));
                }
                marketStatLoader.Close();

            }
            #endregion 
            Logger.ConsoleLog("Process Security...");
            ProcessSeccurities();
            if (DateTime.Now.TimeOfDay >= config.Close)
            {
                ProcessNewList();
                ProcessDeList();
            }
            var status = currenStatus.Status;
            if (status == "J" || status == "P" || status == "O" || status == "A")
            {
                _isUpdatedOpenPrice = false;
            }
            else
            {
                _isUpdatedOpenPrice = true;
            }
            if (status == "P" || status == "O" || status == "A" || status == "C" || status == "K")
            {

                if (ProcessTotalMaket())
                {
                    if (DateTime.Today.Date != lastDay)
                    {
                        IsNewDay = true;
                        lastDay = DateTime.Today.Date;
                    }
                    ProcessFRoomInfo();
                    ProcessHoleInfo();
                    ProcessPutAd();
                    ProcessPutExec();
                }
            }
            Logger.ConsoleLog("Finished with {0} message processed", records);
            Logger.Log("Finished with {0} message processed", records);
        }
        #region Securities

        void ProcessSeccurities()
        {
            StringBuilder xml = new StringBuilder();
            db = DatabaseFactory.CreateDatabase();
            if (securityLoader.Open())
            {
                try
                {

                    Securities securities;
                    xml.Append("<ROOT>");
                    string currentstockSymbol = string.Empty;
                    while (securityLoader.Read(out securities))
                    {
                        Logger.Log("-> securities: {0}",
                            JsonConvert.SerializeObject(
                                new
                                {
                                    securities.StockSymbol,
                                    securities.OpenPrice,
                                    securities.LastPrice,
                                    securities.Ceiling
                                }));
                        records++;
                        if (securities.Type != HOSTC_SECTYPE_D)
                        {
                            StockInfo stock = new StockInfo();
                            stock.StockId = "HO" + securities.StockNo.ToString();
                            stock.Symbol = securities.StockSymbol;
                            stock.Date = DateTime.Now;
                            stock.PriceBasic = securities.PriorClosePrice * 10;
                            stock.PriceCeiling = securities.Ceiling * 10;
                            stock.PriceFloor = securities.Floor * 10;
                            int type = StockType(securities.Type);
                            if (currenStatus.Status == "P" || currenStatus.Status == "A")
                            {
                                stock.PriceCurrent = securities.ProjectOpen * 10;
                            }
                            else
                            {
                                stock.PriceCurrent = securities.LastPrice * 10;
                            }
                            stock.Volume = securities.LastVolume * 10;
                            stock.PriceHigh = securities.Highest * 10;
                            stock.PriceLow = securities.Lowest * 10;
                            stock.PriceOpen = securities.OpenPrice * 10;
                            stock.PriceClose = 0;
                            stock.PriceAverage = securities.AveragePrice;
                            stock.TotalVolume = securities.LastVolume * 10;
                            stock.TotalValue = securities.TotalValue * 1000000;
                            stock.Bid1Price = securities.Best1Bid * 10;
                            stock.Bid1Volume = securities.Best1BidVolume * 10;
                            stock.Bid2Price = securities.Best2Bid * 10;
                            stock.Bid2Volume = securities.Best2BidVolume * 10;
                            stock.Bid3Price = securities.Best3Bid * 10;
                            stock.Bid3Volume = securities.Best3BidVolume * 10;
                            stock.Offer1Price = securities.Best1Offer * 10;
                            stock.Offer1Volume = securities.Best1OfferVolume * 10;
                            stock.Offer2Price = securities.Best2Offer * 10;
                            stock.Offer2Volume = securities.Best2OfferVolume * 10;
                            stock.Offer3Price = securities.Best3Offer * 10;
                            stock.Offer3Volume = securities.Best3OfferVolume * 10;
                            if (currentstockSymbol != stock.Symbol)
                            {
                                xml.AppendFormat("<Stock StockID=\"{0}\" Symbol=\"{1}\" Date=\"{2}\" PriceBasic=\"{3}\" PriceCeiling=\"{4}\" PriceFloor=\"{5}\" PriceCurrent=\"{6}\" Volume=\"{7}\" " +
                                        "PriceHigh=\"{8}\" PriceLow=\"{9}\" PriceOpen=\"{10}\" PriceClose=\"{11}\" PriceAverage=\"{12}\" TotalVolume=\"{13}\" TotalValue=\"{14}\" " +
                                        "PriceBid1=\"{15}\" QuantityBid1=\"{16}\" PriceBid2=\"{17}\" QuantityBid2=\"{18}\" PriceBid3=\"{19}\" QuantityBid3=\"{20}\" " +
                                        "PriceOffer1=\"{21}\" QuantityOffer1=\"{22}\" PriceOffer2=\"{23}\" QuantityOffer2=\"{24}\" PriceOffer3=\"{25}\" QuantityOffer3=\"{26}\" " +
                                        "UnderlyingSymbol=\"{27}\" IssuerName=\"{28}\" CoveredWarrantType=\"{29}\" MaturityDate=\"{30}\" LastTradingDate=\"{31}\" ExercisePrice=\"{32}\" ExerciseRatio=\"{33}\" ListedShare=\"{34}\" " +
                                        "></Stock>", stock.StockId, stock.Symbol, stock.Date, stock.PriceBasic, stock.PriceCeiling, stock.PriceFloor, stock.PriceCurrent, stock.Volume, stock.PriceHigh, stock.PriceLow, stock.PriceOpen, stock.PriceClose, stock.PriceAverage, stock.TotalVolume, stock.TotalValue,
                                        stock.Bid1Price, stock.Bid1Volume, stock.Bid2Price, stock.Bid2Volume, stock.Bid3Price, stock.Bid3Volume,
                                        stock.Offer1Price, stock.Offer1Volume, stock.Offer2Price, stock.Offer2Volume, stock.Offer3Price, stock.Offer3Volume
                                        , stock.UnderlyingSymbol, stock.IssuerName, stock.CoveredWarrantType, stock.MaturityDate, stock.LastTradingDate, stock.ExercisePrice, stock.ExerciseRatio, stock.ListedShare);
                            }
                            currentstockSymbol = stock.Symbol;
                            db.ExecuteNonQuery("GW_UpdateSecurities", stock.StockId, securities.StockSymbol, securities.StockName, "HOSTC", type, true);
                        }


                    }
                    xml.Append("</ROOT>");
                }
                catch (Exception ex)
                {
                    Logger.ConsoleLog("Error update/insert stockPrice", records);
                    Logger.Log("Error update/insert stockPrice", ex);

                }
                securityLoader.Close();
                // Bulk Insert To Database
                db.ExecuteNonQuery("HOGW_UpdateStockInfo", xml.ToString());
            }



        }
        #endregion

        #region TotalMaket

        private bool ProcessTotalMaket()
        {
            if (currenStatus == null || currenStatus.Status == "J" && DateTime.Now.TimeOfDay < new TimeSpan(9, 0, 0))
            {
                Database db = DatabaseFactory.CreateDatabase();
                db.ExecuteNonQuery("HOGW_ResetMarketInfo");
                return true;
            }

            if (totalmktLoader.Open())
            {
                string sql =
                    @"SELECT TotalTrade1,TotalVolume1,TotalValue1,Index1,TotalTrade2,TotalVolume2,TotalValue2,Index2,TotalTrade3,TotalVolume3,TotalValue3,Index3 
                       from stock_CurrentMarketInfo i join stock_Markets m on i.MarketID = m.MarketID and m.Symbol = 'HOSTC'";
                SessionsInfo sessionsInfo = new SessionsInfo();
                var info = db.ExecuteScalar(CommandType.Text, sql);
                if (info != null)
                    sessionsInfo = (SessionsInfo)info;

                Totalmkt totalmkt;
                while (totalmktLoader.Read(out totalmkt))
                {
                    string time = totalmkt.Time.ToString("D6");
                    int seconds = int.Parse(time.Substring(4, 2));
                    int minutes = int.Parse(time.Substring(2, 2));
                    int hours = int.Parse(time.Substring(0, 2));
                    double index = ((double)totalmkt.VnIndex) / 100;
                    TimeSpan ts = new TimeSpan(hours, minutes, seconds);
                    MarketInfo market = new MarketInfo
                    {
                        Symbol = "HOSTC",
                        Date = DateTime.Today.Add(ts),
                        TotalTrade = totalmkt.TotalTrade,
                        TotalValue = totalmkt.TotalValues * 1000000,
                        TotalVolume = totalmkt.TotalShares,
                        CurrentIndex = index,
                        Advances = totalmkt.Advences,
                        NoChange = totalmkt.NoChange,
                        Declines = totalmkt.Declines,

                    };
                    db.ExecuteNonQuery("HOGW_UpdateMarketInfo", market.Date, market.Status, market.CurrentIndex, market.TotalTrade, market.TotalVolume, market.TotalValue, market.Advances, market.NoChange, market.Declines);
                    // process Update3SessionsInfo 
                    //if (pts < t1 && ts > t1 && ts < t2)
                    if (currenStatus.Status == "O" || currenStatus.Status == "P" && ts <= t2 && totalmkt.TotalShares != 0 && sessionsInfo.TotalTrade1 == 0)
                    {
                        sessionsInfo.TotalTrade1 = market.TotalTrade;
                        sessionsInfo.TotalValue1 = market.TotalValue;
                        sessionsInfo.TotalVolume1 = market.TotalVolume;
                        sessionsInfo.Index1 = market.CurrentIndex;
                    }

                    if (sessionsInfo.TotalTrade1 != 0.0 && sessionsInfo.TotalTrade3 == 0.0)
                    {
                        sessionsInfo.TotalTrade2 = market.TotalTrade - sessionsInfo.TotalTrade1;
                        sessionsInfo.TotalValue2 = market.TotalValue - sessionsInfo.TotalValue1;
                        sessionsInfo.TotalVolume2 = market.TotalVolume - sessionsInfo.TotalVolume1;
                        sessionsInfo.Index2 = market.CurrentIndex;
                    }

                    if (sessionsInfo.TotalTrade2 != 0.0)
                    {
                        sessionsInfo.TotalTrade3 = market.TotalTrade - (sessionsInfo.TotalTrade1 + sessionsInfo.TotalTrade2);
                        sessionsInfo.TotalValue3 = market.TotalValue - (sessionsInfo.TotalValue1 + sessionsInfo.TotalValue2);
                        sessionsInfo.TotalVolume3 = market.TotalVolume - (sessionsInfo.TotalVolume1 + sessionsInfo.TotalVolume2);
                        sessionsInfo.Index3 = market.CurrentIndex;
                    }
                    return true;
                }
                if (IsNewDay)
                    Reset3SessionsInfo();
                else
                    db.ExecuteNonQuery("HOGW_Update3SessionsInfo",
                        sessionsInfo.TotalTrade1, sessionsInfo.TotalVolume1, sessionsInfo.TotalValue1, sessionsInfo.Index1,
                        sessionsInfo.TotalTrade2, sessionsInfo.TotalVolume2, sessionsInfo.TotalValue2, sessionsInfo.Index2,
                        sessionsInfo.TotalTrade3, sessionsInfo.TotalVolume3, sessionsInfo.TotalValue3, sessionsInfo.Index3);
                totalmktLoader.Close();
            }


            return true;
        }

        #endregion

        #region NewList

        public void ProcessNewList()
        {
            // phai check cuoi ngay
            NewList newList;
            db = DatabaseFactory.CreateDatabase();
            while (newListLoader.Read(out newList))
            {
                int type = StockType(newList.Type);
                db.ExecuteNonQuery("GW_UpdateSecurities", "HO" + newList.StockNo, newList.StockCode, newList.StockName, "HOSTC", type, true);
            }
            newListLoader.Close();
        }

        #endregion

        #region DeList

        public void ProcessDeList()
        {
            // phai check cuoi ngay
            db = DatabaseFactory.CreateDatabase();
            DeList deList;
            while (deListLoader.Read(out deList))
            {
                db.ExecuteNonQuery("GW_UpdateSecuritiesListingStatus", deList.StockCode, false);
            }
            deListLoader.Close();

        }


        #endregion

        #region Put-Add

        public void ProcessPutAd()
        {
            if (putAdLoader.Open() && "POA".Contains(currenStatus.Status))
            {
                db = DatabaseFactory.CreateDatabase();
                PutAd putAd;
                db.ExecuteNonQuery("HOGW_DeleteAllPutAd");
                StringBuilder xml = new StringBuilder();
                xml.Append("<ROOT>");
                while (putAdLoader.Read(out putAd))
                {
                    string t = putAd.Time.ToString();
                    DateTime time = DateTime.Now;
                    if (t != "0")
                    {
                        if (t.Length == 5) t = "0" + t;
                        int seconds = int.Parse(t.Substring(4, 2));
                        int minutes = int.Parse(t.Substring(2, 2));
                        int hours = int.Parse(t.Substring(0, 2));
                        time = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));
                    }
                    xml.AppendFormat("<PutAd TradeID=\"{0}\" StockID=\"{1}\"  Volume=\"{2}\" Price=\"{3}\" FirmNo=\"{4}\" Side=\"{5}\" Board=\"{6}\" Time=\"{7}\" Flag=\"{8}\"></PutAd>",
                        putAd.TradeId, "HO" + putAd.StockNo, putAd.Vol, putAd.Price * 1000, putAd.FirmNo,
                        putAd.Side, putAd.Board, time.ToString("MM/dd/yyyy hh:mm:ss"), putAd.Flag);
                }

                xml.Append("</ROOT>");
                putAdLoader.Close();
                db.ExecuteNonQuery("HOGW_InsertPutAd", xml.ToString());
            }

        }

        #endregion

        #region Put-Exec

        public void ProcessPutExec()
        {
            if (putExecLoader.Open() && "POA".Contains(currenStatus.Status))
            {
                db = DatabaseFactory.CreateDatabase();
                PutExec putExec;
                db.ExecuteNonQuery("HOGW_DeleteAllPutExec");
                StringBuilder xml = new StringBuilder();
                xml.Append("<ROOT>");
                while (putExecLoader.Read(out putExec))
                {
                    xml.AppendFormat("<PutExec ConfirmNo=\"{0}\" StockID=\"{1}\" Volume=\"{2}\" Price=\"{3}\" Board=\"{4}\"></PutExec>", putExec.ConfirmNo, "HO" + putExec.StockNo, putExec.Vol, putExec.Price * 10, putExec.Board);
                }

                xml.Append("</ROOT>");
                putExecLoader.Close();
                db.ExecuteNonQuery("HOGW_InsertPutExec", xml.ToString());
            }


        }



        #endregion

        #region FROOM

        public void ProcessFRoomInfo()
        {

            if (fRoomLoader.Open())
            {
                db = DatabaseFactory.CreateDatabase();
                List<int> stockNoList = new List<int>();
                List<int> stockNoList2 = new List<int>();
                List<double> basicFRoomList = new List<double>();
                List<double> currentFRoomList = new List<double>();
                List<double> sellVolumeFRoomList = new List<double>();
                List<double> buyVolumeFRoomList = new List<double>();
                FRoom fRoom;
                while (fRoomLoader.Read(out fRoom))
                {
                    if (!stockNoList.Contains(fRoom.StockNo))
                    {
                        stockNoList.Add(fRoom.StockNo);
                        basicFRoomList.Add(fRoom.CurrentRoom);
                        sellVolumeFRoomList.Add(fRoom.SellVoume);
                        buyVolumeFRoomList.Add(fRoom.BuyVolume);
                    }
                    else if (!stockNoList2.Contains(fRoom.StockNo))
                    {
                        stockNoList2.Add(fRoom.StockNo);
                        currentFRoomList.Add(fRoom.CurrentRoom);
                        sellVolumeFRoomList.Add(fRoom.SellVoume);
                        buyVolumeFRoomList.Add(fRoom.BuyVolume);
                    }
                    else
                    {
                        int index = stockNoList2.IndexOf(fRoom.StockNo);
                        currentFRoomList[index] = fRoom.CurrentRoom;
                        sellVolumeFRoomList[index] = fRoom.SellVoume;
                        buyVolumeFRoomList[index] = fRoom.BuyVolume;
                    }
                }
                fRoomLoader.Close();
                StringBuilder xml = new StringBuilder();
                xml.Append("<ROOT>");
                for (int i = 0; i < stockNoList.Count; i++)
                {
                    int stockID = stockNoList[i];
                    double basicForeignRoom = basicFRoomList[i];
                    int index = stockNoList2.IndexOf(stockID);

                    if (index > -1)
                    {
                        double currentForeignRoom = currentFRoomList[index];
                        double sellVolume = sellVolumeFRoomList[index];
                        double buyVolume = buyVolumeFRoomList[index];
                        xml.AppendFormat("<FRoom StockID=\"{0}\" CurrentRoom=\"{1}\" BuyForeignQuantity=\"{2}\" SellForeignQuantity=\"{3}\"></FRoom>",
                            "HO" + stockID.ToString(), currentForeignRoom, buyVolume, sellVolume);
                    }
                    else
                    {
                        xml.AppendFormat("<FRoom StockID=\"{0}\" CurrentRoom=\"{1}\" BuyForeignQuantity=\"{2}\" SellForeignQuantity=\"{3}\"></FRoom>",
                            "HO" + stockID.ToString(), basicForeignRoom, 0, 0);
                    }
                }
                xml.Append("</ROOT>");
                db.ExecuteNonQuery("HOGW_UpdateCurrentFRoom", xml.ToString());
            }


        }



        #endregion

        #region LE

        private void ProcessHoleInfo()
        {
            db = DatabaseFactory.CreateDatabase();
            if (currenStatus.Status == "P" && currenStatus.LastTime <= config.PreClose)
            {
                db.ExecuteNonQuery("HOGW_DeleteLEInfo");
            }
            if (leLoader.Open() && currenStatus.Status == "O")
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<ROOT>");
                Le le;
                while (leLoader.Read(out le))
                {
                    string time = le.TimeString;
                    if (time.Length == 5) time = "0" + time;
                    int seconds = int.Parse(time.Substring(4, 2));
                    int minutes = int.Parse(time.Substring(2, 2));
                    int hours = int.Parse(time.Substring(0, 2));
                    DateTime date = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));

                    xml.AppendFormat("<LE StockID=\"{0}\" Date=\"{1}\" Price=\"{2}\" Volume=\"{3}\"></LE>", "HO" + le.StockNo, date.ToString("MM/dd/yyyy hh:mm:ss"), le.Price * 10, le.AccumulatedVol * 10);

                }
                xml.Append("</ROOT>");
                leLoader.Close();
                db.ExecuteNonQuery("HOGW_UpdateLEInfo", xml.ToString());
            }

        }

        #endregion

        #region LS 

        #endregion

        public void Sleep()
        {
            Thread.Sleep(TimeSpan.FromSeconds(config.IntervalPrice));
        }
        public void ResetMarketInfo()
        {
            db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery("HOGW_ResetMarketInfo");
        }

        public void Reset3SessionsInfo()
        {
            db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery("HOGW_Update3SessionsInfo", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public int StockType(string type)
        {
            int t = 1;
            switch (type)
            {
                case "S":
                    t = 1;
                    break;
                case "D":
                    t = 2;
                    break;
                case "U":
                    t = 3;
                    break;
                case "W":
                    t = 5;
                    break;
                case "E":
                    t = 6;
                    break;
                default:
                    t = 9;
                    break;
            }
            return t;
        }
    }
}