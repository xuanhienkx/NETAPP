namespace DSoft.Common.Shared.Interfaces
{
    public interface IValueConverter
    {
        object Parse(string data, CSValueType type, string format);
        string ToString(object value, CSValueType type, string format);
    }
}
