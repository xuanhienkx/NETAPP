using ProtoBuf;

namespace CS.Common.Contract.Models
{ 
    public class SettingModel
    {
        public ApiConfig Api { get; set; }
        public string CsvTempDirectory { get; set; }
        public int PageSize { get; set; }
    } 

    public class ApiConfig 
    {
        public string BaseUri { get; set; }
        public string Version { get; set; }
        public string BufferSize { get; set; }
        public string TimeoutInSecond { get; set; }
        public string ContentType { get; set; }
    }
}