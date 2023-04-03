namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface ILocalizer
    {
        string Get(string key);
        string Get(string key, params object[] arguments);
    }
}
