namespace DO.Common.Contract
{
    public class DataParserConstants
    {
        public const string ColumnPropertyPattern = @"columns\[(\d+)\]\[data\]";
        public const string OrderPattern = @"order\[(\d+)\]\[column\]";

        public const string Draw = "draw";
        public const string AscendingSort = "asc";
        public const string SearchKey = "search[value]";
        public const string SearchRegexKey = "search[regex]";

        public const string DataPropertyFormat = "columns[{0}][data]";
        public const string SearchablePropertyFormat = "columns[{0}][searchable]";
        public const string OrderablePropertyFormat = "columns[{0}][orderable]";
        public const string SearchValuePropertyFormat = "columns[{0}][search][value]";
        public const string SearchRegexPropertyFormat = "columns[{0}][search][regex]";
        public const string OrderColumnFormat = "order[{0}][column]";
        public const string OrderDirectionFormat = "order[{0}][dir]";
        public const string OrderingEnabled = "ordering";
        public const string Start = "start";
        public const string Length = "length";

        public static string GetKey(string format, int index)
        {
            return string.Format(format, index);
        }

        public static string GetKey(string format, string index)
        {
            return string.Format(format, index);
        }
    }
}
