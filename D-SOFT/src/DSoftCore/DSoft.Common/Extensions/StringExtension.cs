using System.Text;
using System.Text.RegularExpressions;

namespace DSoft.Common.Extensions;

public static class StringExtension
{
    public static string SubStringWithTrimStart(this string text, string trimmedText, int startIndex, int length)
    {
        var idx = text.IndexOf(trimmedText, startIndex, StringComparison.OrdinalIgnoreCase);
        if (idx == -1)
            return string.Empty; // text;

        idx += trimmedText.Length;
        if (idx > text.Length)
            return string.Empty;
        if (length >= text.Length - idx)
            length = -1;

        return length > 0
            ? text.Substring(idx, length)
            : text.Substring(idx);
    }

    public static string SubStringWithTrimStart(this string text, string trimmedText, int length)
    {
        var idx = text.IndexOf(trimmedText, StringComparison.OrdinalIgnoreCase);
        if (idx == -1)
            return string.Empty; // text;

        idx += trimmedText.Length;
        if (idx > text.Length || length + idx > text.Length)
            return string.Empty;

        return length > 0
            ? text.Substring(idx, length)
            : text.Substring(idx);
    }

    public static string TrimStartAll(this string text, string trimmedText)
    {
        if (string.IsNullOrEmpty(trimmedText))
            return text;

        if (text.StartsWith(trimmedText, StringComparison.OrdinalIgnoreCase))
            return text.Substring(trimmedText.Length);
        return text;

        //var idx = text.IndexOf(trimmedText, StringComparison.OrdinalIgnoreCase);
        //return idx == -1 ? text : text.Substring(idx + trimmedText.Length);
    }

    public static string TrimEndAll(this string text, string trimmedText)
    {
        if (string.IsNullOrEmpty(trimmedText))
            return text;

        if (text.EndsWith(trimmedText, StringComparison.OrdinalIgnoreCase))
            return text.Substring(0, text.Length - trimmedText.Length);
        return text;

        //var idx = text.LastIndexOf(trimmedText, StringComparison.OrdinalIgnoreCase);
        //return idx == -1 ? text : text.Remove(idx);
    }

    public static string Between(this string text, string start, string end, int startIndex, out int lastIndex)
    {
        var posA = string.IsNullOrEmpty(start)
            ? 0
            : text.IndexOf(start, startIndex, StringComparison.OrdinalIgnoreCase);
        if (posA == -1)
        {
            lastIndex = -1;
            return string.Empty;
        }
        if (start != null)
            posA += start.Length;

        var posB = string.IsNullOrEmpty(end)
            ? text.Length
            : text.IndexOf(end, posA, StringComparison.OrdinalIgnoreCase);
        if (posB == -1)
        {
            lastIndex = text.Length;
            return text.Substring(posA);
        }
        lastIndex = posB;
        return text.Substring(posA, posB - posA);
    }
    public static string ReplaceWithString(this string text, string oldvalue, string newvalue, int length)
    {
        if (text.Length <= length)
            return text;

        var newstring = string.Empty;
        while (text.Length > length)
        {
            var temp = text.Substring(0, length);
            var indexOf = !temp.EndsWith(oldvalue) ? temp.LastIndexOf(oldvalue, StringComparison.Ordinal) : temp.Length;
            newstring += text.Substring(0, indexOf) + newvalue;
            text = text.Remove(0, indexOf);
        }

        if (text.Length > 0 && text.Length <= length)
            newstring += text;
        return newstring;
    }

    public static string ConvertToUnSign(this string obj)
    {
        var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        var temp = obj.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    }

    public static string EscapeUnicode(this string text)
    {
        var arr1 = new[]{"á","à","ả","ã","ạ","â","ấ","ầ","ẩ","ẫ","ậ","ă","ắ","ằ","ẳ","ẵ","ặ",
                "đ",
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                "í","ì","ỉ","ĩ","ị",
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                "ý","ỳ","ỷ","ỹ","ỵ",};
        var arr2 = new[]{"a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a","a",
                "d",
                "e","e","e","e","e","e","e","e","e","e","e",
                "i","i","i","i","i",
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                "u","u","u","u","u","u","u","u","u","u","u",
                "y","y","y","y","y",};
        for (var i = 0; i < arr1.Length; i++)
        {
            text = text.Replace(arr1[i], arr2[i]);
            text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
        }
        return text;
    }
    public static string FirstCharToUpper(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        return input.First().ToString().ToUpper() + input.Substring(1);
    }
    public static string FirstCharToLower(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        return input.First().ToString().ToLower() + input.Substring(1);
    }

    #region String Encode/Decode

    public static string Base64Encode(this string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
    public static string Base64Decode(this string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    #endregion

}
public static class DSoftExtensions
{
    public static bool Between(this DateTime dt, DateTime start, DateTime end)
    {
        if (start < end) return dt >= start && dt <= end;
        return dt >= end && dt <= start;
    }
}
