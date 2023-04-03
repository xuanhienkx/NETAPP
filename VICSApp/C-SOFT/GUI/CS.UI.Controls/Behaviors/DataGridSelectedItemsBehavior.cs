using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CS.UI.Controls.Behaviors
{
    public class DataGridSelectedItemsBehavior : Behavior<DataGrid>
    {

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<object>),
                typeof(DataGridSelectedItemsBehavior),
                new FrameworkPropertyMetadata(null)
                {
                    BindsTwoWayByDefault = true
                });

        public ObservableCollection<object> SelectedItems
        {
            get
            {
                return (ObservableCollection<object>)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += OnSelectionChanged;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.SelectedItems != null)
            {
                var selectedItems = this.SelectedItems.ToList();
                foreach (var obj in selectedItems)
                {
                    var rowContainer = this.AssociatedObject.ItemContainerGenerator.ContainerFromItem(obj) as DataGridRow;
                    if (rowContainer != null)
                    {
                        rowContainer.IsSelected = true;
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectionChanged -= OnSelectionChanged;
                this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0 && this.SelectedItems != null)
            {
                foreach (object obj in e.AddedItems)
                    this.SelectedItems.Add(obj);
            }

            if (e.RemovedItems != null && e.RemovedItems.Count > 0 && this.SelectedItems != null)
            {
                foreach (object obj in e.RemovedItems)
                    this.SelectedItems.Remove(obj);
            }
        }
    }
}