using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using CommonDomain;
using System.Data;

namespace SBSCore.DomainHelper
{
   public static class AgencyFeeHelper
   {
      private static void PasreFromDataReader(IDataReader dataReader, AgencyFee agencyFee)
      {
         agencyFee.Id = Convert.ToInt32(dataReader["Id"]);
         agencyFee.AgencyTradeCode = dataReader["AgencyTradeCode"].ToString();
         agencyFee.ValueFrom = Convert.ToInt32(dataReader["ValueFrom"]);
         agencyFee.ToValue = Convert.ToInt32(dataReader["ToValue"]);
         agencyFee.Fee = Convert.ToDecimal(dataReader["Fee"]);
         agencyFee.Note = dataReader["Note"].ToString();

      }

      public static AgencyFee GetAgencyFee(int id)
      {
          AgencyFee agencyFee = null;
          string sql = string.Format("SELECT * FROM AgencyFee WHERE id={0}", id);
          using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql.ToString()))
          {
              agencyFee = new AgencyFee();
              if (dataReader.Read())
                  PasreFromDataReader(dataReader, agencyFee);
              dataReader.Close();
          }
          return agencyFee;
      }

      public static List<AgencyFee> GetAgencyFeeByTradeCode(string agencyTradeCode)
      {
         List<AgencyFee> result = new List<AgencyFee>();
         string sql = string.Format("SELECT * FROM AgencyFee WHERE AgencyTradeCode='{0}'",agencyTradeCode);
         using (SqlDataReader dataReader = DBUtil.ExecuteDataReader(sql))
         {
            while (dataReader.Read())
            {
                AgencyFee agencyFee = new AgencyFee();
                PasreFromDataReader(dataReader, agencyFee);
                result.Add(agencyFee);
            }
            dataReader.Close();
         }
         return result;
      }


      public static void NewAgencyFee(string agencyTradeCode, int valueFrom, int toValue, decimal fee, string note)
      {
         StringBuilder sql = new StringBuilder();
         sql.Append("INSERT INTO AgencyFee(AgencyTradeCode, ValueFrom, ToValue, Fee, Note) \n");
         sql.AppendFormat("VALUES ('{0}',{1},{2},{3},'{4}')",agencyTradeCode, valueFrom, toValue, fee, note);
         DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static void EditAgencyFee(string agencyTradeCode,int ID ,int valueFrom, int toValue, decimal fee, string note)
      {
          StringBuilder sql = new StringBuilder();
          sql.AppendFormat("UPDATE AgencyFee SET AgencyTradeCode='{0}', ValueFrom={1}, ToValue={2}, Fee={3}, Note='{4}' WHERE ID = {5}", agencyTradeCode, valueFrom, toValue, fee, note,ID);
          DBUtil.ExecuteNonQuery(sql.ToString());
      }

      public static void DeleteAgencyFee(int Id)
      {
          string sql = string.Format("DELETE FROM dbo.AgencyFee WHERE ID = '{0}'",Id);
         DBUtil.ExecuteNonQuery(sql);
      }
   }
}
