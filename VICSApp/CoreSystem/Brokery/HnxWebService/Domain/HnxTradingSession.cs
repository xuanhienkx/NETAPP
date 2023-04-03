using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HnxWebService.Domain
{
   public enum TradingSessionStatus
   {
      None = 0,
      Normal = 1,
      Pending = 2,
      RamdomEnd = 3,
      CbPending = 4,
      AfterCb = 5,
      Prolong = 6,
      EndDay = 13,
      Waiting = 90,
      Closed = 97
   }

   public enum TradingSessionMode
   {
      NONE,
      OPEN,
      CONT,
      CLOSE,
      PCCLOSE
   }

   public class HnxTradingSession
   {
      public TradingSessionMode TradingSessionMode { get; set; }
      public TradingSessionStatus TradingSessionStatus { get; set; }

      public static HnxTradingSession Parse(string sessionMode, string status)
      {
          return new HnxTradingSession()
                     {
                         TradingSessionMode = ParseMode(sessionMode),
                         TradingSessionStatus = ParseStatus(status)
                     };
      }

      private static TradingSessionStatus ParseStatus(string status)
      {
          TradingSessionStatus sessionStatus;
          if (!Enum.TryParse(status, true, out sessionStatus))
              sessionStatus = TradingSessionStatus.None;
          return sessionStatus;
      }

      private static TradingSessionMode ParseMode(string sessionMode)
      {
          if (sessionMode.StartsWith("NONE"))
              return TradingSessionMode.NONE;
          if (sessionMode.StartsWith("OPEN"))
              return TradingSessionMode.OPEN;
          if (sessionMode.StartsWith("CONT"))
              return TradingSessionMode.CONT;
          if (sessionMode.StartsWith("CLOSE"))
              return TradingSessionMode.CLOSE;
          if (sessionMode.StartsWith("PCCLOSE"))
              return TradingSessionMode.PCCLOSE;
          return TradingSessionMode.NONE;
      }
   }
}