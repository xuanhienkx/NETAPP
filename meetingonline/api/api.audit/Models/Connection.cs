using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.audit.Models
{
    class Connection
    {
        public string ConnectionId { get; private set; }
        public string RemoteIpAddress { get; private set; }
        public string LocalIpAddress { get; private set; }
        public string ClientCertificate { get; private set; }

        internal static Connection From(ConnectionInfo connectionInfo)
        {
            return new Connection
            {
                ConnectionId = connectionInfo.Id,
                RemoteIpAddress = connectionInfo.RemoteIpAddress.ToString(),
                LocalIpAddress = connectionInfo.LocalIpAddress.ToString(),
                ClientCertificate = connectionInfo.ClientCertificate?.GetRawCertDataString(),
            };
        }
    }
}
