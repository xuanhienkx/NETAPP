using System;
using System.Linq.Expressions;
using api.common.Shared.Base;

namespace api.common.Commands
{
    public class UpdateFieldByIdCommand<T> : BaseCommand<T> where T : ILiteralId
    {
        public string Id { get; }
        public Expression<Func<T, object>> Field { get; }
        public object Value { get; }

        public UpdateFieldByIdCommand(string id, Expression<Func<T, object>> field, object value)
        {
            Id = id;
            Field = field;
            Value = value;
        }
    }
}