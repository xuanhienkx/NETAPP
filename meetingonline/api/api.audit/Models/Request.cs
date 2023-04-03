using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace api.audit.Models
{
    public class Request
    {
        public string Scheme { get; private set; }
        public string Host { get; private set; }
        public string Path { get; private set; }
        public string Protocol { get; private set; }
        public string QueryString { get; private set; }
        public string ContentType { get; private set; }
        public string Method { get; private set; }
        public IEnumerable<object> Headers { get; private set; }

        internal static Request From(HttpRequest request)
        {
            return new Request
            {
                Scheme = request.Scheme,
                Host = request.Host.Value,
                Path = request.Path.Value,
                Protocol = request.Protocol,
                QueryString = request.QueryString.Value,
                ContentType = request.ContentType,
                Method = request.Method,
                Headers = GetHeaderContents(request.Headers)
            };
        }

        private static IEnumerable<object> GetHeaderContents(IHeaderDictionary headers)
        {
            var result = new List<object>();

            foreach (var item in headers)
            {
                if (item.Value.Count > 0)
                    result.Add(new { key = item.Key, value = item.Value.ToString() });
            }

            return result;
        }
    }
}
