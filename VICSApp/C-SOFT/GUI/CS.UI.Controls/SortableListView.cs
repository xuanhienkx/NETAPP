using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace CS.UI.Controls
{
    public class SortableListView : ListView
    {
        private GridViewColumnHeader lastHeaderClicked;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;

        public SortableListView()
        {
            this.AddHandler(
                ButtonBase.ClickEvent,
                new RoutedEventHandler(GridViewColumnHeaderClickedHandler));
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is GridViewColumnHeader headerClicked &&
                headerClicked.Role != GridViewColumnHeaderRole.Padding)
            {
                ListSortDirection direction;
                if (headerClicked != lastHeaderClicked)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    direction = lastDirection == ListSortDirection.Ascending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }

                var sortBy = headerClicked.Column.Header as string;
                var sortDescription = new SortDescription(sortBy, direction);

                if (SortCommand == null)
                    Sort(sortDescription);
                else
                    SortCommand.Execute(sortDescription);

                lastHeaderClicked = headerClicked;
                lastDirection = direction;
            }
        }

        public static readonly DependencyProperty SortCommandProperty =
            DependencyProperty.RegisterAttached("SortCommand", typeof(string), typeof(SortableListView));

        public ICommand SortCommand
        {
            get => (ICommand)GetValue(SortCommandProperty);
            set => SetValue(SortCommandProperty, value);
        }

        private void Sort(SortDescription sortDescription)
        {
            var dataView = CollectionViewSource.GetDefaultView(this.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                dataView.SortDescriptions.Add(sortDescription);
                dataView.Refresh();
            }
        }
    }
}
