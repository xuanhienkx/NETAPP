namespace DSoft.Common.Shared.Interfaces;

public interface ILocalizer
{
    string Get(string key);
    string Get(string key, params object[] arguments);
}
