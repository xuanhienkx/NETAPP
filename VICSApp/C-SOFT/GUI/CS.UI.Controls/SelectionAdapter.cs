using System;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace CS.UI.Controls
{
    public class SelectionAdapter
    {
        #region "Fields"

        #endregion

        #region "Constructors"

        public SelectionAdapter(Selector selector)
        {
            SelectorControl = selector;
            SelectorControl.PreviewMouseDown += OnSelectorMouseDown;
            SelectorControl.MouseUp += SelectorControlOnMouseUp;
        }

        #endregion

        #region "Events"

        public delegate void CancelEventHandler();
        public delegate void CommitEventHandler();
        public delegate void SelectionChangedEventHandler();

        public event CancelEventHandler Cancel;
        public event CommitEventHandler Commit;
        public event SelectionChangedEventHandler SelectionChanged;
        #endregion

        #region "Properties"

        public Selector SelectorControl { get; set; }

        #endregion

        #region "Methods"

        public void HandleKeyDown(KeyEventArgs key)
        {
            Debug.WriteLine(key.Key);
            switch (key.Key)
            {
                case Key.Down:
                    IncrementSelection();
                    break;
                case Key.Up:
                    DecrementSelection();
                    break;
                case Key.Enter:
                case Key.Space:
                    CommitFirstSelection();
                    break;
                //case Key.Tab:
                //    Commit?.Invoke();
                //    break;
                case Key.Escape:
                    Cancel?.Invoke();
                    break;
            }
        }

        private void CommitFirstSelection()
        {
            if (SelectorControl.SelectedIndex == -1)
            {
                IncrementSelection();

                if (SelectorControl.Items.Count == 1)
                    Commit?.Invoke();
            }
            else
            {
                Commit?.Invoke();
            }
        }

        private void DecrementSelection()
        {
            if (SelectorControl.SelectedIndex == -1)
            {
                SelectorControl.SelectedIndex = SelectorControl.Items.Count - 1;
            }
            else
            {
                SelectorControl.SelectedIndex -= 1;
            }
            SelectionChanged?.Invoke();
        }

        private void IncrementSelection()
        {
            if (SelectorControl.SelectedIndex == SelectorControl.Items.Count - 1)
            {
                SelectorControl.SelectedIndex = -1;
            }
            else
            {
                SelectorControl.SelectedIndex += 1;
            }
            SelectionChanged?.Invoke();
        }

        private void OnSelectorMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = e.ChangedButton == MouseButton.Left;
        }

        private void SelectorControlOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var selector = (Selector)sender;

            if (e.ChangedButton == MouseButton.Left && e.OriginalSource is Visual source)
            {
                var container = selector.ContainerFromElement(source);
                if (container != null)
                {
                    var index = selector.ItemContainerGenerator.IndexFromContainer(container);
                    if (index >= 0)
                    {
                        selector.SelectedIndex = index;
                    }
                }
            }

            Commit?.Invoke();
        }

        #endregion

    }
}
