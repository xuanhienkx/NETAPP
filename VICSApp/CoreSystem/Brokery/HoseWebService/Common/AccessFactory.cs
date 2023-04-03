using System;
using System.Web;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace HoseWebService.Common
{
   public sealed class AccessFactory : IDisposable
   {
      private static Object connectionlock = new Object();
      private bool disposed;
      private SqlConnection connection;
      private string connectionString;
      private string eventLogName;
      private static System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;

      [ThreadStatic]
      private static AccessFactory currentInstance;

      private const string HTTP_CONTEXT_ACCESS_FACTORY = "AccessFactory";

      private AccessFactory(string connectionString, string eventLogName)
      {
         this.connectionString = connectionString + ";Application Name=HoseGatewaypp";
         this.eventLogName = eventLogName;
      }

      public static void CreateFactory()
      {
         string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
         string eventLogName = ConfigurationManager.AppSettings["EventLog"];
         CreateFactory(connectionString, eventLogName);

         Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = Util.CurrentCulture;
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

      public static void CreateFactory(string connectionString)
      {
         string eventLogName = ConfigurationManager.AppSettings["EventLog"];
         CreateFactory(connectionString, eventLogName);
      }

      public static void CreateFactory(string connectionString, string eventLogName)
      {
         if (CurrentInstance() != null)
         {
            throw new ArgumentException("One already exist on thread");
         }

         // If a http context exists
         if (HttpContext.Current != null)
         {
            // Then create and add the access factory as an item in the current http context
            HttpContext.Current.Items.Add(HTTP_CONTEXT_ACCESS_FACTORY, new AccessFactory(connectionString, eventLogName));
         }
         else
         {
            // Else assign it on the not so safe thread static variable currentInstance
            currentInstance = new AccessFactory(connectionString, eventLogName);
         }
      }

      static public AccessFactory CurrentInstance()
      {
         // If a http context exists
         if (HttpContext.Current != null)
         {
            // Then get the access factory from the current http context
            if (!HttpContext.Current.Items.Contains(HTTP_CONTEXT_ACCESS_FACTORY) || HttpContext.Current.Items[HTTP_CONTEXT_ACCESS_FACTORY] == null)
            {
               return null;
            }

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

      public SqlConnection Connection
      {
         get
         {
            if (disposed)
               throw new NotSupportedException("Dispose has been called on this factory, you can't reuse it");

            if (this.connection != null)
            {
               if (this.connection.State == System.Data.ConnectionState.Open)
                  return this.connection;

               //Something wrong, should never use a connection which is initialized, but not open
               //Recycle pool and kill this one.
               SqlConnection.ClearPool(this.connection);
               this.connection.Dispose();
               this.connection = null;
            }

            //Else we are on the first usage of the connection for this thread (or after a commit of same)

            //Retry a couple of times, in case someone terminated the connection 
            //beneith us and the connection pool is too broken to auto detect it
            int retries = 3;
            while (true)
               try
               {
                  this.connection = new SqlConnection(this.connectionString);
                  lock (connectionlock)
                  {
                     this.connection.Open();
                  }

                  using (SqlCommand command = new SqlCommand())
                  {
                     command.Connection = this.connection;
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
                     if (this.connection != null)
                     {
                        SqlConnection.ClearPool(this.connection);
                        this.connection.Dispose();
                        this.connection = null;
                     }
                     continue;
                  }
                  throw;
               }
            return this.connection;
         }
      }

      public void Commit()
      {
         Commit(null);
      }

      public void Commit(string comment)
      {
         if (this.connection == null)
            return;
         if (this.connection.State != System.Data.ConnectionState.Open)
         {
            Abort("Rollback from AccessFactory.Commit because connection state was not open");
            return;
         }
         try
         {
            using (SqlCommand command = new SqlCommand())
            {
               command.Connection = this.connection;
               command.CommandTimeout = 600;
               command.CommandText = "COMMIT TRANSACTION request";
               if (!string.IsNullOrEmpty(comment))
                  command.CommandText += string.Format(" -- {0}", comment);
               command.ExecuteNonQuery();
            }
            this.connection.Close();
            connection.Dispose();
            connection = null;
         }
         catch
         {
            this.Abort();
            throw;
         }
      }

      public void Abort()
      {
         Abort(null);
      }

      public void Abort(string comment)
      {
         if (this.connection == null)
            return;

         if (this.connection.State == System.Data.ConnectionState.Open)
         {
            try
            {
               using (SqlCommand command = new SqlCommand())
               {
                  command.Connection = this.connection;
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
            this.connection.Close();
         }
         else
         {
            //Cannot just mark this connection as bad, but have to mark them all :(
            SqlConnection.ClearPool(this.connection);
         }
         connection.Dispose();
         connection = null;
      }

      static public System.Web.Caching.Cache Cache { get { return cache; } }
   }
}
