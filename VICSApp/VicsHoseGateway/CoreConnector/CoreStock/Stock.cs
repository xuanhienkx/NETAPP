using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CoreStock
{
    public class CoreBoardType
    {
        public CoreBoardType(string boardName, string boardType)
        {
            BoardType = boardType;
            BoardName = boardType + " - " + boardName;
        }
        public string BoardName { get; set; }
        public string BoardType { get; set; }
    }
    public class CoreStockOrderCancel
    {
        public string OrderDate{ get; set; }
        public int OrderSeq { get; set; }
        public string OrderStatus{ get; set; }        
    }
    public class CoreStockOrderChange
    {
        public string OrderDate { get; set; }
        public int OrderSeq { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerIDNew { get; set; }
    }
    public class CoreStockData
    {
        public string Split { get; set; }
        public string Suspension { get; set; }
        public string Halt { get; set; }
        public string Delist { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string StockType { get; set; }
        public string StockBoard { get; set; }
    }
    public class CoreStockPrice
    {
        public string StockCode { get; set; }
        public string TradingDate { get; set; }
        public double CeilingPrice { get; set; }
        public double BasicPrice { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public double FloorPrice { get; set; }
    }
    public class CoreStock
    {        
        /// <summary>
        /// Cac thong tin ve ma chung khoan va gia su dung trong cac ham duoi day
        /// duoc lay tu CORE (SBS)
        /// Duoc su dung trong truong hop khong lay duoc thong tin tu HOSE GW database
        /// </summary>        
        public static DataSet getStockCodes(string stockType, string boardType)
        {
            string sql = "SELECT [StockCode],[StockType],[StockName],[ParValue],[BoardType] "+
                            ",[StockNameViet],[StockFee],[ListedVolume],[RoomForeigner] "+
                            "FROM [GLStockCode] "+
                            "where StockType = @StockType and BoardType = @BoardType order by StockCode";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@StockType", DbType.String, stockType);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, boardType);
            return DbCore.ExecuteDataSet(cmd);            
        }
        public static DataSet getStockCodes(string boardType)
        {
            string sql = "SELECT [StockCode],[StockType],[StockName],[ParValue],[BoardType] " +
                            ",[StockNameViet],[StockFee],[ListedVolume],[RoomForeigner] " +
                            "FROM [GLStockCode] " +
                            "where BoardType = @BoardType order by StockCode";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, boardType);
            return DbCore.ExecuteDataSet(cmd);
        }
        public static DataSet getStockPrices(string stockType, string boardType)
        {
            string sql = "SELECT [TradingDate],[StockCode],[StockType] "+
                              ",[BoardType],[OpenPrice],[ClosePrice],[BasicPrice] "+
                              ",[CeilingPrice],[FloorPrice],[AveragePrice],[TransactionDate] "+
                          "FROM [StockPrice] where convert(DateTime,TradingDate,103) > getdate() - 1 " +
                            "and StockType = @StockType and BoardType = @BoardType order by StockCode";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@StockType", DbType.String, stockType);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, boardType);
            return DbCore.ExecuteDataSet(cmd);
        }
        public static DataSet getStockPrices(string boardType)
        {
            string sql = "SELECT [TradingDate],[StockCode],[StockType] " +
                              ",[BoardType],[OpenPrice],[ClosePrice],[BasicPrice] " +
                              ",[CeilingPrice],[FloorPrice],[AveragePrice],[TransactionDate] " +
                          "FROM [StockPrice] where convert(DateTime,TradingDate,103) > getdate() - 1 " +
                            "and BoardType = @BoardType order by StockCode";
            Database DbCore = DatabaseFactory.CreateDatabase("ConnStrCore");
            DbCommand cmd = DbCore.GetSqlStringCommand(sql);
            DbCore.AddInParameter(cmd, "@BoardType", DbType.String, boardType);
            return DbCore.ExecuteDataSet(cmd);
        }        
    }    
}
