using CS.Common.Contract;
using CS.Common.Std.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract.Enums;

namespace CS.UI.Common.ViewBase
{
    public abstract class ListPagedViewModel<TKey, T> : ListViewModel<TKey, T>
        where T : class, IResource<TKey>
    {
        private readonly Dictionary<string, string> filterOptions = new Dictionary<string, string>();

        protected ListPagedViewModel(string filterText)
        {
            SearchText = filterText;
            PageIndex = 0;
        }

        protected ListPagedViewModel() : this(null)
        {
            NavigationButtons = new ObservableCollection<NavigationItem>();

            FilterCommand = new RelayCommand<string>(Refresh);
            NavigationButtonCommand = new RelayCommand<NavigationItem>(Navigate);
        }

        public string SearchText
        {
            get => Get<string>();
            set => Set(value);
        }

        public int PageIndex
        {
            get => Get<int>();
            set => Set(value);
        }

        public ObservableCollection<NavigationItem> NavigationButtons { get; set; }
        public ICommand NavigationButtonCommand { get; }

        public ICommand FilterCommand { get; }

        protected void AddFilteredFields<TProperty>(params Expression<Func<T, TProperty>>[] fields)
        {
            var idx = 0;
            foreach (var field in fields)
            {
                var keyName = DataParserConstants.GetKey(DataParserConstants.DataPropertyFormat, idx);
                filterOptions.Add(keyName, field.Body.GetFieldName());

                keyName = DataParserConstants.GetKey(DataParserConstants.SearchablePropertyFormat, idx);
                filterOptions.Add(keyName, Boolean.TrueString);

                keyName = DataParserConstants.GetKey(DataParserConstants.OrderablePropertyFormat, idx);
                filterOptions.Add(keyName, Boolean.TrueString);

                idx++;
            }
        }

        protected void Refresh(string searchText)
        {
            // update filter
            SearchText = searchText;

            // refresh list
            Refresh();
        }

        public int Total
        {
            get => Get<int>();
            set => Set(value);
        }

        protected abstract Task<ListPaged<T>> GetListPaged(IDictionary<string, string> filterOptions);

        protected override async Task<IList<T>> GetList()
        {
            var pageSize = ApplicationSettings.Instance.Settings.PageSize;
            filterOptions[DataParserConstants.Length] = pageSize.ToString();
            filterOptions[DataParserConstants.Start] = PageIndex.ToString();
            filterOptions[DataParserConstants.SearchKey] = SearchText;

            var result = await GetListPaged(filterOptions);
            if (result == null)
                return new List<T>();

            Total = result.Total;
            var pageCount = (Total + pageSize - 1) / pageSize;
           
            // build pager navigation button
            BuildNavigationButton(PageIndex, pageCount);

            return result.List ?? new List<T>();
        }

        protected abstract override AccessRight AccessRight { get; }

        private void Navigate(NavigationItem nav)
        {
            if (int.TryParse(nav.Title, out var page))
            {
                PageIndex = page - 1;
                Refresh();
            }
            else
            {
                var pageSize = ApplicationSettings.Instance.Settings.PageSize;
                var pageCount = (Total + pageSize - 1) / pageSize;
                NavigationItem item;
                switch (nav.Path)
                {
                    case "<":
                        item = NavigationButtons.First(x => !string.IsNullOrEmpty(x.Title));
                        if (int.TryParse(item.Title, out var pIdx))
                        {
                            pIdx = pIdx - 4;
                            BuildNavigationButton(Math.Max(pIdx, 1) + 2, pageCount);
                        }
                        break;

                    case ">":
                        item = NavigationButtons.Last(x => !string.IsNullOrEmpty(x.Title));
                        if (int.TryParse(item.Title, out var pageIndex))
                        {
                            pageIndex = pageIndex + 4;
                            BuildNavigationButton(Math.Min(pageIndex, pageCount) - 2, pageCount);
                        }
                        break;
                }
            }
        }

        private void BuildNavigationButton(int pageIndex, int pageCount)
        {
            NavigationButtons.Clear();
            
            var startPage = pageIndex - 2;
            var endPage = pageIndex + 2;
            
            if (endPage > pageCount)
            {
                var oddPage = endPage - pageCount;
                endPage = pageCount;
                startPage = startPage - oddPage;
            }

            if (startPage < 1)
            {
                startPage = 1;
                endPage = Math.Min(5, pageCount);
            }

            if (startPage > 1)
            {
                // add first
                NavigationButtons.Add(new NavigationItem
                {
                    Description = Translate("NavigationPager_PreviousPageTitle"),
                    Path = "<"
                });
            }

            // add all pages button
            for (var i = startPage; i <= endPage; i++)
            {
                NavigationButtons.Add(new NavigationItem
                {
                    Title = i.ToString(),
                    Description = string.Format(Translate("NavigationPager_PageTitle"), i),
                    IsSelected = i == PageIndex + 1
                });
            }

            if (endPage < pageCount)
            {
                // add last
                NavigationButtons.Add(new NavigationItem
                {
                    Description = Translate("NavigationPager_NextPageTitle"),
                    Path = ">"
                });
            }
        }
    }
}