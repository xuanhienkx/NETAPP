using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.IO;

namespace AutoBackup
{
    public class MyLogManager
    {
        static MyLogManager()
        {
            log4net.Config.XmlConfigurator.Configure();
            
        }
        private static readonly ILog logger = LogManager.GetLogger(typeof(MyLogManager));

        public static void Error(string errorMessage)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(errorMessage);
                Console.WriteLine(errorMessage);
            }
        }

        public static void Debug(string debugInfo)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(debugInfo);
                Console.WriteLine(debugInfo);
            }
        }

        public static void Fatal(string fatalError)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(fatalError);
                Console.WriteLine(fatalError);
            }
        }

        public static void Info(string infoMsg)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info(infoMsg);
                Console.WriteLine(infoMsg);
            }
        }

        public static void Warn(string warnMsg)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(warnMsg);
                Console.WriteLine(warnMsg);
            }
        }

        public static void Write(string msg)
        {
            logger.Info(msg);
            Console.WriteLine(msg);
        }
    }
}
