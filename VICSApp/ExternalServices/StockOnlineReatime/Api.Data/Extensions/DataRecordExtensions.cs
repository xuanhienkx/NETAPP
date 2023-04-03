using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Api.Data.Extensions
{
    public static class DataRecordExtensions
    { 
        public static TOut TryGet<TOut>(this IDataRecord rd, string fieldName,  Func<int, TOut> getValue, TOut @default)
        {
            try
            {
                return getValue(rd.GetOrdinal(fieldName));
            }
            catch
            {
                return @default;
            }
        }
    }
}
