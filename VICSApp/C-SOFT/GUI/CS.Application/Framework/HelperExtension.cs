using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CS.Common.Std;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;

namespace CS.Application.Framework
{
    public static class HelperExtension
    {
        #region CsvData Parse

        public static DataTable ToCsvDataTable( this string tempPathFile)
        {
            if (!File.Exists(tempPathFile))
                return null;

            var csvBags = File.ReadAllLines(tempPathFile);
            if (csvBags.Length == 0)
            {
                return null; 
            }
            var litsPart = csvBags.Last();
            var lstparts = JsonConvert.DeserializeObject<IList<Part>>(litsPart.Base64Decode());
            var tb = new DataTable();
            var columnNames = lstparts.Select(dict => dict.Name).Distinct();
            tb.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());

            var csvData = csvBags.Where(l => l != litsPart).ToArray();
            foreach (var itemLine in csvData)
            {
                var row = ParseFromCsvFields(lstparts, itemLine, tb.NewRow());
                tb.Rows.Add(row);
            }
            return tb;
        }

        private static DataRow ParseFromCsvFields(IList<Part> parts, string data, DataRow row)
        {
            var idx = 0;
            var pReader = new ItemReader<Part>(parts);
            var start = pReader.Current.Start;
            while (pReader.MoveNext())
            {
                var end = $"{pReader.Current.End}{pReader.Next.Start}";
                var value = data.Between(start, end, idx, out idx);
                start = end;
                row[pReader.Current.Name] = value;
                if (idx >= data.Length)
                    break;
            }
            return row;
        }

        #endregion
    }
}