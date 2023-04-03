namespace DO.Common.Interfaces
{
    public interface IDbInitializer
    {
        Task Initialize(IServiceProvider serviceProvider);
        string Name { get; }
    }
}
