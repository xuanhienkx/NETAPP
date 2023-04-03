using System.Collections.Generic;
using System.Linq;
using SMS.DataAccess.Models;

namespace VicsManageWeb.Common.Helpers
{
    public class ReadExcelData
    {
        private readonly string path;
        private readonly string worksheetName;

        public ReadExcelData(string path)
        {
            this.path = path;
        }
        public ReadExcelData(string path, string worksheetName)
        {
            this.path = path;
            this.worksheetName = worksheetName;
        }

        public IEnumerable<SmsCustomer> GetData(bool isFirstRowAsColumnNames = true)
        {
            var excelData = new ExcelData(path);
            var dataRows = excelData.GetData(worksheetName, isFirstRowAsColumnNames);

            return dataRows.Select(dataRow => new SmsCustomer()
            {
                CustomerName = dataRow["CustomerName"].ToString(),
                Id = dataRow["CustomerId"].ToString(),
                Mobile = dataRow["Mobile"].ToString()
            }).ToList();
        } 
    }
}