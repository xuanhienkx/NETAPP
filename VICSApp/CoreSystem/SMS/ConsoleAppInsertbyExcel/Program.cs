using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Common;

namespace ConsoleAppInsertbyExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pass = "E:\\Excel\\2009.xls";
                var excelData = new ExcelData(pass);
                var dataRows = excelData.GetData("2009", true);


                foreach (DataRow row in dataRows.Where(x => !string.IsNullOrEmpty(x[0].ToString())))
                {
                    StringBuilder sqBuilder = new StringBuilder();
                    var sql =
                        "INSERT INTO [dbo].[HOSE_SS]  ([LAST_MODIFIED] ,[MESSAGE_STATUS] ,[MESSAGE_TYPE] ,[SECURITY_NUMBER] ,[SECTOR_NUMBER] ," +
                        "[HALT_RESUME_FLAG] ,[SYSTEM_CONTROL_CODE] ,[SUSPENSION]" +
                        ",[DELIST] ,[CEILING_PRICE] ,[FLOOR_PRICE] ,[SECURITY_TYPE] ,[PRIOR_CLOSE_PRICE],[SPLIT] ,[BENEFIT] " +
                        ",[MEETING] ,[NOTICE]  ,[BOARD_LOT] ,[FILLER]  ,[FILLER1],[FILLER2]," +
                        "[FILLER3],[FILLER4] ,[FILLER5])" +
                        " VALUES (GETDATE(), )";
                    sqBuilder.Append(sql);
                    sqBuilder.AppendFormat("{0},", "R");
                    sqBuilder.AppendFormat("{0},", row["MESSAGE_TYPE"]);
                    sqBuilder.AppendFormat("{0},", row["SECURITY_NUMBER"]);
                    sqBuilder.AppendFormat("{0},", row["SECTOR_NUMBER"]);
                    sqBuilder.AppendFormat("{0},", row["HALT_RESUME_FLAG"]);
                    sqBuilder.AppendFormat("{0},", row["SYSTEM_CONTROL_CODE"]);
                    sqBuilder.AppendFormat("{0},", row["SUSPENSION"]);
                    sqBuilder.AppendFormat("{0},", row["CEILING_PRICE"]);
                    sqBuilder.AppendFormat("{0},", row["FLOOR_PRICE"]);
                    sqBuilder.AppendFormat("{0},", row["SECURITY_TYPE"]);
                    sqBuilder.AppendFormat("{0},", row["PRIOR_CLOSE_PRICE"]);
                    sqBuilder.AppendFormat("{0},", row["SPLIT"]);
                    sqBuilder.AppendFormat("{0},", row["BENEFIT"]);
                    sqBuilder.AppendFormat("{0},", row["MEETING"]);
                    sqBuilder.AppendFormat("{0},", row["NOTICE"]);
                    sqBuilder.AppendFormat("{0},", row["BOARD_LOT"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER1"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER2"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER3"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER4"]);
                    sqBuilder.AppendFormat("{0},", row["FILLER5"]);
                    sqBuilder.Append(" )");
                    Logger.Log(sqBuilder.ToString());
                    Console.WriteLine(sqBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.LogError(ex);
            }
            Console.ReadLine();
        }
    }
}
