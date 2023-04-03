﻿using api.common.Shared.Base;

namespace api.common.Queries
{
    public class GetByIdQuery<T> : BaseQuery<T> where T : class
    {
        public GetByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }

    public class GetByIdFromSubSetQuery<T, TSub> : BaseQuery<TSub> where T : ILiteralId where TSub : ILiteralId
    {
        public GetByIdFromSubSetQuery(string id, string subId)
        {
            Id = id;
            SubId = subId;
        }
        public string Id { get; }
        public string SubId { get; }
    }

}