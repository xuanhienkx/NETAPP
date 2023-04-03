using BO.Core.DataCommon.Shared.Base;

namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface ILoadDataService
    {
        IList<T> ReadFromFile<T>(MediaResource media) where T : class, new();
    }
}