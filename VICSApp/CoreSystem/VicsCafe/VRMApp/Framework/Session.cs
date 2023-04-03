using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMApp.Framework
{
   public enum SessionType
   {
      None = 0,
      OpenSession = 1,
      ContSession = 2,
      CloseSession = 3
   }

   public static class Session
   {
      public static TimeSpan StartOfDay = new TimeSpan(0, 0, 1);
      public static TimeSpan AtTimeOpen = new TimeSpan(8, 59, 0);
      public static TimeSpan AtTimeClose = new TimeSpan(10, 14, 0);
      public static TimeSpan EndOfDay = new TimeSpan(23, 59, 59);

      public static TimeSpan OneMinute = new TimeSpan(0, 1, 0);
      public static TimeSpan OneSecond = new TimeSpan(0, 0, 1);

      internal static SessionType GetCurrentSession(string boardType)
      {
         if (boardType.Equals(Util.HNXBoard, StringComparison.CurrentCultureIgnoreCase))
            return SessionType.ContSession;
         if (Session.StartOfDay <= Util.CurrentTransactionDate.TimeOfDay && Util.CurrentTransactionDate.TimeOfDay <= Session.AtTimeOpen)
            return SessionType.OpenSession;
         if (Session.AtTimeOpen.Add(Session.OneMinute) <= Util.CurrentTransactionDate.TimeOfDay && Util.CurrentTransactionDate.TimeOfDay <= Session.AtTimeClose)
            return SessionType.ContSession;
         if (Session.AtTimeClose.Add(Session.OneMinute) <= Util.CurrentTransactionDate.TimeOfDay && Util.CurrentTransactionDate.TimeOfDay <= Session.EndOfDay)
            return SessionType.CloseSession;
         return SessionType.None;
      }
   }
}
