namespace DO.Common.Enums;

public static class CSEnum
{
    public static T Parse<T>(object enumValue)
    {
        return (T)Enum.Parse(typeof(T), enumValue.ToString());
    }
}
