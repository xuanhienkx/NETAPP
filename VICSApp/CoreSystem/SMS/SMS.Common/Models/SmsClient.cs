using System;
using System.Collections.Generic;

namespace SMS.Common.Models
{
    public class SmsClient
    {
        public string Apikey { get; set; }
        public string Secretkey { get; set; }
        public bool IsBrandname { get; set; }
        public int SmsType { get; set; }
        public string MessageContent { get; set; }
        public string Brandname { get; set; }
        public string BrandnameTelecome { get; set; }
        public Guid RequestId { get; set; }
        public byte SanbBox { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}