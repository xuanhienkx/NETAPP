using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Transactions;
using Console.App;
using HoseContinentialGT.Messaages;
using Newtonsoft.Json;
using IsolationLevel = System.Transactions.IsolationLevel;
namespace HoseContinentialGT
{
    public class HosePriceTask : ITask
    {
        private readonly HoseConfiguration config;
        private readonly string dealDataFile; 
        private readonly string tradingDate;
        private readonly string datapath;

        private readonly MessageLoader<Securities> securityLoader;
        private readonly MessageLoader<MarketStatus> maketLoader;
        private string maketStaus = "O";
        private bool isStop;

        public HosePriceTask(HoseConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            this.config = config;
            this.tradingDate = DateTime.Today.ToString("dd/MM/yyyy");
            this.datapath = config.PRSPath + @"\datapath.map";
            var prsDirPath = PrsDataPath();
            if (string.IsNullOrEmpty(prsDirPath))
            { 
                securityLoader = new MessageLoader<Securities>(prsDirPath, "SECURITY");
                maketLoader = new MessageLoader<MarketStatus>(prsDirPath, "MARKET_STAT");
            }
        }

        public void Run()
        {

            //if (config.TimeUp.HasValue && config.TimeUp.Value < DateTime.Now.TimeOfDay)
            //{
            //    Logger.ConsoleLog("Time up at {0}!", config.TimeUp.Value);
            //    return;
            //}
            Logger.ConsoleLog("Process Security...");
            var records = 0;
            var transactionOptions = new TransactionOptions { IsolationLevel = IsolationLevel.Snapshot };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
            {
                using (var connection = new SqlConnection(config.SbsConnectionString))
                {
                    connection.Open();
                    var selectCommand = new SqlCommand { CommandType = CommandType.Text, Connection = connection };
                    #region Maket prosess

                    try
                    {

                        if (maketLoader.IsOpen)
                        {
                            MarketStatus market;
                            Logger.ConsoleLog("Process Maket info...");
                            while (maketLoader.Read(out market))
                            {
                                switch (market.ControlCode)
                                {
                                    case 'C':
                                    case 'A':
                                    case 'O':
                                    case 'P':
                                        this.maketStaus = "O";
                                        break;
                                    case 'K':
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
                            }
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
                            while (securityLoader.Read(out securities))
                            {
                                if (securities.StockSymbol.ToUpper() == "SC5")
                                {
                                    bool a = false;
                                }
                                Logger.Log("-> 2C: {0}",
                                    JsonConvert.SerializeObject(
                                        new
                                        {
                                            securities.StockSymbol,
                                            securities.stockName,
                                            securities.OpenPrice,
                                            securities.LastPrice,
                                            securities.Ceiling
                                        }));
                                records++;
                                decimal num2 = Convert.ToDecimal(securities.PriorClosePrice) / 100M;
                                decimal num3 = Convert.ToDecimal(securities.Ceiling) / 100M;
                                decimal num4 = Convert.ToDecimal(securities.Floor) / 100M;
                                decimal num5 = Convert.ToDecimal(securities.OpenPrice) / 100M;
                                decimal num6 = Convert.ToDecimal(securities.LastPrice) / 100M;
                                decimal averagePrice = Convert.ToDecimal(securities.AveragePrice) / 100M;
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
                                                "UPDATE [StockPrice] SET [OpenPrice] = ", num5, ", [ClosePrice] = ", num6,
                                                ", [AveragePrice] = 0 WHERE [TradingDate] = '", tradingDate,
                                                "' AND [StockCode] = '", securities.StockSymbol, "' AND [BoardType] = 'M'"
                                            });
                                    }
                                    else
                                    {
                                        selectCommand.CommandText =
                                            string.Concat(new object[]
                                            {
                                                "UPDATE [StockPrice] SET [BasicPrice] = ", num2, ", [CeilingPrice] = ",
                                                num3, ", [FloorPrice] = ", num4, ", [OpenPrice] = ", num5,
                                                ", [ClosePrice] = ", num6,
                                                ", [AveragePrice] = 0 WHERE [TradingDate] = '", tradingDate,
                                                "' AND [StockCode] = '", securities.StockSymbol, "' AND [BoardType] = 'M'"
                                            });
                                    }

                                }
                                else
                                {
                                    selectCommand.CommandText =
                                        string.Concat(new object[]
                                        {
                                            "INSERT INTO [StockPrice] ( [TradingDate], [StockCode], [StockType], [BoardType], [BasicPrice], [CeilingPrice], [FloorPrice], [OpenPrice], [ClosePrice], [AveragePrice]) VALUES ('",
                                            tradingDate, "','", securities.StockSymbol, "','", securities.StockType,
                                            "','M',", num2, ",", num3,
                                            ",", num4, ",", num5, ",", num6,
                                            ",", averagePrice, ")"
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

                }
                scope.Complete();
            }
            Logger.ConsoleLog("Finished with {0} message processed", records);
            Logger.Log("Finished with {0} message processed", records);
        }

        public void Sleep()
        {
            Thread.Sleep(TimeSpan.FromSeconds(config.IntervalPrice));
        }
        private string PrsDataPath()
        {
            if (!File.Exists(datapath))
            {
                throw new Exception("Kh\x00f4ng t\x00ecm thấy DATAPATH.MAP");
            }
            Logger.ConsoleLog("Process PrsDataPath...");
            var reader = new StreamReader(datapath);
            string s = null;
            char[] buffer = new char[0x12];
            while ((s = reader.ReadLine()) != null)
            {
                StringReader reader2 = new StringReader(s);
                while (reader2.Read(buffer, 0, buffer.Length) == buffer.Length)
                {
                    var dayprsData = new string(buffer, 0, 10);
                    if (!dayprsData.Equals(DateTime.Now.ToString("dd/MM/yyyy"))) continue;
                    var dirDay = new string(buffer, 10, 8);
                    var sFileName = config.PRSPath + @"\" + dirDay + @"\SECURITY.DAT";
                    return sFileName;
                }
            }
            Logger.ConsoleLog("Kh\x00f4ng c\x00f3 thư mục dữ liệu cho ng\x00e0y " + DateTime.Now.ToString("dd/MM/yyyy"));
            Logger.LogError("Kh\x00f4ng c\x00f3 thư mục dữ liệu cho ng\x00e0y " + DateTime.Now.ToString("dd/MM/yyyy"));
            return string.Empty;
        }
    }
}