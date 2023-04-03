using System;
using Microsoft.VisualBasic;

namespace pmDHCD
{
    public class clsCommon
    {
        public string num2Text(string str1)
        {
            string num2TextRet = default;
            string str;
            int i;
            string tg;
            int j;
            int sval;
            string sSo;
            var sNum2Text = default(string);
            int k;
            int l;
            str = str1;
            i = Strings.Len(str);
            k = i / 3;
            l = 0;
            while (l <= k)
            {
                if (l < k)
                {
                    tg = Strings.Mid(str, i - (l + 1) * 3 + 1, 3);
                }
                else
                {
                    tg = Strings.Left(str, i - l * 3);
                }

                sSo = "";
                var loopTo = Strings.Len(tg);
                for (j = 1; j <= loopTo; j++)
                {
                    sval = (int)Math.Round(Conversion.Val(Strings.Mid(tg, Strings.Len(tg) - j + 1, 1)));
                    switch (sval)
                    {
                        case 0:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            if (Conversion.Val(tg) > 0d)
                                            {
                                                sSo = "không trăm " + sSo;
                                            }

                                            break;
                                        }

                                    case 2:
                                        {
                                            if (Conversion.Val(Strings.Mid(tg, 3, 1)) > 0d)
                                            {
                                                sSo = "linh " + sSo;
                                            }

                                            break;
                                        }

                                    case 1:
                                        {
                                            break;
                                        }
                                }

                                break;
                            }

                        case 1:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "một trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "mười " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            if (Strings.Len(tg) > 1 & Conversion.Val(Strings.Mid(tg, 2, 1)) > 1d)
                                            {
                                                sSo = "mốt" + sSo;
                                            }
                                            else
                                            {
                                                sSo = "một" + sSo;
                                            }

                                            break;
                                        }
                                }

                                break;
                            }

                        case 2:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "hai trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "hai mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "hai" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 3:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "ba trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "ba mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "ba" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 4:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "bốn trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "bốn mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "bốn" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 5:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "năm trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "năm mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            if (Strings.Len(tg) > 1 & Conversion.Val(Strings.Mid(tg, 2, 1)) >= 1d)
                                            {
                                                sSo = "lăm " + sSo;
                                            }
                                            else
                                            {
                                                sSo = "năm " + sSo;
                                            }

                                            break;
                                        }
                                }

                                break;
                            }

                        case 6:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "sáu trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "sáu mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "sáu" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 7:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "bảy trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "bảy mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "bảy" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 8:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "tám trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "tám mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "tám" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }

                        case 9:
                            {
                                switch (j)
                                {
                                    case 3:
                                        {
                                            sSo = "chín trăm " + sSo;
                                            break;
                                        }

                                    case 2:
                                        {
                                            sSo = "chín mươi " + sSo;
                                            break;
                                        }

                                    case 1:
                                        {
                                            sSo = "chín" + sSo;
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }

                switch (l)
                {
                    case 1:
                    case 4:
                        {
                            if (!string.IsNullOrEmpty(sSo))
                            {
                                sNum2Text = sSo + " nghìn" + " " + sNum2Text;
                            }

                            break;
                        }

                    case 2:
                    case 5:
                        {
                            if (!string.IsNullOrEmpty(sSo))
                            {
                                sNum2Text = sSo + " triệu" + " " + sNum2Text;
                            }

                            break;
                        }

                    case 3:
                    case 6:
                        {
                            if (!string.IsNullOrEmpty(sSo))
                            {
                                sNum2Text = sSo + " tỷ" + " " + sNum2Text;
                            }

                            break;
                        }

                    default:
                        {
                            sNum2Text = sSo;
                            break;
                        }
                }

                l = l + 1;
            }

            num2TextRet = sNum2Text;
            return num2TextRet;
        }
    }
}