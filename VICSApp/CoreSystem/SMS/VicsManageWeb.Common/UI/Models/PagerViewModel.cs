using System.Collections.Generic;
using SMS.Common.Models;

namespace VicsManageWeb.Common.UI.Models
{
    public class PagedList<T> 
    {
        public PagedList()
        {}

        public PagedList(IEnumerable<T> items)
            : this()
        {
            Items = items;
        }

        public PagedList(IEnumerable<T> items, int pageSize)
            : this (items)
        {
            PageSize = pageSize;
        }

        public PagedList(IEnumerable<T> items, int pageSize, int totalItems)
            : this(items, pageSize)
        {
            TotalItemsCount = totalItems;
        }
        public IEnumerable<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
       public List<SortField> SortFields { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string UpdateTargetId { get; set; }
    }
}
