using System.Configuration;

namespace Brokery
{
   public static class SessionUtil
   {
      public static string LIST_PREFIX = ConfigurationManager.AppSettings["LIST_PREFIX"];
      public static string UPCOM_PREFIX = ConfigurationManager.AppSettings["UPCOM_PREFIX"];
      public static string EDITLOCK_SUBFIX = ConfigurationManager.AppSettings["EDITLOCK_SUBFIX"];

      public static string OPEN_SECTION = ConfigurationManager.AppSettings["OPEN_SECTION"];
      public static string CLOSE_SECTION = ConfigurationManager.AppSettings["CLOSE_SECTION"];
      public static string CONTINUE_SECTION = ConfigurationManager.AppSettings["CONTINUE_SECTION"];
      public static string PRECLOSE_SECTION = ConfigurationManager.AppSettings["PRECLOSE_SECTION"];

      public static string FindBoard(string tradingSession)
      {
         return tradingSession.StartsWith(LIST_PREFIX) ? "S" : "O";
      }

      public static bool IsCloseSession(string tradingSession)
      {
         return tradingSession.Contains(CLOSE_SECTION);
      }

      public static bool IsOpenSession(string tradingSession)
      {
         return tradingSession.Contains(OPEN_SECTION);
      }

      public static bool RejectModifyOrder(string tradingSession)
      {
         return tradingSession.EndsWith(EDITLOCK_SUBFIX);
      }

      public static bool IsContinueSession(string tradingSession)
      {
         return tradingSession.Contains(CONTINUE_SECTION);
      }

      public static bool IsPreCloseSession(string tradingSession)
      {
         return tradingSession.Contains(PRECLOSE_SECTION);
      }
   }
}