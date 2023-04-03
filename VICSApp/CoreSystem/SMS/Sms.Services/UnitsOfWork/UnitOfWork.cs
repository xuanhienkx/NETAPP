using System;
using System.Data;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using SMS.Common;
using SMS.Data.Services.EF.UnitsOfWork;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace SMS.Data.Services.UnitsOfWork
{
    public abstract class UnitOfWork : Disposable,IUnitOfWork, IUnitOfWorkAsync
    { 
        private bool _disposed;

        protected UnitOfWork()
        {

        }

        protected UnitOfWork(DbContext context)
        {
            
            if (context == null) throw new ArgumentNullException("context"); 
            Context = context; 
          //  Context.Database.Connection.StateChange += OnStateChange;
        }

        protected DbContext Context { get; set; }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual int SaveChanges()
        {
            if (_disposed)
                throw new ObjectDisposedException("UnitOfWork");
            return Context.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            if (_disposed)
                throw new ObjectDisposedException("UnitOfWork");
            return await SaveChangesAsync(CancellationToken.None);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (_disposed)
                throw new ObjectDisposedException("UnitOfWork");
            return await Context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) Context.Dispose();
            _disposed = true;
        }

        protected override void DisposeCore()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
        private void OnStateChange(object sender, StateChangeEventArgs args)
        {
            if (args.CurrentState == ConnectionState.Open && args.OriginalState != ConnectionState.Open)
            {
                using (var command = Context.Database.Connection.CreateCommand())
                {
                    if (Transaction.Current == null)
                    {
                        command.CommandText = "SET TRANSACTION ISOLATION LEVEL SNAPSHOT";
                    }
                    else
                    {
                        switch (Transaction.Current.IsolationLevel)
                        {
                            case IsolationLevel.ReadCommitted:
                                command.CommandText = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED";
                                break;
                            case IsolationLevel.ReadUncommitted:
                                command.CommandText = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
                                break;
                            case IsolationLevel.Snapshot:
                                command.CommandText = "SET TRANSACTION ISOLATION LEVEL SNAPSHOT";
                                break;
                            default: 
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}