using System.Collections.Generic;
using System.Linq;
using SMS.DataAccess.Models;
using VicsManageWeb.Common.Helpers;

namespace VICS.Manager.WebApp.Models
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

        public IEnumerable<CustomerViewModel> GetData(bool isFirstRowAsColumnNames = true)
        {
            var excelData = new ExcelData(path);
            var dataRows = excelData.GetData(worksheetName, isFirstRowAsColumnNames);

            return dataRows.Where(x => !string.IsNullOrEmpty(x[0].ToString())).Select(dataRow => new CustomerViewModel()
            {
                Id = dataRow[0].ToString(),
                CustomerName = dataRow[1].ToString(),
                Mobile = dataRow[2].ToString(),
                MessageContent = dataRow[3].ToString()
            }).ToList();
        }
    }
}