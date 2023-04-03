using System;
using System.IO;
using System.Web;
using log4net;
using log4net.Config;

namespace SMS.Common
{
    public class Logger : ILogger
    {
        private static ILog logger;

        protected static ILog LoggerInstance
        {
            get
            {
                if (logger == null)
                {
                    var fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
                    // for web requst
                    if (!File.Exists(fileName))
                    {
                        fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin", "log4net.config");
                    }

                    XmlConfigurator.Configure(new FileInfo(fileName));
                    logger = LogManager.GetLogger(typeof(Logger));//LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);//
                }
                return logger;
            }
        }

        public void Log(string message)
        {
            LoggerInstance.Info(message);
        }

        public void Log(string messageFormat, params object[] args)
        {
            LoggerInstance.InfoFormat(messageFormat, args);
        }

        public void LogDebug(string message)
        {
            LoggerInstance.Debug(message);
        }

        public void LogDebug(string messageFormat, params object[] args)
        {
            LoggerInstance.DebugFormat(messageFormat, args);
        }

        public void LogError(Exception exception)
        {
            LogError(exception.ToString());
            if (exception.InnerException != null)
                LogError(exception.InnerException);
        }

        public void LogError(string message)
        {
            LoggerInstance.Error(message);
        }

        public void LogError(string messageFormat, params object[] args)
        {
            LoggerInstance.ErrorFormat(messageFormat, args);
        }
    }

}