using AutoMapper;
using CS.Common.Contract;
using CS.Common.Domain;
using CS.Common.Domain.Interfaces;
using CS.Common.Std.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CS.Common.Contract.Enums;
using Microsoft.AspNetCore.Http;

namespace CS.Domain.Data.Queries
{
    public class EntityQuery<TIdentity, TServiceModel, TEntityModel> : CommonQuery<TEntityModel>, IQuery<TIdentity, TServiceModel, TEntityModel>
        where TServiceModel : IResource<TIdentity>
        where TEntityModel : class, IIdentityEntity<TIdentity>
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly IUserLogin userLogin;

        public EntityQuery(IHttpContextAccessor httpContext, IUserLogin userLogin, DbContext dataContext, IMapper mapper, 
            params Expression<Func<TEntityModel, object>>[] includePaths)
            : base(mapper, dataContext, includePaths)
        {
            this.httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            this.userLogin = userLogin;
        }

        public TServiceModel Get(TIdentity id)
        {
            var db = Queryable().FirstOrDefault(x => Equals(x.Id, id));
            return Mapper.Map<TServiceModel>(db);
        }

        public async Task<TServiceModel> GetAsync(TIdentity id)
        {
            var db = await Queryable().FirstOrDefaultAsync(x => Equals(x.Id, id));
            return Mapper.Map<TServiceModel>(db);
        }

        public IList<TServiceModel> GetAll()
        {
            return Mapper.Map<IList<TServiceModel>>(Queryable());
        }

        public async Task<IList<TServiceModel>> GetAllAsync()
        {
            var db = await Queryable().ToListAsync();
            return Mapper.Map<IList<TServiceModel>>(db);
        }

        public IList<TServiceModel> Filter(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            var db = Queryable(excludePaths).Where(filter);
            return Mapper.Map<IList<TServiceModel>>(db);
        }

        public async Task<IList<TServiceModel>> FilterAsync(Expression<Func<TEntityModel, bool>> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            var db = await Queryable(excludePaths).Where(filter)
                .ToListAsync();
            return Mapper.Map<IList<TServiceModel>>(db);
        }

        public ListPaged<TServiceModel> FilterAsync(IDictionary<string, string> filter, params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            var entityQuery = Queryable(excludePaths);
            var parser = new Parser<TEntityModel>(filter, entityQuery);
            var result = parser.Parse();
            return new ListPaged<TServiceModel>
            {
                List = Mapper.Map<IList<TServiceModel>>(result.Data),
                Total = result.RecordsFiltered
            };
        }

        public IQueryable<TEntityModel> Queryable(params Expression<Func<TEntityModel, object>>[] excludePaths)
        {
            var fields = excludePaths.Select(x => x.Body.GetFieldName())
                                     .Where(x => !string.IsNullOrEmpty(x))
                                     .ToList();
            var query = excludePaths.Any()
                ? BuildQuery(DataContext.Set<TEntityModel>().FromSql(BuildSelectRawSql(fields)))
                : Query;

            if (httpContext.HttpContext.User.IsInRole(UserRoleType.Admin) ||
                userLogin?.Branch == null || userLogin.Has(AccessRight.NoLimitResourceBoundaries))
                return query;

            return typeof(TEntityModel).GetInterfaces().Contains(typeof(IBranchBaseEntity)) 
                ? query.Cast<IBranchBaseEntity>().Where(x => x.BranchId == userLogin.Branch.Id).Cast<TEntityModel>()
                : query;
        }

        private string BuildSelectRawSql(IList<string> excludePaths)
        {
            if (!excludePaths.Any())
                return string.Empty;

            var entitySchema = DataContext.Model.FindEntityType(typeof(TEntityModel));
            var schema = entitySchema.Relational();

            var selectedFields = entitySchema.GetProperties()
                .Select(field => excludePaths.Any(x => x == field.Name)
                    ? $"NULL as [{field.Name}]"
                    : $"[{field.Name}]")
                .ToList();

            var table = string.IsNullOrEmpty(schema.Schema)
                ? $"[{schema.TableName}]"
                : $"[{ schema.Schema}].[{schema.TableName}]";
            return $"SELECT {string.Join(", ", selectedFields)} FROM {table}";
        }
    }
}
