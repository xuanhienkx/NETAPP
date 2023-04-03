namespace DO.Common.Interfaces
{
    public interface IMessageConverter
    {
        bool CanParse(IList<KeyValuePair<string, string>> blocks);
        T Parse<T>(IList<KeyValuePair<string, string>> blocks) where T : CsBag;
        bool CanBuild(CsBag messageBag);
        string Build(CsBag messsageBag);
        void CollectLiteralData(CsBag messsageBag);
    }
    public interface IMarketMessageConverter
    {
        Task<T?> Read<T>(Stream stream, string messsage) where T : CsBag;
        void CollectLiteralData(CsBag messsageBag);
    }
}
