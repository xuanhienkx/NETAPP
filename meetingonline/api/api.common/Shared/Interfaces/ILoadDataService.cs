using System.Collections.Generic;
using api.common.Models;

namespace api.common.Shared.Interfaces
{
    public interface ILoadDataService
    {
        IList<T> ReadFromFile<T>(MediaResource media) where T : class, new();
    }
}