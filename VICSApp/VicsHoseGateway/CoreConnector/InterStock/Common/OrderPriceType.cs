using System;

namespace InterStock
{
    public class OrderPriceType
    {
        public const string LO = "LO"; //LO - GIA BAT KY
        public const string ATO = "ATO"; //MO CUA
        public const string ATC = "ATC"; //DONG CUA
        public const string MP = "MP"; //THI TRUONG
        public const string LO_CEILING = "CEILING"; //TRAN
        public const string LO_CEILING_SUBTRACT1 = "CEILING - 1"; //TRAN - 1
        public const string LO_FLOOR = "FLOOR"; //SAN
        public const string LO_FLOOR_PLUS1 = "FLOOR + 1"; //SAN + 1
        public const string LO_REF = "REFERENCE"; //THAM CHIEU
        public const string LO_REF_FLOOR = "AVGERAGE ( REF, FLOOR )"; //TRUNG BINH GIUA THAM CHIEU VA SAN
        public const string LO_REF_CEILING = "AVGERAGE ( REF , CEILING )"; //TRUNG BINH GIUA THAM CHIEU VA TRAN
        public const string LO_REF_PLUS1 = "REFERENCE + 1"; //THAM CHIEU + 1
        public const string LO_REF_SUBTRACT1 = "REFERENCE - 1"; //THAM CHIEU  - 1
    }
}
