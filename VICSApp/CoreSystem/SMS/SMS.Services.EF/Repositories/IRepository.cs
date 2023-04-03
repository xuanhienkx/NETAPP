using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace SMS.Data.Services.EF.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        IQueryable<TEntity> GetQuery();
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        bool Any(Expression<Func<TEntity, bool>> filter);
        long Count();
        int Count(Expression<Func<TEntity, bool>> filter);
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        bool Delete(params object[] keyValues);
        ObjectQuery<TEntity> GetObjectQuery(string sql);
    }
}