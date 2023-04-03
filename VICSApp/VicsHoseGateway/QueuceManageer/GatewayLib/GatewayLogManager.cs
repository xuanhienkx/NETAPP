namespace GatewayLib
{
    using log4net;
    using log4net.Config;
    using System;

    public class GatewayLogManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GatewayLogManager));

        static GatewayLogManager()
        {
            XmlConfigurator.Configure();
        }

        public static void Debug(string debugInfo)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(debugInfo);
            }
        }

        public static void Error(string errorMessage)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(errorMessage);
            }
        }

        public static void Fatal(string fatalError)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(fatalError);
            }
        }

        public static void Info(string infoMsg)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info(infoMsg);
            }
        }

        public static void Warn(string warnMsg)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(warnMsg);
            }
        }

        public static void Write(string msg)
        {
            logger.Info(msg);
        }
    }
}

