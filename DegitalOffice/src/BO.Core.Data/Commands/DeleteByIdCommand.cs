using BO.Core.DataCommon.Shared.Base;
using BO.Core.DataCommon.Shared.Interfaces;

namespace BO.Core.DataCommon.Commands
{
    public class DeleteByIdCommand<T> : BaseCommand<bool> where T : ILiteralId, IPersistentEntity
    {
        public DeleteByIdCommand(string id, bool isPermanent = false)
        {
            Id = id;
            IsPermanentDeleted = isPermanent;
            Arguments = new Dictionary<string, object>();
        }

        public string Id { get; set; }
        public bool IsPermanentDeleted { get; set; }

        public IDictionary<string, object> Arguments { get; set; }

        public bool TryGet<TValue>(string key, out TValue value)
        {
            if (Arguments.ContainsKey(key))
            {
                value = (TValue)Arguments[key];
                return true;
            }

            value = default;

            return false;
        }

        public DeleteByIdCommand<T> With(string key, object value)
        {
            Arguments.Add(key, value);
            return this;
        }
    }

    public class DeleteByIdCommand<T, TSub> : DeleteByIdCommand<T>
        where T : ILiteralId, IPersistentEntity
        where TSub : ILiteralId
    {
        public string SubId { get; }

        public DeleteByIdCommand(string id, string subId, bool isPermanent = false)
            : base(id, isPermanent)
        {
            SubId = subId;
        }
    }

    public class DeleteByIdCommand<T, TSub, TNestedSub> : DeleteByIdCommand<T, TSub>
        where T : ILiteralId, IPersistentEntity
        where TSub : ILiteralId
        where TNestedSub : ILiteralId
    {
        public string NestedSubId { get; }

        public DeleteByIdCommand(string id, string subId, string nestedSubId, bool isPermanent = false)
            : base(id, subId, isPermanent)
        {
            NestedSubId = nestedSubId;
        }
    }
}