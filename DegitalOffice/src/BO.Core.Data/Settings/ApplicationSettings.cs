namespace BO.Core.DataCommon.Settings
{
    public class ApplicationSettings
    {
        public string ClientUrl { get; set; }
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
}