using System;
using System.Collections.Generic;
using System.Text;

namespace api.common.Shared
{
    public class EmailContent
    {
        public string Title { get; }
        public string Body { get; }

        public EmailContent(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
