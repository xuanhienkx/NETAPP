using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;

namespace Auto_A
{
   public delegate void UpdateMessage(string message);
   public delegate Arg GetArguments();
   public class Worker
   {
      private static string receivedBy;
      private UpdateMessage updateMsg;
      private GetArguments getArgs;

      public Worker(UpdateMessage updateMsg, GetArguments getArgs)
      {
         this.updateMsg = updateMsg;
         this.getArgs = getArgs;
         receivedBy = "'" + string.Join("','", ConfigurationManager.AppSettings["ReceivedBy"].Split(',')) + "'";
      }

      public void Run()
      {
         if (updateMsg == null || getArgs == null)
            throw new Exception("Thông tin chưa đầy đủ để thực hiện");

         while (true)
         {
            Arg arg = getArgs();
            Excecute(arg);
            Thread.Sleep(arg.Interval * 1000);
         }
      }

      private void Excecute(Arg arg)
      {
         string message = string.Format("[received by] in ({0}) ", receivedBy);
         StringBuilder sql = new StringBuilder();
         sql.Append("UPDATE [StockOrder] SET [OrderStatus] = 'S', [ApprovedBy] = ReceivedBy WHERE OrderStatus = 'P' ");
         sql.AppendFormat("AND ReceivedBy IN ({0}) ", receivedBy);
         if (arg.LimitAmount > 0)
         {
            sql.AppendFormat("AND OrderValue <= {0}  ", arg.LimitAmount);
            message = string.Format("{0} & [order volumne] <= {1}", message, arg.LimitAmount);
         }

         int items = AccessFactory.ExcecuteCommand(sql.ToString());
         //updateMsg(sql.ToString());
         updateMsg(string.Format("{0} updated: {1}", items, message));
      }
   }
}
