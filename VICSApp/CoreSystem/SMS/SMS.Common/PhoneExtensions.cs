using System.Text.RegularExpressions;

namespace SMS.Common
{
    public static class PhoneExtensions
    {
        public static MobileType GePhoneType(this string phone)
        {
            if (IsMobiphone(phone))
                return MobileType.Mobiphone;
            if (IsViettel(phone))
                return MobileType.Viettel;
            if (IsMobiphone(phone))
                return MobileType.Mobiphone;
            if (IsVinaphone(phone))
                return MobileType.Vinaphone;
            if (IsVietnammobile(phone))
                return MobileType.Vietnammobile;
            if (IsGmobile(phone))
                return MobileType.Gmobile;
            if (IsSfone(phone))
                return MobileType.SFone;
            return MobileType.None;
        }
        public static bool IsMobiphone(string phone)
        {
            if (phone.Length == 11)
            {
                Regex regexShort = new Regex(@"^(0120|0121|0122|0126|0128)+\d{7}$");
                return regexShort.IsMatch(phone);
            }
            else if (phone.Length == 10)
            {
                Regex regex = new Regex(@"^(090|093)+\d{7}$");
                return regex.IsMatch(phone);
            }
            return false;
        }

        public static bool IsViettel(string phone)
        {
            if (phone.Length == 11)
            {
                Regex regexShort = new Regex(@"^(0162|0163|0164|0165|0166|0167|0168|0169)+\d{7}$");
                return regexShort.IsMatch(phone);
            }
            else if (phone.Length == 10)
            {
                Regex regex = new Regex(@"^(096|097|098|086)+\d{7}$");
                return regex.IsMatch(phone);
            }
            return false;
        }

        public static bool IsVinaphone(string phone)
        {
            if (phone.Length == 11)
            {
                Regex regexShort = new Regex(@"^(0123|0124|0125|0127|0129)+\d{7}$");
                return regexShort.IsMatch(phone);
            }
            else if (phone.Length == 10)
            {
                Regex regex = new Regex(@"^(091|094)+\d{7}$");
                return regex.IsMatch(phone);
            }
            return false;
        }

        public static bool IsVietnammobile(string phone)
        {
            if (phone.Length == 11)
            {
                Regex regexShort = new Regex(@"^(0188|0186|0189)+\d{7}$");
                return regexShort.IsMatch(phone);
            }
            else if (phone.Length == 10)
            {
                Regex regex = new Regex(@"^(092)+\d{7}$");
                return regex.IsMatch(phone);
            }
            return false;
        }

        public static bool IsGmobile(string phone)
        {
            if (phone.Length == 11)
            {
                Regex regexShort = new Regex(@"^(0199)+\d{7}$");
                return regexShort.IsMatch(phone);
            }
            else if (phone.Length == 10)
            {
                Regex regex = new Regex(@"^(099)+\d{7}$");
                return regex.IsMatch(phone);
            }
            return false;
        }

        public static bool IsSfone(string phone)
        {
            Regex regex = new Regex(@"^(095)+\d{7}$");
            return regex.IsMatch(phone);
        }
        public static bool IsNumber( this string phone)
        {
            if (string.IsNullOrEmpty(phone)) { return false; }
            switch (phone.Length)
            {
                case 11:
                    {
                        Regex regexShort = new Regex(@"^(0199|0188|0186|0189|0123|0124|0125|0127|0129|0162|0163|0164|0165|0166|0167|0168|0169|0120|0121|0122|0126|0128)+\d{7}$");
                        return regexShort.IsMatch(phone); 
                    }
                case 10:
                    {
                        Regex regex = new Regex(@"^(099|092|091|094|096|097|098|090|093|086)+\d{7}$");
                        return regex.IsMatch(phone); 
                    }
            }
            return false;
        }
    }
}