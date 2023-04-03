namespace BO.Core.DataCommon.Settings
{
    public class EmailProviderSettings
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string EmailServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
