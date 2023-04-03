using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace api.unit_test
{
    public class ReadExcel
    {
        public static IList<T> ReadExcelToList<T>() where T : class, new()
        {
            try
            {
                DataTable dtTable = new DataTable();
                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using SpreadsheetDocument doc = SpreadsheetDocument.Open("D:/CodongTest-10.xlsx", true);
                //create the object for workbook part  
                WorkbookPart workbookPart = doc.WorkbookPart;
                var sheetCollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                var isLostData = false;
                //using for each loop to get the sheet from the sheetcollection  
                foreach (var sheet in sheetCollection.OfType<Sheet>())
                {
                    //statement to get the worksheet object by using the sheet id  
                    var theWorksheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;

                    var sheetData = theWorksheet.GetFirstChild<SheetData>();

                    for (var rCnt = 0; rCnt < sheetData.ChildElements.Count(); rCnt++)
                    {
                        var elements = sheetData.ElementAt(rCnt).ChildElements;
                        var rowList = new List<string>();
                        for (int rCnt1 = 0; rCnt1 < elements.Count(); rCnt1++)
                        {

                            var currentCell = (Cell)elements.ElementAt(rCnt1);
                            //statement to take the integer value  
                            if (currentCell.DataType != null)
                            {
                                if (currentCell.DataType == CellValues.SharedString)
                                {
                                    int id;
                                    if (Int32.TryParse(currentCell.InnerText, out id))
                                    {
                                        SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                        if (item.Text == null) continue;
                                        //first row will provide the column name.
                                        if (rCnt == 0)
                                        {
                                            dtTable.Columns.Add(item.Text.Text);
                                        }
                                        else
                                        {
                                            rowList.Add(item.Text.Text);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (rCnt1 == 0)
                                {
                                    isLostData = true;
                                    break;
                                }
                                if (rCnt != 0)//reserved for column values
                                {
                                    rowList.Add(currentCell.InnerText);
                                }

                            }
                        }

                        if (isLostData)
                            break;

                        if (rCnt != 0 && rowList.Count > 0 && !string.IsNullOrEmpty(rowList[0].ToString()))//reserved for column values
                            dtTable.Rows.Add(rowList.ToArray());

                    }

                }

                return ConvertDataTable<T>(dtTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        private static IList<T> ConvertDataTable<T>(DataTable dt)
        {

            IList<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        var propertyInfo = temp.GetProperty(pro.Name);
                        var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                        var rowValue = dr[pro.Name];
                        object safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);

                        pro.SetValue(obj, safeValue, null);
                    }

                }
            }
            return obj;
        }
    }
}