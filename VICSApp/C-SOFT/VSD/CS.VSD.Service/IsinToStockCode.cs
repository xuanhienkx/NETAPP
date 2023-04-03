using CS.Common.Std.Extensions;

namespace CS.VSD.Service
{
    public class IsinToStockCode
    {
        public static string Convert(string isincode)
        {
            var txt = isincode.Substring(2).TrimStartAll("0");
            var code = txt.Substring(0, txt.Length - 1);
            return code;
        }
    }
}