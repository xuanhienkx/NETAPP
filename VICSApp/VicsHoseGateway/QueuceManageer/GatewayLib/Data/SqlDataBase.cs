namespace GatewayLib.Data
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class SqlDataBase
    {
        private static SqlCommand Command;
        private static SqlConnection Connection;
        private static SqlDataAdapter DataAdapter;

        public static bool Connect(string strConnection)
        {
            try
            {
                Connection = new SqlConnection();
                string str = strConnection;
                Connection.ConnectionString = str;
                Connection.Open();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return false;
            }
        }

        public static bool Connect(string servername, string databasename, string user, string password)
        {
            try
            {
                Connection = new SqlConnection();
                string str = "Server=" + servername + ";Database=" + databasename + ";User ID=" + user + ";Password=" + password + ";Trusted_Connection=False";
                Connection.ConnectionString = str;
                Connection.Open();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return false;
            }
        }

        public static void Disconnect()
        {
            if ((Connection != null) && (Connection.State == ConnectionState.Open))
            {
                Connection.Close();
                Connection.Dispose();
            }
        }

        public static DataTable ReturnDataTable(string strSql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Command = new SqlCommand(strSql, Connection);
                DataAdapter = new SqlDataAdapter(Command);
                DataAdapter.Fill(dataTable);
                DataAdapter.Dispose();
                Command.Dispose();
                return dataTable;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return null;
            }
        }
    }
}

