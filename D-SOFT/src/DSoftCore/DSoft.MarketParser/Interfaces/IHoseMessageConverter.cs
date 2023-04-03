using DSoft.MarketParser.Common;
namespace DSoft.MarketParser.Interfaces;
public interface IHoseMessageConverter
{
    Task<T?> Read<T>(byte[] stream, string fileName) where T : CsBag;
    bool CanParse(string fileName, DateTime dateProcess);
}
public interface IHnxMessageConverter
{
    Task<T?> Read<T>(string file) where T : CsBag;   
}

