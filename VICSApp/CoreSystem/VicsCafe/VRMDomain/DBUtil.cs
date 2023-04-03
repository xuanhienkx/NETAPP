using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace VRMDomain
{
    public static class DBUtil
    {
        private static SqlConnection SbsConnection
        {
            get
            {
                return AccessFactory.CurrentInstance().SbsConnection;
            }
        }
        private static SqlConnection AccountConnection
        {
            get
            {
                return AccessFactory.CurrentInstance().AccountConnection;
            }
        }

        public static SqlDataReader ExecuteDataReader(string cmdText)
        {
            SqlCommand command = new SqlCommand(cmdText, SbsConnection);
            return command.ExecuteReader();
        }
        public static SqlDataReader ExecuteDataReader(string cmdText, bool kt)
        {
            try
            {
                SqlCommand command;
                if (kt)
                {
                    command = new SqlCommand(cmdText, AccountConnection);
                }
                else
                {
                    command = new SqlCommand(cmdText, SbsConnection);
                }

                return command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static SqlDataReader SBExecuteDataReader(string storeProcedureName, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storeProcedureName, SbsConnection);
            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteReader();
        }

        public static object ExecuteScalar(string cmdText)
        {
            SqlCommand command = new SqlCommand(cmdText, SbsConnection);
            return command.ExecuteScalar();
        }

        public static int ExecuteNonQuery(string cmdText)
        {
            SqlCommand command = new SqlCommand(cmdText, SbsConnection);
            return command.ExecuteNonQuery();
        }
        public static int ExecuteNonQuery(string cmdText, bool kt)
        {
            try
            {
                SqlCommand command;
                if (kt)
                {
                    command = new SqlCommand(cmdText, AccountConnection);
                }
                else
                {
                    command = new SqlCommand(cmdText, SbsConnection);
                }
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public static int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = SbsConnection;
            return command.ExecuteNonQuery();
        }

        internal static DataSet ExecuteDataSet(string cmdText)
        {
            return ExecuteDataSet(cmdText, 0);
        }

        internal static DataSet ExecuteDataSet(string cmdText, int timeout)
        {
            DataSet result = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(cmdText, SbsConnection));
            if (timeout > 0)
                adapter.SelectCommand.CommandTimeout = timeout;

            adapter.Fill(result);

            return result;
        }

        public static DataSet SPExecuteDataSet(string storeProcedureName, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storeProcedureName, SbsConnection);
            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet result = new DataSet();
            adapter.Fill(result);

            return result;
        }

        public static int SPExecuteNonQuery(string storeProcedureName, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(storeProcedureName, SbsConnection);
            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd.ExecuteNonQuery();
        }
        public static int SPExecuteNonQuery(string storeProcedureName, bool kt, params SqlParameter[] parameters)
        {
            SqlCommand cmd;
            if (kt)
            {
                cmd = new SqlCommand(storeProcedureName, AccountConnection);

            }
            else
            {
                cmd = new SqlCommand(storeProcedureName, SbsConnection);
            }

            cmd.Parameters.AddRange(parameters);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd.ExecuteNonQuery();
        }

        public static int SPExecuteNonQuery(string storeProcedureName, SqlParameterCollection parameters)
        {
            SqlCommand cmd = new SqlCommand(storeProcedureName, SbsConnection);
            Array paras = null;
            parameters.CopyTo(paras, 0);
            cmd.Parameters.AddRange(paras);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd.ExecuteNonQuery();
        }

        public static SqlCommand CreateSqlCommmandToExecSP(string storeProcedureName)
        {
            SqlCommand cmd = new SqlCommand(storeProcedureName, SbsConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
