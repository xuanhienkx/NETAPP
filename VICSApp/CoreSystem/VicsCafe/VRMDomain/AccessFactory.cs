using System;
using System.Web;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace VRMDomain
{
    public sealed class AccessFactory : IDisposable
    {
        private bool disposed;
        private string eventLogName;
        private static System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;

        private static Object connectionlock = new Object();
        private SqlConnection sbsConnection;
        private SqlConnection accountConnection;

        [ThreadStatic]
        private static AccessFactory currentInstance;

        private const string HTTP_CONTEXT_ACCESS_FACTORY = "AccessFactory";

        public static void CreateFactory()
        {
            if (CurrentInstance() != null)
                throw new ArgumentException("One already exist on thread");

            // If a http context exists
            if (HttpContext.Current != null)
            {
                // Then create and add the access factory as an item in the current http context
                HttpContext.Current.Items.Add(HTTP_CONTEXT_ACCESS_FACTORY, new AccessFactory());
            }
            else
            {
                // Else assign it on the not so safe thread static variable currentInstance
                currentInstance = new AccessFactory();
            }

            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = VRMDomain.Common.Util.CurrentCulture;
        }

        public AccessFactory()
        {
            eventLogName = ConfigurationManager.AppSettings["EventLog"];
        }

        ~AccessFactory()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            // If there is a current http context then there is a good chance we have an access factory stored in the items dictionary
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(HTTP_CONTEXT_ACCESS_FACTORY))
            {
                HttpContext.Current.Items.Remove(HTTP_CONTEXT_ACCESS_FACTORY);
            }

            // Set the not so safe thread static variable to null
            currentInstance = null;

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            disposed = true;

            DisposeConnection(sbsConnection, disposing);
            DisposeConnection(accountConnection, disposing);
        }

        private void DisposeConnection(SqlConnection connection, bool disposing)
        {
            if (disposing && connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    this.Abort("AccessFactory.Dispose - Attempting to dispose an open connection");
                    throw new NotSupportedException("Dispose was called on an open transaction, you need to explicitly call Abort or Commit");
                }
                connection.Dispose();
            }
            connection = null;
        }

        static public AccessFactory CurrentInstance()
        {
            // If a http context exists
            if (HttpContext.Current != null)
            {
                // Then get the access factory from the current http context
                if (!HttpContext.Current.Items.Contains(HTTP_CONTEXT_ACCESS_FACTORY) || HttpContext.Current.Items[HTTP_CONTEXT_ACCESS_FACTORY] == null)
                    return null;

                return (AccessFactory)HttpContext.Current.Items[HTTP_CONTEXT_ACCESS_FACTORY];
            }
            else
            {
                // Else get it from the not so safe thread static variable currentInstance
                return currentInstance;
            }
        }

        public static string EventLogName
        {
            get
            {
                return CurrentInstance().eventLogName;
            }
        }

        public SqlConnection SbsConnection
        {
            get
            {
                if (disposed)
                    throw new NotSupportedException("Dispose has been called on this factory, you can't reuse it");

                if (this.sbsConnection != null)
                {
                    if (this.sbsConnection.State == System.Data.ConnectionState.Open)
                        return this.sbsConnection;

                    //Something wrong, should never use a connection which is initialized, but not open
                    //Recycle pool and kill this one.
                    SqlConnection.ClearPool(this.sbsConnection);
                    this.sbsConnection.Dispose();
                    this.sbsConnection = null;
                }

                //Else we are on the first usage of the connection for this thread (or after a commit of same)
                string connectionstring = ConfigurationManager.ConnectionStrings["SBSConnection"].ToString();

                this.sbsConnection = InitConnection(connectionstring);
                return this.sbsConnection;
            }
        }

        public SqlConnection AccountConnection
        {
            get
            {
                if (disposed)
                    throw new NotSupportedException("Dispose has been called on this factory, you can't reuse it");

                if (this.accountConnection != null)
                {
                    if (this.accountConnection.State == System.Data.ConnectionState.Open)
                        return this.accountConnection;

                    //Something wrong, should never use a connection which is initialized, but not open
                    //Recycle pool and kill this one.
                    SqlConnection.ClearPool(this.accountConnection);
                    this.accountConnection.Dispose();
                    this.accountConnection = null;
                }

                //Else we are on the first usage of the connection for this thread (or after a commit of same)

                this.accountConnection = InitConnection(ConfigurationManager.ConnectionStrings["KTConnection"].ToString());
                return this.accountConnection;
            }
        }

        private SqlConnection InitConnection(string connectionString)
        {
            SqlConnection connection = null;
            //Retry a couple of times, in case someone terminated the connection 
            //beneith us and the connection pool is too broken to auto detect it
            int retries = 3;
            while (true)
                try
                {
                    connection = new SqlConnection(connectionString);
                    lock (connectionlock)
                    {
                        connection.Open();
                    }

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 30;
                        command.CommandText = "BEGIN TRANSACTION request";
                        command.ExecuteNonQuery();
                    }
                    break;
                }
                catch (SqlException e)
                {
                    if (--retries > 0 && e.Message.StartsWith("A transport-level"))
                    {
                        //Something wrong. Recycle pool and kill this one.
                        if (connection != null)
                        {
                            SqlConnection.ClearPool(connection);
                            connection.Dispose();
                            connection = null;
                        }
                        continue;
                    }
                    throw;
                }
            return connection;
        }

        public void Commit()
        {
            Commit(null);
        }

        public void Commit(string comment)
        {
            CommitConnection(comment, sbsConnection);
            CommitConnection(comment, accountConnection);
        }

        private void CommitConnection(string comment, SqlConnection connection)
        {
            if (connection != null)
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    Abort("Rollback from AccessFactory.Commit because connection state was not open");
                    return;
                }
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandTimeout = 600;
                        command.CommandText = "COMMIT TRANSACTION request";
                        if (!string.IsNullOrEmpty(comment))
                            command.CommandText += string.Format(" -- {0}", comment);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
                catch
                {
                    this.Abort();
                    throw;
                }
            }
        }

        public void Abort()
        {
            Abort(null);
        }

        public void Abort(string comment)
        {
            AbortConnection(comment, sbsConnection);
            AbortConnection(comment, accountConnection);
        }

        private void AbortConnection(string comment, SqlConnection connection)
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandTimeout = 600;
                            command.CommandText = "ROLLBACK TRANSACTION request";
                            if (!string.IsNullOrEmpty(comment))
                                command.CommandText += string.Format(" -- {0}", comment);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        /* NO-OP */
                    }
                    connection.Close();
                }
                else
                {
                    //Cannot just mark this connection as bad, but have to mark them all :(
                    SqlConnection.ClearPool(connection);
                }
                connection.Dispose();
                connection = null;
            }
        }

        static public System.Web.Caching.Cache Cache { get { return cache; } }
    }
}
