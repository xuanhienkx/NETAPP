using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.SwiftParser
{
    public static class LatinEncoder
    {
        private static readonly Lazy<IDictionary<string, string>> LatinDictionary = new Lazy<IDictionary<string, string>>(ValueFactory);

        private static IDictionary<string, string> ValueFactory()
        {
            return new Dictionary<string, string>
            {
                {"Ă","?AW?"},
                {"ă","?aw?"},
                {"Ơ","?OW?"},
                {"ơ","?ow?"},
                {"Ư","?UW?"},
                {"ư","?uw?"},
                {"Â","?AA?"},
                {"â","?aa?"},
                {"Ô","?OO?"},
                {"ô","?oo?"},
                {"Ê","?EE?"},
                {"ê","?ee?"},
                {"À","?AF?"},
                {"Á","?AS?"},
                {"Ả","?AR?"},
                {"Ã","?AX?"},
                {"Ạ","?AJ?"},
                {"à","?af?"},
                {"á","?as?"},
                {"ả","?ar?"},
                {"ã","?ax?"},
                {"ạ","?aj?"},
                {"Ầ","?AAF?"},
                {"Ấ","?AAS?"},
                {"Ẩ","?AAR?"},
                {"Ẫ","?AAX?"},
                {"Ậ","?AAJ?"},
                {"ầ","?aaf?"},
                {"ấ","?aas?"},
                {"ẩ","?aar?"},
                {"ẫ","?aax?"},
                {"ậ","?aaj?"},
                {"Ằ","?AWF?"},
                {"Ắ","?AWS?"},
                {"Ẳ","?AWR?"},
                {"Ẵ","?AWX?"},
                {"Ặ","?AWJ?"},
                {"ằ","?awf?"},
                {"ắ","?aws?"},
                {"ẳ","?awr?"},
                {"ẵ","?awx?"},
                {"ặ","?awj?"},
                {"Đ","?DD?"},
                {"đ","?dd?"},
                {"È","?EF?"},
                {"É","?ES?"},
                {"Ẻ","?ER?"},
                {"Ẽ","?EX?"},
                {"Ẹ","?EJ?"},
                {"è","?ef?"},
                {"é","?es?"},
                {"ẻ","?er?"},
                {"ẽ","?ex?"},
                {"ẹ","?ej?"},
                {"Ề","?EEF?"},
                {"Ế","?EES?"},
                {"Ể","?EER?"},
                {"Ễ","?EEX?"},
                {"Ệ","?EEJ?"},
                {"ề","?eef?"},
                {"ế","?ees?"},
                {"ể","?eer?"},
                {"ễ","?eex?"},
                {"ệ","?eej?"},
                {"Ì","?IF?"},
                {"Í","?IS?"},
                {"Ỉ","?IR?"},
                {"Ĩ","?IX?"},
                {"Ị","?IJ?"},
                {"ì","?if?"},
                {"í","?is?"},
                {"ỉ","?ir?"},
                {"ĩ","?ix?"},
                {"ị","?ij?"},
                {"Ò","?OF?"},
                {"Ó","?OS?"},
                {"Ỏ","?OR?"},
                {"Õ","?OX?"},
                {"Ọ","?OJ?"},
                {"ò","?of?"},
                {"ó","?os?"},
                {"ỏ","?or?"},
                {"õ","?ox?"},
                {"ọ","?oj?"},
                {"Ồ","?OOF?"},
                {"Ố","?OOS?"},
                {"Ổ","?OOR?"},
                {"Ỗ","?OOX?"},
                {"Ộ","?OOJ?"},
                {"ồ","?oof?"},
                {"ố","?oos?"},
                {"ổ","?oor?"},
                {"ỗ","?oox?"},
                {"ộ","?ooj?"},
                {"Ờ","?OWF?"},
                {"Ớ","?OWS?"},
                {"Ở","?OWR?"},
                {"Ỡ","?OWX?"},
                {"Ợ","?OWJ?"},
                {"ờ","?owf?"},
                {"ớ","?ows?"},
                {"ở","?owr?"},
                {"ỡ","?owx?"},
                {"ợ","?owj?"},
                {"Ù","?UF?"},
                {"Ú","?US?"},
                {"Ủ","?UR?"},
                {"Ũ","?UX?"},
                {"Ụ","?UJ?"},
                {"ù","?uf?"},
                {"ú","?us?"},
                {"ủ","?ur?"},
                {"ũ","?ux?"},
                {"ụ","?uj?"},
                {"Ừ","?UWF?"},
                {"Ứ","?UWS?"},
                {"Ử","?UWR?"},
                {"Ữ","?UWX?"},
                {"Ự","?UWJ?"},
                {"ừ","?uwf?"},
                {"ứ","?uws?"},
                {"ử","?uwr?"},
                {"ữ","?uwx?"},
                {"ự","?uwj?"},
                {"ỳ","?yf?"},
                {"ý","?ys?"},
                {"ỹ","?yx?"},
                {"ỵ","?yj?"},
                {"ỷ","?yr?"},
                {"Ỳ","?YF?"},
                {"Ý","?YS?"},
                {"Ỹ","?YX?"},
                {"Ỵ","?YJ?"},
                {"Ỷ","?YR?"},
                {"/","?_?"},
                {"&","?_38?"},
                {"#","?_35?"},
                {"%","?_37?"},
                {"@","(at)"},
                {"\\", "?_92?"}
            };
        }

        // trung ?uw??ow?ng=trung ương
        public static string VniEncode(string latinString)
        {
            string ouputStr = LatinDictionary.Value.Aggregate(latinString, (result, s) => result.Replace(s.Value, s.Key, StringComparison.InvariantCulture));
            return ouputStr;
        }

        //trung ương = trung ?uw??ow?ng
        public static string VniEscape(string vniString)
        {

            string ouputStr = LatinDictionary.Value.Aggregate(vniString, (result, s) => result.Replace(s.Key, s.Value, StringComparison.InvariantCulture));
            return ouputStr;
        }
    }
}