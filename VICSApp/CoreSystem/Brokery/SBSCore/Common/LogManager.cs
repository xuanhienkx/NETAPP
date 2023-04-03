using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace SBSCore.Common
{
   public class Logger
   {
      static Logger()
      {
         log4net.Config.XmlConfigurator.Configure();
      }
      private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));

      public static void Error(string errorMessage, Exception exception, params object[] args)
      {
         if (logger.IsErrorEnabled)
         {
            logger.Error(string.Format(errorMessage, args), exception);
         }
      }

      public static void Debug(string debugInfo, params object[] args)
      {
         if (logger.IsDebugEnabled)
         {
            logger.Debug(string.Format(debugInfo, args));
         }
      }

      public static void Fatal(string fatalError)
      {
         if (logger.IsFatalEnabled)
         {
            logger.Fatal(fatalError);
         }
      }

      public static void Info(string infoMsg, params object[] args)
      {
         if (logger.IsInfoEnabled)
         {
            logger.Info(string.Format(infoMsg, args));
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
