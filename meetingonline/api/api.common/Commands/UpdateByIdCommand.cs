using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using api.common.Shared.Base;
using MongoDB.Driver;

namespace api.common.Commands
{
    public class UpdateByIdCommand<T> : BaseCommand<bool> where T : ILiteralId
    {
        public string Id { get; }
        public Expression<Func<T, object>> Field { get; }
        public object Value { get; }

        public UpdateByIdCommand(string id, Expression<Func<T, object>> field, object value)
        {
            Id = id;
            Field = field;
            Value = value;
        }
    }

    public class UpdateByIdCommand<T, TSub> : BaseCommand<bool>
        where T : ILiteralId
        where TSub : ILiteralId
    {
        public string Id { get; }
        public string SubId { get; }
        public Expression<Func<T, IEnumerable<TSub>>> ElementMatch { get; }
        public Expression<Func<T, object>> Field { get; }

        public object Value { get; }

        public UpdateByIdCommand(string id, string subId, 
            Expression<Func<T, IEnumerable<TSub>>> elementMatch,
            Expression<Func<T, object>> field, object value)
        {
            Id = id;
            SubId = subId;
            ElementMatch = elementMatch;
            Field = field;
            Value = value;
        }
    }

    public class UpdateManyByIdCommand<T> : BaseCommand<UpdateResult> where T : ILiteralId
    {
        public string Id { get; }
        public List<Tuple<Expression<Func<T, object>>, object>>  UpdateFields { get; set; }

        public UpdateManyByIdCommand(string id)
        {
            Id = id;
            UpdateFields = new List<Tuple<Expression<Func<T, object>>, object>>();
        }
    }
}