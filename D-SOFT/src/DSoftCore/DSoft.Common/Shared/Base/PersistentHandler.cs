using DSoft.Common.Models;
using DSoft.Common.Shared.Interfaces;
using MediatR;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DSoft.Common.Shared.Base;

public class PersistentHandlerOptions<T>
{
    public List<UpdateDefinition<T>> UpdateFields { get; } = new List<UpdateDefinition<T>>();
    public List<FilterDefinition<T>> FilterFields { get; } = new List<FilterDefinition<T>>();
}

public class PersistentHandlerOptions<T, TOut> : PersistentHandlerOptions<T>
{
    public ProjectionDefinition<T, TOut> Projection { get; set; }
    public Func<TOut, TOut> OnSetupItem { get; set; }
    public Action<TOut> OnUpdated { get; set; }
    public Action OnInserted { get; set; }
    public Action<TOut> OnDeleted { get; set; }
}

public abstract class PersistentHandler<T, TComponent> : BaseHandler
    where T : IPersistentEntity, ILiteralId
    where TComponent : IPersistentService<TComponent>
{
    protected readonly IPersistentService<TComponent> PersistentService;

    protected IMongoCollection<T> Collection => PersistentService.GetCollection<T>();

    protected PersistentHandler(IMediator mediator, IPersistentService<TComponent> persistentService, ILocalizer localizer)
        : base(mediator, localizer)
    {
        PersistentService = persistentService ?? throw new ArgumentNullException(nameof(persistentService));
    }

    protected abstract ProjectionDefinition<T> ExcludeGetProjection { get; }

    protected async Task<UpdateResult> Update(
        string id, Action<PersistentHandlerOptions<T>> options,
        CancellationToken cancellationToken)
    {
        var opt = new PersistentHandlerOptions<T>
        {
            FilterFields = { Builders<T>.Filter.Eq(x => x.Id, id) }
        };
        options(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);
        var update = Builders<T>.Update.Combine(opt.UpdateFields);
        return PersistentService.HasSession
            ? await PersistentService.GetCollection<T>().UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
            : await PersistentService.GetCollection<T>().UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

    }

    protected async Task<T> UpdateAndReturn(
        string id, Action<PersistentHandlerOptions<T>> options,
        CancellationToken cancellationToken)
    {
        var opt = new PersistentHandlerOptions<T>
        {
            FilterFields = { Builders<T>.Filter.Eq(x => x.Id, id) }
        };
        options(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);
        var update = Builders<T>.Update.Combine(opt.UpdateFields);
        var option = new FindOneAndUpdateOptions<T, T> { ReturnDocument = ReturnDocument.After };
        return PersistentService.HasSession
            ? await PersistentService.GetCollection<T>().FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
            : await PersistentService.GetCollection<T>().FindOneAndUpdateAsync(filter, update, option, cancellationToken);
    }

    protected async Task<Result<TValue>> UpdateOneToSubSet<TValue>(
        string id,
        Expression<Func<TValue, bool>> subFilter,
        Expression<Func<T, IEnumerable<TValue>>> field,
        Action<PersistentHandlerOptions<T, TValue>> options = null,
        CancellationToken cancellationToken = default)
    {
        var opt = new PersistentHandlerOptions<T, TValue>
        {
            FilterFields = { Builders<T>.Filter.Eq(x => x.Id, id) }
        };
        options?.Invoke(opt);

        var filters = opt.FilterFields.ToList();

        filters.Add(Builders<T>.Filter.ElemMatch(field, subFilter));
        var filter = Builders<T>.Filter.And(filters);
        var projection = opt.Projection ?? Builders<T>.Projection.Expression(x => field.Compile().Invoke(x).FirstOrDefault(subFilter.Compile()));

        var collection = PersistentService.GetCollection<T>();

        var oldOne = await collection.Find(filter)
            .Project(projection)
            .SingleOrDefaultAsync(cancellationToken);

        var value = opt.OnSetupItem.Invoke(oldOne);
        if (oldOne == null)
        {
            // add to set
            filter = Builders<T>.Filter.And(opt.FilterFields);
            var update = Builders<T>.Update.AddToSet(field, value);
            var result = PersistentService.HasSession
                ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
                : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
            if (result.ModifiedCount != 0)
                opt.OnInserted?.Invoke();
        }
        else
        {
            var option = new FindOneAndUpdateOptions<T, TValue>
            {
                ReturnDocument = ReturnDocument.After,
                Projection = projection
            };
            var update = Builders<T>.Update.Set($"{((MemberExpression)field.Body).Member.Name}.$", value);
            value = PersistentService.HasSession
                ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
                : await collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);
            if (value != null)
                opt.OnUpdated?.Invoke(oldOne);
        }
        if (value == null)
            return Error<TValue>("common.resourceNotFound");
        return Result(value);
    }

    protected async Task<Result<TValue>> UpdateOneToSubSet<TValue>(
        string id, TValue value,
        Expression<Func<T, IEnumerable<TValue>>> field,
        Action<PersistentHandlerOptions<T>> options = null,
        CancellationToken cancellationToken = default) where TValue : ILiteralId
    {
        var opt = new PersistentHandlerOptions<T>
        {
            FilterFields = { Builders<T>.Filter.Eq(x => x.Id, id) }
        };
        options?.Invoke(opt);

        var filters = opt.FilterFields.ToList();

        filters.Add(Builders<T>.Filter.ElemMatch(field, x => x.Id.Equals(value.Id)));
        var filter = Builders<T>.Filter.And(filters);

        var collection = PersistentService.GetCollection<T>();
        var update = Builders<T>.Update.Set($"{((MemberExpression)field.Body).Member.Name}.$", value);

        var option = new FindOneAndUpdateOptions<T, TValue>
        {
            ReturnDocument = ReturnDocument.After,
            Projection = Builders<T>.Projection.Expression(x => field.Compile().Invoke(x).FirstOrDefault(v => v.Id.Equals(value.Id)))
        };

        var updated = PersistentService.HasSession
            ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, update, option, cancellationToken)
            : await collection.FindOneAndUpdateAsync(filter, update, option, cancellationToken);
        if (updated != null)
        {
            return Result(updated);
        }

        // add to set
        filter = Builders<T>.Filter.And(opt.FilterFields);
        update = Builders<T>.Update.AddToSet(field, value);
        var result = PersistentService.HasSession
            ? await collection.UpdateOneAsync(PersistentService.Session, filter, update, cancellationToken: cancellationToken)
            : await collection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);

        if (result.MatchedCount != 0 || result.ModifiedCount != 0)
        {
            return Result(value);
        }

        return Error<TValue>("common.resourceNotFound");
    }

    protected async Task<Result<bool>> DeleteFromSubSet<TValue>(
        string id, string subId,
        Expression<Func<T, IEnumerable<TValue>>> field,
        Action<PersistentHandlerOptions<T, TValue>> options = null,
        CancellationToken cancellationToken = default)
        where TValue : ILiteralId
    {
        var opt = new PersistentHandlerOptions<T, TValue>
        {
            FilterFields = { Builders<T>.Filter.Eq(x => x.Id, id) }
        };
        options?.Invoke(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);
        var delete = Builders<T>.Update.PullFilter(field, x => x.Id.Equals(subId));
        var option = new FindOneAndUpdateOptions<T, TValue>
        {
            ReturnDocument = ReturnDocument.Before,
            Projection = opt.Projection ?? Builders<T>.Projection.Expression(x => field.Compile().Invoke(x).FirstOrDefault(v => v.Id.Equals(subId)))
        };
        var collection = PersistentService.GetCollection<T>();
        var result = PersistentService.HasSession
            ? await collection.FindOneAndUpdateAsync(PersistentService.Session, filter, delete, option, cancellationToken)
            : await collection.FindOneAndUpdateAsync(filter, delete, option, cancellationToken);

        if (result != null)
        {
            opt.OnDeleted?.Invoke(result);
            return Result(true);
        }

        return Result(false);
    }

    protected async Task<Result<bool>> DeleteFromNestedSubSet<TValue, TOut>(
        string id, string subId, string pullId,
        Expression<Func<T, IEnumerable<TValue>>> contentField,
        Expression<Func<T, IEnumerable<TOut>>> pullField,
        Action<PersistentHandlerOptions<T>> options = null,
        CancellationToken cancellationToken = default)
        where TValue : ILiteralId
        where TOut : ILiteralId
    {
        var opt = new PersistentHandlerOptions<T>
        {
            FilterFields =
                {
                    Builders<T>.Filter.Eq(x => x.Id, id),
                    Builders<T>.Filter.ElemMatch(contentField, x => x.Id.Equals(subId))
                }
        };
        options?.Invoke(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);
        var delete = Builders<T>.Update.PullFilter(pullField, m => m.Id.Equals(pullId));

        var collection = PersistentService.GetCollection<T>();
        var result = PersistentService.HasSession
            ? await collection.UpdateOneAsync(PersistentService.Session, filter, delete, cancellationToken: cancellationToken)
            : await collection.UpdateOneAsync(filter, delete, cancellationToken: cancellationToken);

        return Result(result.ModifiedCount != 0);
    }

    protected async Task<Result<TValue>> QueryByIdFromSubSet<TValue>(
        string id,
        Expression<Func<T, IEnumerable<TValue>>> contentField,
        Expression<Func<TValue, bool>> filterValue,
        Action<PersistentHandlerOptions<T, TValue>> options = null,
        CancellationToken cancellationToken = default)
    where TValue : ILiteralId
    {
        var opt = new PersistentHandlerOptions<T, TValue>
        {
            FilterFields =
                {
                    Builders<T>.Filter.Eq(x => x.Id, id),
                    Builders<T>.Filter.ElemMatch( contentField, filterValue)
                }
        };
        options?.Invoke(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);
        var projection = opt.Projection ?? Builders<T>.Projection.Expression(x => contentField.Compile().Invoke(x).FirstOrDefault(v => filterValue.Compile().Invoke(v)));
        var result = await PersistentService.GetCollection<T>()
            .Find(filter)
            .Project(projection)
            .FirstOrDefaultAsync(cancellationToken);

        return new Result<TValue>(result);
    }

    protected async Task<Result<List<TValue>>> QuerySubSet<TValue>(
        string id,
        ProjectionDefinition<T, IEnumerable<TValue>> projection,
        Action<PersistentHandlerOptions<T>> options = null,
        CancellationToken cancellationToken = default)
    {
        var opt = new PersistentHandlerOptions<T>
        {
            FilterFields =
                {
                    Builders<T>.Filter.Eq(x => x.Id, id)
                }
        };

        options?.Invoke(opt);

        var filter = Builders<T>.Filter.And(opt.FilterFields);

        var result = await PersistentService.GetCollection<T>()
            .Find(filter)
            .Project(projection)
            .FirstOrDefaultAsync(cancellationToken);

        return new Result<List<TValue>>(result.ToList());
    }
}