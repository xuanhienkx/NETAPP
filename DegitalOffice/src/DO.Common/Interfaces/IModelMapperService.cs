namespace DO.Common.Interfaces
{
    public interface IModelMapperService
    {
        T Map<T>(CsBag bag, Func<T> constructor);

        IDictionary<string, object> Serialize<T>(T model);
        object MapByType(CsBag csvBags, Type type);
    }
}