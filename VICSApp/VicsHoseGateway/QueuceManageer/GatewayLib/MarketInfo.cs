namespace GatewayLib
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class MarketInfo
    {
        private static string marketCurrentStatus = null;

        public static string GetCurrentStatus()
        {
            if (marketCurrentStatus == null)
            {
                GatewayDataContext context = GatewayManager.GetGatewayContext2();
                try
                { 
                    var systemControlCode = from msg in context.HOSE_SCs
                                            where msg.SYSTEM_CONTROL_CODE != 'N' &&
                                            msg.SYSTEM_CONTROL_CODE != 'X'
                                            select msg.SYSTEM_CONTROL_CODE;

                    if (systemControlCode != null && systemControlCode.Count() > 0)
                    {
                        marketCurrentStatus = systemControlCode.ToArray()[systemControlCode.Count() - 1].ToString();
                    }
                    else
                    {
                        marketCurrentStatus = MarketStatusConst.NOT_APPLICABLE;
                    }
                }
                catch (SqlException exception)
                {
                    GatewayLogManager.Error("Error in GetCurrentStatus, Error detail:" + exception.Message);
                    throw exception;
                }
            }
            return marketCurrentStatus;
        }

        public static void ResetMarketStatus()
        {
            marketCurrentStatus = null;
        }

        public static void SetMarketStatus(string status)
        {
            marketCurrentStatus = status;
        }
    }
}

