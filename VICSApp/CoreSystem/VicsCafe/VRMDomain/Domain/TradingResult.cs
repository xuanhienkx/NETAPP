using System;
using System.Data;
using System.Data.SqlClient;

namespace VRMDomain.Domain
{
    public class TradingResult
    {
        public static DataSet GetSummaryTrading(DateTime callDate)
        {
            var pCallDate = new SqlParameter("@date", SqlDbType.DateTime) { Value = callDate.Date };
            DataSet result = DBUtil.SPExecuteDataSet("GetTradingByDay", pCallDate);
            return result;
        } 
    }
}