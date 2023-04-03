using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CS.Common.Domain
{
    public abstract class CommonQuery<TEntityModel> where TEntityModel : class
    {
        protected readonly DbContext DataContext;
        protected readonly IMapper Mapper;
        private readonly Expression<Func<TEntityModel, object>>[] includePaths;

        protected CommonQuery(IMapper mapper, DbContext dataContext, Expression<Func<TEntityModel, object>>[] includePaths)
        {
            Mapper = mapper;
            DataContext = dataContext;
            this.includePaths = includePaths;
        }

        protected CommonQuery(IMapper mapper, DbContext dataContext)
        {
            DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected IQueryable<TEntityModel> Query => BuildQuery(DataContext.Set<TEntityModel>());

        protected IQueryable<TEntityModel> BuildQuery(IQueryable<TEntityModel> query)
        {
            foreach (var includeField in includePaths)
               query = query.Include(includeField);
            return query;
        }
    }
}
