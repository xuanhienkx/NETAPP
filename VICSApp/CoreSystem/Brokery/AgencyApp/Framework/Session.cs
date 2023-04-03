using System;

namespace Brokery.Framework
{
   public enum SessionType
   {
      None = 0,
      OpenSession = 1,
      ContSession = 2,
      CloseSession = 3,
      PostCloseSession = 4,
      EndSession = 5,
   }

   public enum SessionStatus
   {
      Normal,
      NotEdit,
      End,
      Halt,
      Empty,
      Delay
   }

   public class TradingSession
   {
      public static TimeSpan StartOfDay = new TimeSpan(0, 0, 1);
      public static TimeSpan AtTimeOpen = new TimeSpan(8, 59, 0);
      public static TimeSpan AtTimeClose = new TimeSpan(10, 14, 0);
      public static TimeSpan EndOfDay = new TimeSpan(23, 59, 59);

      public static TimeSpan OneMinute = new TimeSpan(0, 1, 0);
      public static TimeSpan OneSecond = new TimeSpan(0, 0, 1);
      public static string CurrentHoseFlag;

      public TradingSession(SessionType sessionType, SessionStatus sessionStatus)
      {
         SessionStatus = sessionStatus;
         SessionType = sessionType;
      }

      public SessionType SessionType { get; private set; }
      public SessionStatus SessionStatus { get; private set; }

      internal static TradingSession GetCurrentSession(string stockCode, string boardType)
      {
         var type = SessionType.None;
         var status = SessionStatus.Normal;
         var tradingSession = Util.AgencyGateway.GetCurrentTradingSession(Util.TokenKey, stockCode, boardType);
         if (boardType == "M")
         {
            if (tradingSession.StartsWith("P"))
               type = SessionType.OpenSession;
            else if (tradingSession.StartsWith("O") || tradingSession.StartsWith("I") || tradingSession.StartsWith("F"))
               type = SessionType.ContSession;
            else if (tradingSession.StartsWith("A"))
               type = SessionType.CloseSession;
            else
               type = SessionType.EndSession;

            if (tradingSession.EndsWith("HALT"))
               status = SessionStatus.Halt;
            else if (tradingSession.EndsWith("EMPTY"))
               status = SessionStatus.Empty;
            else if (tradingSession.EndsWith("DELAY"))
               status = SessionStatus.Delay;
         }
         else if (boardType == "S" || boardType == "O")
         {
            if (tradingSession.StartsWith("NONE"))
               type = SessionType.None;
            else if (SessionUtil.IsOpenSession(tradingSession))
               type = SessionType.OpenSession;
            else if (SessionUtil.IsContinueSession(tradingSession))
               type = SessionType.ContSession;
            else if (SessionUtil.IsCloseSession(tradingSession))
               type = SessionType.CloseSession;
            else if (SessionUtil.IsPreCloseSession(tradingSession))
               type = SessionType.PostCloseSession;
            else
               type = SessionType.EndSession;

            if (SessionUtil.RejectModifyOrder(tradingSession))
               status = SessionStatus.NotEdit;
            else if (tradingSession.EndsWith("HALT"))
               status = SessionStatus.Halt;
            else if (tradingSession.EndsWith("EMPTY"))
               status = SessionStatus.Empty;
            else if (tradingSession.EndsWith("DELAY"))
               status = SessionStatus.Delay;
         }

         return new TradingSession(type, status);
      }
   }
}
