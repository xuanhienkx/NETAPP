using System;
using System.Collections.Generic;

namespace CS.Common.Interfaces
{
    public interface IModelMapperService
    {
        T Map<T>(CsBag bag, Func<T> constructor);

        IDictionary<string, object> Serialize<T>(T model);
        object MapByType(CsBag csvBags, Type type);
    }
}