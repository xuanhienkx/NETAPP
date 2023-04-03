using System.Text;
using System.Web;

namespace DSoft.Common.Settings
{
    public class SecuritySettings
    {
        public string SuperAdminEmail { get; set; }
        public string TokenKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryInHours { get; set; }
        public bool RequiredNonceValidation { get; set; }
    }
    public class ApplicationSettings
    {
        public string ClientUrl { get; set; }
        public string Authority { get; set; }
        public string OpenOfficeLocation { get; set; }
        public bool UseSwagger { get; set; }
        public bool EnableSignalR { get; set; }

        public SecuritySettings SecuritySettings { get; set; }

        public int DataBoundaryLength { get; set; }
        public int DataFileCountLimit { get; set; }
        public int DataFileSizeLimit { get; set; }
        public string DataFileLocation { get; set; }
        public bool DataSignatureCheck { get; set; }
        public bool UseDefaultEmailProvider { get; set; }
        public bool UseMongoReplset { get; set; }
    }
    public class DatabaseSettings
    {
        private string Pramaters
            => "?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-1";
        public string ConnectionString => $"mongodb://{UserName}:{HttpUtility.UrlEncode(Password, Encoding.UTF8)}@{Server}/{Pramaters}";

        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
    }
}
