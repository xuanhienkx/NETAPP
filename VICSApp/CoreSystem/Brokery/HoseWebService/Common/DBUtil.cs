using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HoseWebService.Common
{
   public static class DBUtil
   {
      static SqlConnection sbsCon
      {
         get
         {
            return AccessFactory.CurrentInstance().Connection;
         }
      }

      public static SqlDataReader ExecuteDataReader(string cmdText)
      {
         SqlCommand command = new SqlCommand(cmdText, sbsCon);
         return command.ExecuteReader();
      }

      public static SqlDataReader SBExecuteDataReader(string storeProcedureName, params SqlParameter[] parameters)
      {
         SqlCommand cmd = new SqlCommand(storeProcedureName, sbsCon);
         cmd.Parameters.AddRange(parameters);
         cmd.CommandType = CommandType.StoredProcedure;
         return cmd.ExecuteReader();
      }

      public static object ExecuteScalar(string cmdText)
      {
         SqlCommand command = new SqlCommand(cmdText, sbsCon);
         return command.ExecuteScalar();
      }

      public static int ExecuteNonQuery(string cmdText)
      {
         SqlCommand command = new SqlCommand(cmdText, sbsCon);
         return command.ExecuteNonQuery();
      }

      internal static DataSet ExecuteDataSet(string cmdText)
      {
         DataSet result = new DataSet();
         SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(cmdText, sbsCon));
         adapter.Fill(result);

         return result;
      }

      public static DataSet SPExecuteDataSet(string storeProcedureName, params SqlParameter[] parameters)
      {
         SqlCommand cmd = new SqlCommand(storeProcedureName, sbsCon);
         cmd.Parameters.AddRange(parameters);
         cmd.CommandType = CommandType.StoredProcedure;

         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataSet result = new DataSet();
         adapter.Fill(result);

         return result;
      }

      public static int SPExecuteNonQuery(string storeProcedureName, params SqlParameter[] parameters)
      {
         SqlCommand cmd = new SqlCommand(storeProcedureName, sbsCon);
         cmd.Parameters.AddRange(parameters);
         cmd.CommandType = CommandType.StoredProcedure;

         return cmd.ExecuteNonQuery();
      }

      public static int SPExecuteNonQuery(string storeProcedureName, SqlParameterCollection parameters)
      {
         SqlCommand cmd = new SqlCommand(storeProcedureName, sbsCon);
         Array paras = null;
         parameters.CopyTo(paras, 0);
         cmd.Parameters.AddRange(paras);
         cmd.CommandType = CommandType.StoredProcedure;

         return cmd.ExecuteNonQuery();
      }

      public static SqlCommand CreateSqlCommmandToExecSP(string storeProcedureName)
      {
         SqlCommand cmd = new SqlCommand(storeProcedureName, sbsCon);
         cmd.CommandType = CommandType.StoredProcedure;
         return cmd;
      }
   }
}
