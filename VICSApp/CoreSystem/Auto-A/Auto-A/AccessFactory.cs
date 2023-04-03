using System;
using System.Web;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace Auto_A
{
   public sealed class AccessFactory : IDisposable
   {
      private bool disposed;
      private static Object sbsconnectionlock = new Object();
      private string sbsConnectionString;
      private SqlConnection sbsConnection;


      [ThreadStatic]
      private static AccessFactory currentInstance;

      private AccessFactory(string sbsConnectionString)
      {
         this.sbsConnectionString = sbsConnectionString + ";Application Name=Auto-A";
      }

      public static void CreateFactory()
      {
         string sbsConnectionString = ConfigurationManager.ConnectionStrings["SBSConnection"].ConnectionString;
         CreateFactory(sbsConnectionString);
      }

      ~AccessFactory()
      {
         Dispose(false);
      }

      public void Dispose()
      {
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

         if (disposing && sbsConnection != null)
         {
            if (sbsConnection.State == System.Data.ConnectionState.Open)
            {
               this.Abort("AccessFactory.Dispose - Attempting to dispose an open connection");
               throw new NotSupportedException("Dispose was called on an open transaction, you need to explicitly call Abort or Commit");
            }
            sbsConnection.Dispose();
         }
         sbsConnection = null;
      }

      public static void CreateFactory(string sbsConnectionString)
      {
         if (CurrentInstance() != null)
            throw new ArgumentException("One already exist on thread");
         currentInstance = new AccessFactory(sbsConnectionString);
      }

      static public AccessFactory CurrentInstance()
      {
         return currentInstance;
      }

      public SqlConnection SBSConnection
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

            //Retry a couple of times, in case someone terminated the connection 
            //beneith us and the connection pool is too broken to auto detect it
            int retries = 3;
            while (true)
               try
               {
                  this.sbsConnection = new SqlConnection(this.sbsConnectionString);
                  lock (sbsconnectionlock)
                  {
                     this.sbsConnection.Open();
                  }

                  using (SqlCommand command = new SqlCommand())
                  {
                     command.Connection = this.sbsConnection;
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
                     if (this.sbsConnection != null)
                     {
                        SqlConnection.ClearPool(this.sbsConnection);
                        this.sbsConnection.Dispose();
                        this.sbsConnection = null;
                     }
                     continue;
                  }
                  throw;
               }
            return this.sbsConnection;
         }
      }

      public void Commit()
      {
         Commit(null);
      }

      public void Commit(string comment)
      {
         if (this.sbsConnection != null)
         {
            if (this.sbsConnection.State != System.Data.ConnectionState.Open)
            {
               Abort("Rollback from AccessFactory.Commit because connection state was not open");
               return;
            }
            try
            {
               using (SqlCommand command = new SqlCommand())
               {
                  command.Connection = this.sbsConnection;
                  command.CommandTimeout = 600;
                  command.CommandText = "COMMIT TRANSACTION request";
                  if (!string.IsNullOrEmpty(comment))
                     command.CommandText += string.Format(" -- {0}", comment);
                  command.ExecuteNonQuery();
               }
               this.sbsConnection.Close();
               sbsConnection.Dispose();
               sbsConnection = null;
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
         if (this.sbsConnection != null)
         {
            if (this.sbsConnection.State == System.Data.ConnectionState.Open)
            {
               try
               {
                  using (SqlCommand command = new SqlCommand())
                  {
                     command.Connection = this.sbsConnection;
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
               this.sbsConnection.Close();
            }
            else
            {
               //Cannot just mark this connection as bad, but have to mark them all :(
               SqlConnection.ClearPool(this.sbsConnection);
            }
            sbsConnection.Dispose();
            sbsConnection = null;
         }
      }

      internal static int ExcecuteCommand(string sql)
      {
         AccessFactory.CreateFactory();
         SqlCommand cmd = new SqlCommand(sql, AccessFactory.CurrentInstance().SBSConnection);
         int item = cmd.ExecuteNonQuery();
         AccessFactory.CurrentInstance().Commit();
         AccessFactory.CurrentInstance().Dispose();
         return item;
      }
   }
}
