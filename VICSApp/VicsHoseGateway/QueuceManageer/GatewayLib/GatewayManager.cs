namespace GatewayLib
{
    using System;
    using System.Configuration;

    public class GatewayManager
    {
        private static GatewayDataContext _gatewayContext = null;
        private static GatewayDataContext _gatewayContext2 = null;
        private static GatewayDataContext _gatewayContext3 = null;

        public static GatewayDataContext GetGatewayContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GatewayDB"].ConnectionString;
            if (_gatewayContext == null)
            {
                _gatewayContext = new GatewayDataContext(connectionString);
            }
            return _gatewayContext;
        }

        public static GatewayDataContext GetGatewayContext2()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GatewayDB"].ConnectionString;
            if (_gatewayContext2 == null)
            {
                _gatewayContext2 = new GatewayDataContext(connectionString);
            }
            return _gatewayContext2;
        }

        public static GatewayDataContext GetGatewayContext3()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GatewayDB"].ConnectionString;
            if (_gatewayContext3 == null)
            {
                _gatewayContext3 = new GatewayDataContext(connectionString);
            }
            return _gatewayContext3;
        }
    }
}

