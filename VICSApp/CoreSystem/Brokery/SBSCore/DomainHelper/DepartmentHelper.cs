using System.Collections.Generic;
using CommonDomain;
using SBSCore.Common;
using System.Data.SqlClient;

namespace SBSCore.DomainHelper
{
   public static class DepartmentHelper
   {
      public static List<Department> GetList(string branchCode)
      {
         List<Department> result = new List<Department>();

         string sql = string.Format("SELECT [Id], [Name] FROM dbo.Department WHERE BranchCode = '{0}'", LiteralUtil.GetLiteral(branchCode));
         using (SqlDataReader reader = DBUtil.ExecuteDataReader(sql))
         {
            while (reader.Read())
            {
               Department d = new Department();
               d.Id = (int)reader["Id"];
               d.Name = reader["Name"].ToString();
               result.Add(d);
            }
            reader.Close();
            reader.Dispose();
         }
         return result;
      }
   }
}
