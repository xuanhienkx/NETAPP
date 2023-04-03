using BO.Core.DataCommon.Shared.Base;
using System.Linq.Expressions;

namespace BO.Core.DataCommon.Commands
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