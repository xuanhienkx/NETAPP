using System.Web;
using GridMvc.Filtering;
using GridMvc.Sorting;
using SMS.Common.Models;

namespace VicsManageWeb.Common.UI.Grid
{
    public class PagedGrid
    {
        public PagedGrid(SortField sortField)
        {
            SortField = sortField;
        }

        public static PagedGrid GetCurrent(HttpContext httpContext)
        {
            var sortedColumn = new QueryStringSortSettings(httpContext);

            var grid = new PagedGrid(new SortField(sortedColumn.ColumnName, sortedColumn.Direction == GridSortDirection.Ascending))
            {
                FilterColumnCollection = new QueryStringFilterSettings(httpContext).FilteredColumns
            };
            return grid;
        }

        public IFilterColumnCollection FilterColumnCollection { get; private set; }
        public SortField SortField { get; private set; }
    }
}
