using System.Collections.Generic;
using System.Xml.Serialization;

namespace SMS.Common.Models
{
    public class SmsStatus
    {
        public string CodeResult { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public int TotalReceiver { get; set; }
        public int TotalSent { get; set; }
        public decimal TotalPrice { get; set; }
    }

    [XmlRoot(ElementName = "Receiver")]
    public class Receiver
    {
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "SentResult")]
        public bool SentResult { get; set; }
        [XmlElement(ElementName = "IsSent")]
        public bool IsSent { get; set; }
    }

    [XmlRoot(ElementName = "ReceiverList")]
    public class ReceiverList
    {
        [XmlElement(ElementName = "Receiver")]
        public List<Receiver> Receiver { get; set; }
    }

    [XmlRoot(ElementName = "ReceiverStatus")]
    public class ReceiverStatus
    {
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "SentTime")]
        public string SentTime { get; set; }
    }

    [XmlRoot(ElementName = "SmsReceiver")]
    public class SmsReceiver
    {
        [XmlElement(ElementName = "CodeResult")]
        public string CodeResult { get; set; }
        [XmlElement(ElementName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
        [XmlElement(ElementName = "ReceiverList")]
        public ReceiverList ReceiverList { get; set; }
        [XmlElement(ElementName = "ReceiverStatus")]
        public ReceiverStatus ReceiverStatus { get; set; }
    }
}