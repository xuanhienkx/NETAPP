using System.IO;
using System.Threading.Tasks;

namespace CS.Common.Interfaces
{
    public interface IMessageBuilder
    {
        Task<T> Read<T>(string fileName, Stream fileStream) where T : CsBag;
        void Write(Stream stream, CsBag bag);
    }
}
