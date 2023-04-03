using System;
using System.Collections.Generic;
using api.common.Shared.Base;

namespace api.common.Queries
{
    public class SearchQuery<T> : BaseQuery<List<T>> where T : class
    {
        public string Text { get; }
        public int Size { get; }
        public int Index { get; }
        public int Skip { get; }
        public SearchQuery(string text, int size, int index = 0)
        {
            Text = text;
            Size = size;
            Index = Math.Min(index, 100);
            Skip = Index * Size;
        }
    }

    public class SearchQuery<T, TOut> : SearchQuery<TOut>
    where T : ILiteralId
    where TOut : class
    {
        public string Id { get; }

        public SearchQuery(string id, string text, int size, int index = 0)
        : base(text, size, index)
        {
            Id = id;
        }
    }
}