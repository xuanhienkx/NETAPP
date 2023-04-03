using api.common.Models;
using api.common.Settings;
using api.common.Shared.Interfaces;
using DnsClient.Internal;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace api.resources.Services
{
    public class ReadExcelService : ILoadDataService
    {
        private readonly ApplicationSettings settings;
        private readonly ILogger<ReadExcelService> logger;

        public ReadExcelService(ApplicationSettings settings, ILogger<ReadExcelService> logger)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public IList<T> ReadFromFile<T>(MediaResource media) where T : class, new()
        {
            var fileFullName = Path.Combine(settings.DataFileLocation, media.FileId);

            DataTable dtTable = new DataTable();
            //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
            using SpreadsheetDocument doc = SpreadsheetDocument.Open(fileFullName, true);
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
                    var rowList = new List<string>();
                    for (int rCnt1 = 0; rCnt1
                                        < sheetData.ElementAt(rCnt).ChildElements.Count(); rCnt1++)
                    {

                        var currentCell = (Cell)sheetData.ElementAt(rCnt).ChildElements.ElementAt(rCnt1);
                        //statement to take the integer value  
                        if (currentCell.DataType != null)
                        {
                            if (currentCell.DataType == CellValues.SharedString)
                            {
                                if (Int32.TryParse(currentCell.InnerText, out var id))
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
        private IList<T> ConvertDataTable<T>(DataTable dt)
        {

            IList<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
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
                        logger.LogDebug($"map data ==>> {pro.Name}: {rowValue}");
                        object safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);

                        pro.SetValue(obj, safeValue, null);
                    }

                }
            }
            return obj;
        }
    }
}