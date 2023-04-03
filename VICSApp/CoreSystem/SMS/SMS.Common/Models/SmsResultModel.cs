namespace SMS.Common.Models
{
    public class SmsResultModel
    {
        public string CodeResult { get; set; }
        public string ErrorMessage { get; set; }
        public string SMSID { get; set; }
        public string SendStatus { get; set; }
        public bool IsSandbox { get; set; }
    }
}