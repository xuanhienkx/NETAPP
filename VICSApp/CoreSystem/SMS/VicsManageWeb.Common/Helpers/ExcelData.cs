using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Excel;

namespace VicsManageWeb.Common.Helpers
{
    public class ExcelData
    {
        private string path;

        public ExcelData(string path)
        {
            this.path = path;
        }

        private IExcelDataReader GetExcelDataReader(bool isFirstRowAsColumnNames)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader dataReader;

                if (path.EndsWith(".xls"))
                {
                    dataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                }
                else if (path.EndsWith(".xlsx"))
                {
                    dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                }
                else
                {
                    //Throw exception for things you cannot correct
                    throw new FileNotFoundException("The file to be processed is not an Excel file");
                }

                dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;

                return dataReader;
            }
        }

        private DataSet GetExcelDataAsDataSet(bool isFirstRowAsColumnNames)
        {
            return GetExcelDataReader(isFirstRowAsColumnNames).AsDataSet();
        }

        private DataTable GetExcelWorkSheet(string workSheetName, bool isFirstRowAsColumnNames)
        {
            DataSet dataSet = GetExcelDataAsDataSet(isFirstRowAsColumnNames);
            DataTable workSheet = dataSet.Tables[workSheetName];

            if (workSheet == null)
            {
                throw new FileLoadException(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            }

            return workSheet;
        }

        public IEnumerable<DataRow> GetData(string workSheetName = null, bool isFirstRowAsColumnNames = true)
        {
            DataTable workSheet = !string.IsNullOrEmpty(workSheetName) ? GetExcelWorkSheet(workSheetName, isFirstRowAsColumnNames) : GetExcelWorkSheetFirst(isFirstRowAsColumnNames);

            IEnumerable<DataRow> rows = from DataRow row in workSheet.Rows
                                        select row;

            return rows;
        }
        public DataTable GetExcelWorkSheetFirst(bool isFirstRowAsColumnNames = true)
        {
            DataTable workSheet = GetExcelDataAsDataSet(isFirstRowAsColumnNames).Tables[0];
            if (workSheet == null)
                throw new FileLoadException(string.Format("The worksheet 0 does not exist, has an incorrect name, or does not have any data in the worksheet"));
            return workSheet;
        }
    }
}