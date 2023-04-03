using HoseContinentialGT.Messaages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Console.App;
using HoseContinentialGT.DAL;
using Newtonsoft.Json;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace HoseContinentialGT
{
    public class HoseMatchTask : ITask
    {
        private readonly HoseConfiguration config;
        private readonly MessageLoader<Message_1I> m1ILoader;
        private readonly MessageLoader<Message_2B> m2BLoader;
        private readonly MessageLoader<Message_2D> m2DLoader;
        private readonly MessageLoader<Message_2E> m2ELoader;
        private readonly MessageLoader<Message_2I> m2ILoader;
        private readonly MessageLoader<Message_2C> m2CLoader;
        private readonly MessageLoader<DataPath> datapathLoader;
        private bool isStop;
        private readonly string dealDataFile;
        private readonly string tradingDate;
        private readonly string datapath;

        private readonly MessageLoader<Securities> securityLoader;
        private readonly MessageLoader<MarketStatus> maketLoader;
        private string maketStaus = "O";
        private string currenMarket = "O";

        public HoseMatchTask(HoseConfiguration config)
        {
            this.config = config;
            this.tradingDate = DateTime.Today.ToString("dd/MM/yyyy");
            this.dealDataFile = config.CTCIPath + @"\DEAL_DATA\astpt02" + DateTime.Today.ToString("ddMMyyyy") + ".txt";
            m1ILoader = new MessageLoader<Message_1I>(config.CTCIPath, "1I", config.CtciFilePrefix);
            m2BLoader = new MessageLoader<Message_2B>(config.CTCIPath, "2B", config.CtciFilePrefix);
            m2DLoader = new MessageLoader<Message_2D>(config.CTCIPath, "2D", config.CtciFilePrefix);
            m2ELoader = new MessageLoader<Message_2E>(config.CTCIPath, "2E", config.CtciFilePrefix);
            m2ILoader = new MessageLoader<Message_2I>(config.CTCIPath, "2I", config.CtciFilePrefix);
            m2CLoader = new MessageLoader<Message_2C>(config.CTCIPath, "2C", config.CtciFilePrefix);
            datapathLoader = new MessageLoader<DataPath>(config.PRSPath, "datapath.map");
            var dayDir = PrsDataPath();
            if (!string.IsNullOrEmpty(dayDir))
            {
                var prsDirPath = Path.Combine(config.PRSPath, dayDir);
                securityLoader = new MessageLoader<Securities>(prsDirPath, "SECURITY.DAT");
                maketLoader = new MessageLoader<MarketStatus>(prsDirPath, "MARKET_STAT.DAT");
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
            Logger.ConsoleLog("Khong co thư mục dữ liệu cho ngay " + DateTime.Now.ToString("dd/MM/yyyy"));
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

            var records = 0;
            var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.Snapshot };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
            {
                using (var connection = new SqlConnection(config.SbsConnectionString))
                {
                    SqlDataAdapter adapter;
                    DataTable table;
                    connection.Open();
                    var selectCommand = new SqlCommand { CommandType = CommandType.Text, Connection = connection };
                    Logger.ConsoleLog("Start execute the price and maket stust process...");
                    #region Maket prosess

                    try
                    {

                        if (maketLoader.Open(5))
                        {
                            MarketStatus market;
                            Logger.ConsoleLog("Process Market info...");
                            while (maketLoader.Read(out market))
                            {
                                switch (market.ControlCode)
                                {
                                    case 'C':
                                    case 'A':
                                    case 'O':
                                    case 'P':
                                    case 'I':
                                    case 'F':
                                        this.maketStaus = "O";
                                        break;
                                    case 'K':
                                    case 'G':
                                    case 'J':
                                        this.maketStaus = "C";
                                        break;
                                }
                                records++;
                                selectCommand.CommandText = "UPDATE [OrderSysStat] SET [MarketStatus] = @MarketStatus WHERE [OrderDate] = @OrderDate AND [BoardType] = @BoardType";
                                selectCommand.Parameters.Clear();
                                selectCommand.Parameters.Add("@MarketStatus", SqlDbType.VarChar).Value = this.maketStaus;
                                selectCommand.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = tradingDate;
                                selectCommand.Parameters.Add("@BoardType", SqlDbType.VarChar).Value = "M";
                                selectCommand.ExecuteNonQuery();
                                this.currenMarket = market.ControlCode.ToString();
                            }
                            Logger.ConsoleLog("-> Current market status: {0}", this.currenMarket);
                            maketLoader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.ConsoleLog(ex.Message);
                        Logger.LogError(ex);
                    }
                    #endregion

                    #region Seccurity

                    if (securityLoader.Open())
                    {
                        try
                        {
                            Securities securities;
                            Logger.ConsoleLog("Process securities...");
                            while (securityLoader.Read(out securities))
                            {
                                Logger.Log("-> security: {0}",
                                    JsonConvert.SerializeObject(
                                        new
                                        {
                                            StockSymbol = securities.StockSymbol,
                                            OpenPrice = securities.OpenPrice,
                                            ClosePrice = securities.PriorClosePrice,
                                            LastPrice = securities.LastPrice,
                                            Ceiling = securities.Ceiling,
                                            AveragePrice = securities.LastPrice,
                                            ProjectOpen = securities.ProjectOpen,
                                            PriorClosePrice = securities.PriorClosePrice
                                        }));
                                records++;

                                decimal average = securities.LastPrice > 0
                                    ? securities.LastPrice
                                    : securities.ProjectOpen > 0 ? securities.ProjectOpen : securities.PriorClosePrice;
                                decimal closePrice = Convert.ToDecimal(securities.PriorClosePrice) / 100M;
                                decimal ceilingPrice = Convert.ToDecimal(securities.Ceiling) / 100M;
                                decimal floorPrice = Convert.ToDecimal(securities.Floor) / 100M;
                                decimal openPrice = Convert.ToDecimal(securities.OpenPrice) / 100M;
                                decimal lastPrice = Convert.ToDecimal(securities.LastPrice) / 100M;//giá khớp
                                decimal averagePrice = Convert.ToDecimal(average) / 100M;
                                if (currenMarket == "J" || currenMarket == "P")
                                {
                                    GLStockCode glStock = new GLStockCode()
                                    {
                                        StockType = securities.StockType.ToString().Trim(),
                                        StockCode = securities.StockSymbol,
                                        BoardLot = securities.BoardLot,
                                        BasicPrice = securities.PriorClosePrice,
                                        ParValue = securities.ParValue,
                                        StockName = securities.StockName,
                                        BoardType = "M",
                                        BoardName = "HOSE",
                                        CeilingPrice = securities.Ceiling,
                                        FloorPrice = securities.Floor,
                                        ShortName = securities.StockSymbol,
                                        StockNameViet = securities.StockName,
                                        ListedVolume = 1000000,
                                        RoomForeigner = 500000
                                    };
                                    string sqlgl = "if not exists(select * from GlStockCode where StockCode = '" + glStock.StockCode + "') \n ";
                                    sqlgl += " insert into GlStockCode(StockCode, StockType, StockName, ParValue, ShortName, BoardType, StockNameViet, StockFee, ListedVolume, RoomForeigner) values('" +
                                        glStock.StockCode + "', '" + glStock.StockType + "', '" + glStock.StockName + "', " + glStock.ParValue + ", '" + glStock.StockCode + "', 'M', N'" + glStock.StockName + "', 1, 1000000,500000) \n";
                                    selectCommand.CommandText = sqlgl;
                                    selectCommand.ExecuteNonQuery();
                                }
                                
                                if (this.maketStaus == "P" || this.maketStaus == "A")
                                {
                                    lastPrice = closePrice;
                                }

                                selectCommand.CommandText =
                                    string.Concat(new object[]
                                    {
                                        "SELECT COUNT(*) FROM [StockPrice] WHERE [TradingDate] ='", tradingDate,
                                        "' AND [StockCode] = '", securities.StockSymbol, "' AND [BoardType] = 'M'"

                                    });

                                if ((int)selectCommand.ExecuteScalar() > 0)
                                {
                                    if (this.maketStaus == "C")
                                    {
                                        selectCommand.CommandText =
                                            string.Concat(new object[]
                                            {
                                                "UPDATE [StockPrice] SET [OpenPrice] = ", openPrice, ", [ClosePrice] = ", lastPrice,
                                                ", [AveragePrice] =  ",averagePrice,",ExercisePrice=",securities.ExercisePrice,
                                                ", [ExerciseRatio] =  '",securities.ExerciseRatio,"',ListedShare=",securities.ListedShare,
                                                " WHERE [TradingDate] = '", tradingDate,
                                                "' AND [StockCode] = '", securities.StockSymbol, "' AND [BoardType] = 'M'"

                                            });
                                    }
                                    else
                                    {
                                        string sql = string.Concat(new object[]
                                            {
                                                "UPDATE [StockPrice] SET [BasicPrice] = ", closePrice, ", [CeilingPrice] = ",ceilingPrice,
                                                ", [FloorPrice] = ", floorPrice, ", [OpenPrice] = ", openPrice, ", [ClosePrice] = ", lastPrice,
                                                ", [AveragePrice] =  ",averagePrice,",ExercisePrice=",securities.ExercisePrice,
                                                ", [ExerciseRatio] =  '",securities.ExerciseRatio,"',ListedShare=",securities.ListedShare,
                                                " WHERE [TradingDate] = '", tradingDate,
                                                "' AND [StockCode] = '", securities.StockSymbol, "' AND [BoardType] = 'M'"
                                            });
                                        selectCommand.CommandText = sql;

                                    }

                                }
                                else
                                {
                                    selectCommand.CommandText =
                                        string.Concat(new object[]
                                        {
                                            "INSERT INTO [StockPrice] ( [TradingDate], [StockCode],[StockNo], [StockType], [BoardType], " +
                                            "[BasicPrice], [CeilingPrice], [FloorPrice], [OpenPrice], [ClosePrice], [AveragePrice],[TransactionDate]," +
                                            "[UnderlyingSymbol],[IssuerName],[CoveredWarrantType],[MaturityDate],[LastTradingDate],[ExercisePrice],[ExerciseRatio],[ListedShare]) " +
                                            "VALUES ('", tradingDate, "','", securities.StockSymbol, "','", securities.StockNo,"','", securities.StockType,
                                            "','M',", closePrice, ",", ceilingPrice,  ",", floorPrice, ",", openPrice, ",", lastPrice,
                                            ",", averagePrice, ",'",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            "','",securities.UnderlyingSymbol,"','",securities.IssueDate,"','",securities.CoveredWarrantType,"','",securities.MaturityDate,"','",
                                            securities.LastTradingDate,"',",securities.ExercisePrice,",'", securities.ExerciseRatio,"',",securities.ListedShare,")"
                                        });

                                }
                                selectCommand.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.ConsoleLog("Error update/insert stockPrice", records);
                            Logger.Log("Error update/insert stockPrice", ex);

                        }
                        securityLoader.Close();
                    }

                    #endregion
                    Logger.ConsoleLog("Start execute the match process...");

                    #region 1I

                    if (m1ILoader.Open())
                    {
                        Message_1I msg_1I;
                        Logger.ConsoleLog("Process 1I...");
                        while (m1ILoader.Read(out msg_1I))
                        {
                            Logger.Log("-> 1I: {0}",
                                JsonConvert.SerializeObject(
                                    new
                                    {
                                        msg_1I.Time,
                                        msg_1I.Firm,
                                        msg_1I.OrderNumber,
                                        msg_1I.CustomerID,
                                        msg_1I.OrderSide,
                                        msg_1I.StockCode,
                                        msg_1I.OrderVolume,
                                        msg_1I.OrderPrice
                                    }));

                            if (msg_1I.Firm != config.Firm)
                            {
                                Logger.ConsoleLog("Expected firm {0} but actually firm {1} does not math", config.Firm, msg_1I.Firm);
                                Logger.LogError("Expected firm {0} but actually firm {1} does not math", config.Firm, msg_1I.Firm);
                                m1ILoader.Close();
                                return;
                            }
                            records++;

                            if (DALHelper.HasTradingOrder(tradingDate, msg_1I.OrderNumber, connection) == false)
                            {
                                decimal orderPrice = msg_1I.OrderPrice;
                                if ((msg_1I.OrderType.Equals("ATO") || msg_1I.OrderType.Equals("ATC")) ||
                                    msg_1I.OrderType.Equals("MP"))
                                {
                                    selectCommand.CommandText =
                                        "SELECT [CeilingPrice], [FloorPrice] FROM [StockPrice] WHERE [TradingDate] = '" +
                                        tradingDate + "' AND [BoardType] = 'M' AND [StockCode] = '" + msg_1I.StockCode +
                                        "'";
                                    using (var reader = selectCommand.ExecuteReader())
                                    {
                                        if (!reader.Read())
                                        {
                                            throw new ApplicationException("Cannot get stock price for " +
                                                msg_1I.StockCode);
                                        }
                                        orderPrice = reader.GetDecimal(msg_1I.OrderSide.Equals("B") ? 0 : 1);
                                    }
                                }

                                DALHelper.InsertTradingOrder(tradingDate, msg_1I.Time, msg_1I.OrderNumber,
                                    msg_1I.OrderType, msg_1I.OrderSide, msg_1I.StockCode, msg_1I.OrderVolume,
                                    orderPrice, msg_1I.CustomerID, msg_1I.PCFlag, "O", 0M, 0M, msg_1I.OrderVolume,
                                    orderPrice, 0M, connection);
                            }
                        }
                        m1ILoader.Close();
                    }

                    #endregion

                    #region 2B

                    if (m2BLoader.Open())
                    {
                        Message_2B msg_2B;
                        Logger.ConsoleLog("Process 2B...");
                        while (m2BLoader.Read(out msg_2B))
                        {
                            Logger.Log("-> 2B: {0}",
                                JsonConvert.SerializeObject(
                                    new
                                    {
                                        msg_2B.Time,
                                        msg_2B.Firm,
                                        msg_2B.OrderNumber
                                    }));
                            records++;

                            selectCommand.CommandText =
                                "UPDATE [TradingOrder] SET [OrderStatus] = 'O' WHERE [OrderDate] = '" + tradingDate +
                                "' AND [OrderNo] = '" + msg_2B.OrderNumber +
                                "' AND [BoardType] = 'M' AND [OrderStatus] = 'E'";

                            Logger.Log("Update orderStatus for trading order {0}", msg_2B.OrderNumber);
                            selectCommand.ExecuteNonQuery();
                        }
                        m2BLoader.Close();
                    }

                    #endregion

                    #region 2D

                    if (m2DLoader.Open())
                    {
                        Message_2D msg_2D;
                        Logger.ConsoleLog("Process 2D...");
                        while (m2DLoader.Read(out msg_2D))
                        {
                            Logger.Log("-> 2D: {0}",
                                 JsonConvert.SerializeObject(
                                     new
                                     {
                                         msg_2D.Time,
                                         msg_2D.Firm,
                                         msg_2D.OrderNumber,
                                         msg_2D.CustomerID,
                                         msg_2D.PCFlag,
                                         msg_2D.Volume,
                                         msg_2D.price
                                     }));
                            records++;

                            selectCommand.CommandText = "SELECT * FROM [TradingOrder] WHERE [OrderDate] = '" +
                                                        tradingDate + "' AND [OrderNo] = '" + msg_2D.OrderNumber +
                                                        "' AND [BoardType] = 'M'";
                            adapter = new SqlDataAdapter(selectCommand);
                            table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                if (!Convert.ToString(table.Rows[0]["CustomerID"]).Equals(msg_2D.CustomerID))
                                {
                                    string branchCode = null;
                                    string tradeCode = null;
                                    selectCommand.CommandText =
                                        "SELECT [BranchCode], [TradeCode] FROM [Customers] WHERE [CustomerID] = @CustomerID";
                                    selectCommand.Parameters.Clear();
                                    selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value =
                                        msg_2D.CustomerID;
                                    using (var reader = selectCommand.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            branchCode = Convert.ToString(reader["BranchCode"]);
                                            tradeCode = Convert.ToString(reader["TradeCode"]);
                                        }
                                    }
                                    selectCommand.CommandText =
                                        "UPDATE [TradingOrder] SET [CustomerID] = @CustomerID, [CustomerBranchCode] = @CustomerBranchCode, [CustomerTradeCode] = @CustomerTradeCode WHERE [OrderDate] = @OrderDate AND [OrderNo] = @OrderNo AND [BoardType] = 'M'";
                                    selectCommand.Parameters.Clear();
                                    selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value =
                                        msg_2D.CustomerID;
                                    if (branchCode != null)
                                    {
                                        selectCommand.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value =
                                            branchCode;
                                    }
                                    else
                                    {
                                        selectCommand.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value =
                                            DBNull.Value;
                                    }
                                    if (tradeCode != null)
                                    {
                                        selectCommand.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value =
                                            tradeCode;
                                    }
                                    else
                                    {
                                        selectCommand.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value =
                                            DBNull.Value;
                                    }
                                    selectCommand.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = tradingDate;
                                    selectCommand.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value =
                                        msg_2D.OrderNumber;
                                    Logger.Log("Update trading order {0}", msg_2D.OrderNumber);
                                    selectCommand.ExecuteNonQuery();
                                    selectCommand.CommandText =
                                        "UPDATE [TradingResult] SET [CustomerID] = @CustomerID, [CustomerBranchCode] = @CustomerBranchCode, [CustomerTradeCode] = @CustomerTradeCode WHERE [OrderDate] = @OrderDate AND [OrderNo] = @OrderNo AND [BoardType] = 'M'";
                                    selectCommand.Parameters.Clear();
                                    selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value =
                                        msg_2D.CustomerID;
                                    if (branchCode != null)
                                    {
                                        selectCommand.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value =
                                            branchCode;
                                    }
                                    else
                                    {
                                        selectCommand.Parameters.Add("@CustomerBranchCode", SqlDbType.VarChar).Value =
                                            DBNull.Value;
                                    }
                                    if (tradeCode != null)
                                    {
                                        selectCommand.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value =
                                            tradeCode;
                                    }
                                    else
                                    {
                                        selectCommand.Parameters.Add("@CustomerTradeCode", SqlDbType.VarChar).Value =
                                            DBNull.Value;
                                    }
                                    selectCommand.Parameters.Add("@OrderDate", SqlDbType.VarChar).Value = tradingDate;
                                    selectCommand.Parameters.Add("@OrderNo", SqlDbType.VarChar).Value =
                                        msg_2D.OrderNumber;
                                    Logger.Log("Update trading result {0}", msg_2D.OrderNumber);
                                    selectCommand.ExecuteNonQuery();
                                    selectCommand.Parameters.Clear();
                                }
                                else
                                {
                                    selectCommand.CommandText =
                                        string.Concat("UPDATE [TradingOrder] SET [PublishedPrice] = '", msg_2D.Price,
                                            "' WHERE [OrderDate] = '", tradingDate, "' AND [OrderNo] = '",
                                            msg_2D.OrderNumber, "' AND [BoardType] = 'M'");
                                    Logger.Log("Update trading order {0}", msg_2D.OrderNumber);
                                    selectCommand.ExecuteNonQuery();
                                }
                            }
                        }
                        m2DLoader.Close();
                    }

                    #endregion

                    #region 2E

                    if (m2ELoader.Open())
                    {
                        Message_2E msg_2E;
                        Logger.ConsoleLog("Process 2E...");
                        while (m2ELoader.Read(out msg_2E))
                        {
                            Logger.Log("-> 2E: {0}",
                                JsonConvert.SerializeObject(
                                    new
                                    {
                                        msg_2E.Time,
                                        msg_2E.Firm,
                                        msg_2E.OrderNumber,
                                        msg_2E.ConfirmNumber,
                                        msg_2E.MatchedPrice,
                                        msg_2E.MatchedVolume,
                                        msg_2E.OrderSide
                                    }));
                            records++;
                            selectCommand.CommandText = "SELECT COUNT(*) FROM [TradingResult] WHERE [OrderDate] = '" +
                                                       tradingDate + "' AND [OrderNo] = '" + msg_2E.OrderNumber + "' AND [ConfirmNo] = '" +
                                                        msg_2E.ConfirmNumber + "' AND [BoardType] = 'M'";
                            if (((int)selectCommand.ExecuteScalar()) <= 0)
                            {
                                selectCommand.CommandText =
                                    "SELECT [CustomerID], [StockCode], [StockType] FROM [TradingOrder] WHERE [OrderDate] = '" +
                                   tradingDate + "' AND [OrderNo] = '" + msg_2E.OrderNumber + "' AND [BoardType] = 'M'";
                                adapter = new SqlDataAdapter(selectCommand);
                                table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count > 0)
                                {
                                    string customerId = Convert.ToString(table.Rows[0]["CustomerID"]);
                                    string stockCode = Convert.ToString(table.Rows[0]["StockCode"]);
                                    string stockType = Convert.ToString(table.Rows[0]["StockType"]);
                                    DALHelper.InsertTradingResult(tradingDate, msg_2E.OrderNumber, msg_2E.ConfirmNumber, msg_2E.Time, msg_2E.OrderSide, stockCode, stockType, customerId, msg_2E.MatchedVolume, msg_2E.MatchedPrice, false,
                                        connection);
                                }
                            }
                        }
                        m2ELoader.Close();
                    }

                    #endregion

                    #region 2I

                    if (m2ILoader.Open())
                    {
                        Message_2I msg_2I;
                        Logger.ConsoleLog("Process 2I...");
                        while (m2ILoader.Read(out msg_2I))
                        {
                            Logger.Log("-> 2I: {0}",
                               JsonConvert.SerializeObject(
                                   new
                                   {
                                       msg_2I.Time,
                                       msg_2I.Firm,
                                       msg_2I.BuyerOrderNumber,
                                       msg_2I.SellerOrderNumber,
                                       msg_2I.ConfirmNumber,
                                       msg_2I.MatchedPrice,
                                       msg_2I.MatchedVolume,
                                   }));
                            records++;

                            selectCommand.CommandText = "SELECT COUNT(*) FROM [TradingResult] WHERE [OrderDate] = '" +
                                                       tradingDate + "' AND [OrderNo] = '" + msg_2I.BuyerOrderNumber + "' AND [ConfirmNo] = '" +
                                                        msg_2I.ConfirmNumber + "' AND [BoardType] = 'M'";
                            if (((int)selectCommand.ExecuteScalar()) <= 0)
                            {
                                selectCommand.CommandText =
                                    "SELECT [CustomerID], [StockCode], [StockType] FROM [TradingOrder] WHERE [OrderDate] = '" +
                                   tradingDate + "' AND [OrderNo] = '" + msg_2I.BuyerOrderNumber + "' AND [BoardType] = 'M'";
                                adapter = new SqlDataAdapter(selectCommand);
                                table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count > 0)
                                {
                                    string customerId = Convert.ToString(table.Rows[0]["CustomerID"]);
                                    string stockCode = Convert.ToString(table.Rows[0]["StockCode"]);
                                    string stockType = Convert.ToString(table.Rows[0]["StockType"]);
                                    DALHelper.InsertTradingResult(tradingDate, msg_2I.BuyerOrderNumber, msg_2I.ConfirmNumber, msg_2I.Time, "B", stockCode, stockType, customerId, msg_2I.MatchedVolume, msg_2I.MatchedPrice, true,
                                        connection);
                                }
                            }
                            selectCommand.CommandText = "SELECT COUNT(*) FROM [TradingResult] WHERE [OrderDate] = '" +
                                                       tradingDate + "' AND [OrderNo] = '" + msg_2I.SellerOrderNumber + "' AND [ConfirmNo] = '" +
                                                        msg_2I.ConfirmNumber + "' AND [BoardType] = 'M'";
                            if (((int)selectCommand.ExecuteScalar()) <= 0)
                            {
                                selectCommand.CommandText =
                                    "SELECT [CustomerID], [StockCode], [StockType] FROM [TradingOrder] WHERE [OrderDate] = '" +
                                   tradingDate + "' AND [OrderNo] = '" + msg_2I.SellerOrderNumber + "' AND [BoardType] = 'M'";
                                adapter = new SqlDataAdapter(selectCommand);
                                table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count > 0)
                                {
                                    string customerId = Convert.ToString(table.Rows[0]["CustomerID"]);
                                    string stockCode = Convert.ToString(table.Rows[0]["StockCode"]);
                                    string stockType = Convert.ToString(table.Rows[0]["StockType"]);
                                    DALHelper.InsertTradingResult(tradingDate, msg_2I.SellerOrderNumber, msg_2I.ConfirmNumber, msg_2I.Time, "S", stockCode, stockType, customerId, msg_2I.MatchedVolume, msg_2I.MatchedPrice, true,
                                        connection);
                                }
                            }
                        }
                        m2ILoader.Close();
                    }

                    #endregion

                    #region Fee

                    DALHelper.UpdateFee(tradingDate, new List<string>() { "S", "U","E","W" }, connection);
                    DALHelper.UpdateFee(tradingDate, new List<string>() { "D" }, connection);


                    adapter = new SqlDataAdapter(
                            "SELECT * FROM [TradingOrder] WHERE [OrderDate] = '" + tradingDate + "' AND [BoardType] = 'M'",
                            connection);
                    table = new DataTable();
                    adapter.Fill(table);
                    for (int k = 0; k < table.Rows.Count; k++)
                    {
                        string orderNo = table.Rows[k]["OrderNo"].ToString();
                        string orderType = table.Rows[k]["OrderType"].ToString();
                        string orderSide = table.Rows[k]["OrderSide"].ToString();
                        string stockCode = table.Rows[k]["StockCode"].ToString();
                        decimal orderVolume = Convert.ToDecimal(table.Rows[k]["OrderVolume"]);
                        decimal orderPrice = Convert.ToDecimal(table.Rows[k]["OrderPrice"]);
                        string customerId = table.Rows[k]["CustomerID"].ToString();
                        bool hasOrderSeq = DBNull.Value.Equals(table.Rows[k]["OrderSeq"]);

                        var sqlstr = "SELECT ISNULL(SUM([MatchedVolume]), 0) [MatchedVolume], ISNULL(SUM([MatchedValue]), 0)  [MatchedValue], ISNULL(MAX([FeeRate]), 0) [FeeRate] FROM [TradingResult] " +
                                string.Format(" WHERE [OrderDate] = '{0}' AND [BoardType] = 'M' AND [OrderNo] = '{1}'", tradingDate, orderNo);
                        decimal matchedVolume = 0M;
                        decimal matchedValue = 0M;
                        decimal feeRate = 0M;
                        SqlDataReader reader3 = DALHelper.DataReader(sqlstr, connection);
                        if (reader3.Read())
                        {
                            matchedVolume = Convert.ToDecimal(reader3["MatchedVolume"]);
                            matchedValue = Convert.ToDecimal(reader3["MatchedValue"]);
                            feeRate = Convert.ToDecimal(reader3["FeeRate"]);
                        }
                        reader3.Close();
                        decimal tradeVolume = orderVolume - matchedVolume;
                        string statusMatched = "";
                        string statusNotMathed = "";
                        if (tradeVolume == 0M)
                        {
                            statusMatched = ", [OrderStatus] = 'M'";
                            statusNotMathed = " OR [OrderStatus] <> 'M'";
                        }
                        if (hasOrderSeq)
                        {
                            sqlstr =
                                string.Concat(new object[]
                                {
                                          "SELECT * FROM [StockOrder] WHERE [OrderDate] = '", tradingDate,
                                          "' AND [BoardType] = 'M' AND [OrderNo] IS NULL AND [OrderType] = '", orderType,
                                          "' AND [OrderSide] = '", orderSide, "' AND [StockCode] = '", stockCode,
                                          "' AND [OrderVolume] = ", orderVolume, " AND [OrderPrice] = ", orderPrice,
                                          " AND [CustomerID] = '", customerId,
                                          "' AND [OrderStatus] <> 'P' AND [OrderStatus] <> 'H' AND [OrderStatus] <> 'X' AND [OrderStatus] <> 'D' AND [OrderStatus] <> 'R'"
                                });
                            SqlDataReader reader4 = DALHelper.DataReader(sqlstr, connection);
                            if (reader4.Read())
                            {
                                int orderSeq = Convert.ToInt32(reader4["OrderSeq"]);
                                string branchCode = reader4["BranchCode"].ToString();
                                string tradeCode = reader4["TradeCode"].ToString();
                                reader4.Close();
                                sqlstr =
                                    string.Concat(new object[]
                                    {
                                              "UPDATE [StockOrder] SET [OrderNo] = '", orderNo, "' WHERE [OrderDate] = '", tradingDate,
                                              "' AND [OrderSeq] = ", orderSeq
                                    });
                                DALHelper.ExecuteNonQuery(sqlstr, connection);
                                sqlstr = string.Concat(new object[]
                                {
                                          "UPDATE [TradingOrder] SET [OrderSeq] = ", orderSeq, ", [BranchCode] = '", branchCode,
                                          "', [TradeCode] = '", tradeCode, "', [MatchedVolume] = ", matchedVolume, ", [MatchedValue] = ",
                                          matchedValue, ", [FeeRate] = ", feeRate, ", [PublishedVolume] = ", tradeVolume, statusMatched,
                                          " WHERE [OrderDate] = '",
                                          tradingDate, "' AND [OrderNo] = '", orderNo, "' AND [BoardType] = 'M'"
                                });

                                DALHelper.ExecuteNonQuery(sqlstr, connection);
                                sqlstr =
                                     string.Concat(new object[]
                                    {
                                              "UPDATE [TradingResult] SET [OrderSeq] = ", orderSeq, ", [BranchCode] = '", branchCode,
                                              "', [TradeCode] = '", tradeCode, "' WHERE [OrderDate] = '", tradingDate,
                                              "' AND [OrderNo] = '", orderNo, "' AND [BoardType] = 'M'"
                                    });
                                DALHelper.ExecuteNonQuery(sqlstr, connection);
                            }
                            else
                            {
                                reader4.Close();
                                sqlstr = string.Concat(new object[]
                                {
                                          "UPDATE [TradingOrder] SET [MatchedVolume] = ", matchedVolume, ", [MatchedValue] = ", matchedValue,
                                          ", [FeeRate] = ", feeRate, ", [PublishedVolume] = ", tradeVolume, statusMatched,
                                          " WHERE [OrderDate] = '", tradingDate, "' AND [OrderNo] = '", orderNo,
                                          "' AND [BoardType] = 'M' AND ([MatchedVolume] <> ", matchedVolume, " OR [MatchedValue] <> ",
                                          matchedValue, " OR [FeeRate] <> ", feeRate, " OR [PublishedVolume] <> ", tradeVolume, statusNotMathed, ")"
                                });
                                DALHelper.ExecuteNonQuery(sqlstr, connection);
                            }
                        }
                        else
                        {
                            int orderSeq = Convert.ToInt32(table.Rows[k]["OrderSeq"]);
                            string branchCode = table.Rows[k]["BranchCode"].ToString();
                            string tradeCode = table.Rows[k]["TradeCode"].ToString();
                            sqlstr = string.Concat(new object[]
                            {
                                      " UPDATE [TradingOrder] SET [MatchedVolume] = ", matchedVolume, ", [MatchedValue] = ", matchedValue,
                                      ", [FeeRate] = ", feeRate, ", [PublishedVolume] = ", tradeVolume, statusMatched,
                                      " WHERE [OrderDate] = '", tradingDate, "' AND [OrderNo] = '", orderNo,
                                      "' AND [BoardType] = 'M' AND ([MatchedVolume] <> ", matchedVolume, " OR [MatchedValue] <> ",
                                      matchedValue, " OR [FeeRate] <> ", feeRate, " OR [PublishedVolume] <> ", tradeVolume, statusNotMathed, "); "
                            });
                            sqlstr +=
                                 string.Concat(new object[]
                                {
                                          " UPDATE [TradingResult] SET [OrderSeq] = ", orderSeq, ", [BranchCode] = '", branchCode,
                                          "', [TradeCode] = '", tradeCode, "' WHERE [OrderDate] = '", tradingDate, "' AND [OrderNo] = '",
                                          orderNo, "' AND [BoardType] = 'M' AND [OrderSeq] IS NULL"
                                });
                            DALHelper.ExecuteNonQuery(sqlstr, connection);
                        }
                    }

                    #endregion

                    #region 2C

                    if (m2CLoader.Open())
                    {
                        Message_2C msg_2C;
                        Logger.ConsoleLog("Process 2I...");
                        while (m2CLoader.Read(out msg_2C))
                        {
                            Logger.Log("-> 2C: {0}",
                             JsonConvert.SerializeObject(
                                 new
                                 {
                                     msg_2C.Time,
                                     msg_2C.Firm,
                                     msg_2C.OrderNumber,
                                     msg_2C.CancelledVolume,
                                     msg_2C.Status
                                 }));
                            records++;

                            selectCommand.CommandText =
                                string.Concat(new object[]
                                {
                                          "UPDATE [TradingOrder] SET [PublishedVolume] = 0, [PublishedPrice] = 0, [CancelledVolume] = ",
                                          msg_2C.CancelledVolume, ", [OrderStatus] = 'C' WHERE [OrderDate] = '", tradingDate, "' AND [OrderNo] = '",
                                          msg_2C.OrderNumber, "' AND [BoardType] = 'M' AND [OrderStatus] <> 'C'"
                                });
                            selectCommand.ExecuteNonQuery();
                        }
                        m2CLoader.Close();
                    }

                    #endregion

                    #region DEAL data

                    if (File.Exists(dealDataFile))
                    {
                        Logger.ConsoleLog("Process Deal Data...");
                        var reader = new StreamReader(dealDataFile);
                        string lineContent = null;
                        while ((lineContent = reader.ReadLine()) != null)
                        {
                            if (!tradingDate.Equals(lineContent.Substring(14, 10).Trim()))
                            {
                                throw new ApplicationException("Kh\x00f4ng phải dữ liệu giao dịch ng\x00e0y " + tradingDate);
                            }
                            string confirmNo = lineContent.Substring(0, 6).Trim();
                            string orderTime = lineContent.Substring(6, 8).Trim();
                            string status = lineContent.Substring(0x25, 2);
                            string stockCode = lineContent.Substring(0x27, 8).Trim();
                            int buyerFirmNo = Convert.ToInt32(lineContent.Substring(0x20, 2));
                            int sellerFirmNo = Convert.ToInt32(lineContent.Substring(0x22, 2));
                            string buyerCustomerId = lineContent.Substring(60, 10);
                            string sellerCustomerId = lineContent.Substring(70, 10);
                            decimal orderVolume = 0M;
                            decimal orderPrice = Convert.ToDecimal(lineContent.Substring(0x2f, 13));

                            decimal volume1 = Convert.ToDecimal(lineContent.Substring(0x5d, 8));
                            decimal volume2 = Convert.ToDecimal(lineContent.Substring(0x65, 8));
                            decimal volume3 = Convert.ToDecimal(lineContent.Substring(0x6d, 8));
                            decimal volume4 = Convert.ToDecimal(lineContent.Substring(0x75, 8));
                            decimal volume5 = Convert.ToDecimal(lineContent.Substring(0x9d, 8));
                            decimal volume9 = Convert.ToDecimal(lineContent.Substring(0xad, 8));
                            decimal volume10 = Convert.ToDecimal(lineContent.Substring(0xb5, 8));

                            string sellerPcFlag = "C";
                            string buyerPcFlag = "C";
                            if (volume1 > 0M)
                            {
                                orderVolume = volume1;
                                buyerPcFlag = "P";
                            }
                            else if (volume3 > 0M)
                            {
                                orderVolume = volume3;
                                buyerPcFlag = "M";
                            }
                            else if (volume4 > 0M)
                            {
                                orderVolume = volume4;
                                buyerPcFlag = "F";
                            }
                            else
                            {
                                orderVolume = volume2;
                            }
                            if (volume5 > 0M)
                            {
                                sellerPcFlag = "P";
                            }
                            else if (volume9 > 0M)
                            {
                                sellerPcFlag = "M";
                            }
                            else if (volume10 > 0M)
                            {
                                sellerPcFlag = "F";
                            }

                            if (((orderVolume != 0M) && !"DC".Equals(status)) && !"X ".Equals(status))
                            {
                                bool isCross = buyerFirmNo == sellerFirmNo;
                                selectCommand.CommandText =
                                    "SELECT [StockType] FROM [GLStockCode] WHERE [StockCode] = @StockCode";
                                selectCommand.Parameters.Clear();
                                selectCommand.Parameters.Add("@StockCode", SqlDbType.VarChar).Value = stockCode;
                                object stockObj = selectCommand.ExecuteScalar();
                                if (stockObj == null)
                                {
                                    // throw new ApplicationException("Kh\x00f4ng thể x\x00e1c định loại chứng kho\x00e1n m\x00e3 " + stockCode);
                                    throw new ApplicationException("Không thể xác định loại chứng khoán mã " + stockCode);
                                }
                                string stockType = (string)stockObj;

                                // buyer
                                if (buyerFirmNo == config.Firm)
                                {
                                    string buyerOrderNo = "PT" + confirmNo + "B";
                                    selectCommand.CommandText =
                                        "SELECT COUNT(*) FROM [TradingOrder] WHERE [OrderDate] = '" + tradingDate +
                                        "' AND [OrderNo] = '" + buyerOrderNo + "' AND [BoardType] = 'M'";
                                    if (((int)selectCommand.ExecuteScalar()) <= 0)
                                    {
                                        DALHelper.InsertTradingOrder(tradingDate, orderTime, buyerOrderNo, "PT", "B", stockCode, orderVolume,
                                            orderPrice, buyerCustomerId, buyerPcFlag, "M", orderVolume,
                                            (orderVolume * orderPrice) * 1000M, 0M, 0M, 0M, connection);
                                        DALHelper.InsertTradingResult(tradingDate, buyerOrderNo, confirmNo, orderTime, "B", stockCode, stockType, buyerCustomerId, orderVolume,
                                            orderPrice, isCross, connection);
                                    }
                                }

                                // seller
                                if (sellerFirmNo == config.Firm)
                                {
                                    string sellerOrderNo = "PT" + confirmNo + "S";
                                    selectCommand.CommandText =
                                        "SELECT COUNT(*) FROM [TradingOrder] WHERE [OrderDate] = '" + tradingDate +
                                        "' AND [OrderNo] = '" + sellerOrderNo + "' AND [BoardType] = 'M'";
                                    if (((int)selectCommand.ExecuteScalar()) <= 0)
                                    {
                                        DALHelper.InsertTradingOrder(tradingDate, orderTime, sellerOrderNo, "PT", "S", stockCode, orderVolume,
                                            orderPrice, sellerCustomerId, sellerPcFlag, "M", orderVolume,
                                            (orderVolume * orderPrice) * 1000M, 0M, 0M, 0M, connection);
                                        DALHelper.InsertTradingResult(tradingDate, sellerOrderNo, confirmNo, orderTime, "S", stockCode, stockType, sellerCustomerId, orderVolume,
                                            orderPrice, isCross, connection);
                                    }
                                }
                            }
                        }
                    }
                    const string selectCommandText = "SELECT [CustomerID] FROM [TradingOrder] WHERE [BoardType] = 'M' AND ([CustomerBranchCode] IS NULL OR [CustomerTradeCode] IS NULL) GROUP BY [CustomerID]";
                    adapter = new SqlDataAdapter(selectCommandText, connection);
                    table = new DataTable();
                    adapter.Fill(table);
                    for (int m = 0; m < table.Rows.Count; m++)
                    {
                        string customerId = Convert.ToString(table.Rows[m]["CustomerID"]);
                        selectCommand.CommandText =
                            "SELECT [BranchCode], [TradeCode] FROM [Customers] WHERE [CustomerID] = @CustomerID";
                        selectCommand.Parameters.Clear();
                        selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
                        string branchCode = null;
                        string tradeCode = null;
                        using (SqlDataReader reader6 = selectCommand.ExecuteReader())
                        {
                            if (reader6.Read())
                            {
                                branchCode = Convert.ToString(reader6["BranchCode"]);
                                tradeCode = Convert.ToString(reader6["TradeCode"]);
                            }
                        }
                        if (branchCode != null)
                        {
                            selectCommand.CommandText =
                                "UPDATE [TradingOrder] SET [CustomerBranchCode] = @BranchCode,[CustomerTradeCode] = @TradeCode WHERE [CustomerID] = @CustomerID";
                            selectCommand.Parameters.Clear();
                            selectCommand.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = branchCode;
                            selectCommand.Parameters.Add("@TradeCode", SqlDbType.VarChar).Value = tradeCode;
                            selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
                            selectCommand.ExecuteNonQuery();
                            selectCommand.CommandText =
                                "UPDATE [TradingResult] SET [CustomerBranchCode] = @BranchCode,[CustomerTradeCode] = @TradeCode WHERE [CustomerID] = @CustomerID";
                            selectCommand.Parameters.Clear();
                            selectCommand.Parameters.Add("@BranchCode", SqlDbType.VarChar).Value = branchCode;
                            selectCommand.Parameters.Add("@TradeCode", SqlDbType.VarChar).Value = tradeCode;
                            selectCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = customerId;
                            selectCommand.ExecuteNonQuery();
                        }
                    }

                    #endregion

                }

                scope.Complete();

                Logger.ConsoleLog("Finished with {0} message processed", records);
                Logger.Log("Finished with {0} message processed", records);
            }
        }
        
        public void Sleep()
        {
            Thread.Sleep(TimeSpan.FromSeconds(config.Interval));
        }

    }
}
