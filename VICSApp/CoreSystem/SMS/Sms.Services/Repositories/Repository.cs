using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SMS.Data.Services.EF.Repositories;

namespace SMS.Data.Services.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IRepositoryAsync<TEntity>
        where TEntity : class
    {
        protected Repository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; set; }

        protected DbSet<TEntity> Set
        {
            get { return Context.Set<TEntity>(); }
        }

        public virtual IList<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return Set.AsQueryable();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter)
        {
            return Set.Where(filter);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return Set.Where(filter).ToList();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
           return Set.Any(filter);
        }

        public virtual long Count()
        {
            return Set.LongCount();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter)
        {
            return Set.Count(filter);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return Set.Find(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool Delete(params object[] keyValues)
        {
            TEntity entity = Find(keyValues);
            if (entity == null) return false;
            Set.Remove(entity);
            Context.SaveChanges();
            return true;
        }

        public ObjectQuery<TEntity> GetObjectQuery(string sql)
        {
            var objctx = (Context as IObjectContextAdapter).ObjectContext;
            ObjectQuery<TEntity> objectQuery = objctx.CreateQuery<TEntity>(sql);
            return objectQuery;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Set.Where(filter).ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await FindAsync(CancellationToken.None, keyValues);
        }

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await Set.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            TEntity entity = await FindAsync(cancellationToken, keyValues);
            if (entity == null) return false;
            Set.Remove(entity);
            Context.SaveChanges();
            return true;
        }
    }
}