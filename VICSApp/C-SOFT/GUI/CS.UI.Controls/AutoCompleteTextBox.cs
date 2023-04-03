using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace CS.UI.Controls
{
    [TemplatePart(Name = PartEditor, Type = typeof(TextBox))]
    [TemplatePart(Name = PartPopup, Type = typeof(Popup))]
    [TemplatePart(Name = PartSelector, Type = typeof(Selector))]
    public class AutoCompleteTextBox : TextBox
    {

        #region "Fields"

        public const string PartEditor = "PART_Editor";
        public const string PartPopup = "PART_Popup";
        public const string PartSelector = "PART_Selector";

        public static readonly DependencyProperty DisplayMemberProperty = DependencyProperty.Register("DisplayMember", typeof(string), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register("IsLoading", typeof(bool), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty ItemTemplateSelectorProperty = DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty LoadingContentProperty = DependencyProperty.Register("LoadingContent", typeof(object), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(null, OnSelectedItemChanged));
        public static readonly DependencyProperty MaxPopUpHeightProperty = DependencyProperty.Register("MaxPopUpHeight", typeof(int), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(600));
        public static readonly DependencyProperty FilterTextChangedCommandProperty = DependencyProperty.Register("FilterTextChangedCommand", typeof(FilterCommand), typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(null));

        private readonly SuggestionsAdapter suggestionsAdapter;
        private readonly DispatcherTimer fetchDispatcherTimer;

        private bool isUpdatingText;
        private bool selectionCancelled;
        private BindingEvaluator bindingEvaluator;
        private SelectionAdapter selectionAdapter;
        private string filter;

        private TextBox textEditor;
        private Selector itemsSelector;
        private Popup popup;

        #endregion

        #region "Constructors"

        static AutoCompleteTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AutoCompleteTextBox), new FrameworkPropertyMetadata(typeof(AutoCompleteTextBox)));
        }

        public AutoCompleteTextBox()
        {
            suggestionsAdapter = new SuggestionsAdapter(this);

            fetchDispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            fetchDispatcherTimer.Tick += OnFetchTimerTick;
        }

        #endregion

        #region "Properties"


        public int MaxPopupHeight
        {
            get => (int)GetValue(MaxPopUpHeightProperty);
            set => SetValue(MaxPopUpHeightProperty, value);
        }

        public FilterCommand FilterTextChangedCommand
        {
            get => (FilterCommand)GetValue(FilterTextChangedCommandProperty);
            set => SetValue(FilterTextChangedCommandProperty, value);
        }

        public string DisplayMember
        {
            get => (string)GetValue(DisplayMemberProperty);
            set => SetValue(DisplayMemberProperty, value);
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        public bool IsDropDownOpen
        {
            get => (bool)GetValue(IsDropDownOpenProperty);
            set => SetValue(IsDropDownOpenProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public DataTemplateSelector ItemTemplateSelector
        {
            get => ((DataTemplateSelector)(GetValue(ItemTemplateSelectorProperty)));
            set => SetValue(ItemTemplateSelectorProperty, value);
        }

        public object LoadingContent
        {
            get => GetValue(LoadingContentProperty);
            set => SetValue(LoadingContentProperty, value);
        }

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        #endregion

        #region "Methods"

        public static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AutoCompleteTextBox act)
            {
                if (act.textEditor != null & !act.isUpdatingText)
                {
                    act.isUpdatingText = true;
                    act.textEditor.Text = act.bindingEvaluator.Evaluate(e.NewValue);
                    act.isUpdatingText = false;
                }
            }
        }

        private void ScrollToSelectedItem()
        {
            if (itemsSelector is ListBox listBox && listBox.SelectedItem != null)
                listBox.ScrollIntoView(listBox.SelectedItem);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            textEditor = Template.FindName(PartEditor, this) as TextBox;
            popup = Template.FindName(PartPopup, this) as Popup;
            itemsSelector = Template.FindName(PartSelector, this) as Selector;
            bindingEvaluator = new BindingEvaluator(new Binding(DisplayMember));

            if (textEditor != null)
            {
                if (SelectedItem != null)
                    textEditor.Text = bindingEvaluator.Evaluate(SelectedItem);

                textEditor.TextChanged += OnEditorTextChanged;
                textEditor.PreviewKeyDown += OnEditorKeyDown;
                textEditor.LostFocus += OnEditorLostFocus;
            }

            GotFocus += AutoCompleteTextBoxGotFocus;

            if (popup != null)
            {
                popup.StaysOpen = false;
                popup.Opened += OnPopupOpened;
                popup.Closed += OnPopupClosed;
            }

            if (itemsSelector != null)
            {
                selectionAdapter = new SelectionAdapter(itemsSelector);
                selectionAdapter.Commit += OnSelectionAdapterCommit;
                selectionAdapter.Cancel += OnSelectionAdapterCancel;
                selectionAdapter.SelectionChanged += OnSelectionAdapterSelectionChanged;
            }
        }

        private void AutoCompleteTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            textEditor?.Focus();
        }

        private string GetDisplayText(object dataItem)
        {
            if (bindingEvaluator == null)
            {
                bindingEvaluator = new BindingEvaluator(new Binding(DisplayMember));
            }
            if (dataItem == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(DisplayMember))
            {
                return dataItem.ToString();
            }
            return bindingEvaluator.Evaluate(dataItem);
        }

        private void OnEditorKeyDown(object sender, KeyEventArgs e)
        {
            if (selectionAdapter != null)
            {
                if (IsDropDownOpen)
                    selectionAdapter.HandleKeyDown(e);
                else
                    IsDropDownOpen = e.Key == Key.Down || e.Key == Key.Up;
            }
        }

        private void OnEditorLostFocus(object sender, RoutedEventArgs e)
        {
            if (!IsKeyboardFocusWithin)
            {
                IsDropDownOpen = false;
            }
        }

        private void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdatingText)
                return;

            SetSelectedItem(null);
            if (textEditor.Text.Length > 0)
            {
                if (!fetchDispatcherTimer.IsEnabled)
                {
                    IsDropDownOpen = true;
                    itemsSelector.ItemsSource = null;

                    fetchDispatcherTimer.Start();
                }
            }
            else
            {
                IsDropDownOpen = false;
            }
        }

        private void OnFetchTimerTick(object sender, EventArgs e)
        {
            if (IsLoading)
                return;

            if (FilterTextChangedCommand != null && itemsSelector != null)
            {
                filter = textEditor.Text;
                suggestionsAdapter.GetSuggestions(textEditor.Text);
            }
        }

        private void OnPopupClosed(object sender, EventArgs e)
        {
            if (!selectionCancelled)
            {
                OnSelectionAdapterCommit();
            }
        }

        private void OnPopupOpened(object sender, EventArgs e)
        {
            selectionCancelled = false;
            itemsSelector.SelectedItem = SelectedItem;
        }

        private void OnSelectionAdapterCancel()
        {
            isUpdatingText = true;
            textEditor.Text = SelectedItem == null ? filter : GetDisplayText(SelectedItem);
            textEditor.SelectionStart = textEditor.Text.Length;
            textEditor.SelectionLength = 0;
            isUpdatingText = false;
            IsDropDownOpen = false;
            selectionCancelled = true;
        }

        private void OnSelectionAdapterCommit()
        {
            if (itemsSelector.SelectedItem != null)
            {
                SelectedItem = itemsSelector.SelectedItem;
                isUpdatingText = true;
                textEditor.Text = GetDisplayText(itemsSelector.SelectedItem);
                SetSelectedItem(itemsSelector.SelectedItem);
                isUpdatingText = false;
                IsDropDownOpen = false;
            }
        }

        private void OnSelectionAdapterSelectionChanged()
        {
            isUpdatingText = true;
            if (itemsSelector.SelectedItem == null)
            {
                textEditor.Text = filter;
            }
            else
            {
                textEditor.Text = GetDisplayText(itemsSelector.SelectedItem);
            }
            textEditor.SelectionStart = textEditor.Text.Length;
            textEditor.SelectionLength = 0;
            ScrollToSelectedItem();
            isUpdatingText = false;
        }

        private void SetSelectedItem(object item)
        {
            isUpdatingText = true;
            SelectedItem = item;
            isUpdatingText = false;
        }
        #endregion

        #region Nested class

        public class FilterCommand : ICommand
        {
            private bool isExecuting;
            private readonly Func<string, Task<IEnumerable>> execute;
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            public FilterCommand(Func<string, Task<IEnumerable>> execute)
            {
                this.execute = execute;
                isExecuting = false;
            }

            public Action<IEnumerable> UpdateAction { get; internal set; }

            public bool CanExecute(object parameter)
            {
                return !isExecuting;
            }

            public async void Execute(object parameter)
            {
                if (!(parameter is string filter))
                    return;

                isExecuting = true;

                var result = await execute.Invoke(filter);
                UpdateAction?.Invoke(result);

                isExecuting = false;
            }
        }
        
        #region "Nested Types"

        private class SuggestionsAdapter
        {

            #region "Fields"

            private readonly AutoCompleteTextBox actb;

            private string filter;
            #endregion

            #region "Constructors"

            public SuggestionsAdapter(AutoCompleteTextBox actb)
            {
                this.actb = actb;
            }

            #endregion

            #region "Methods"

            public void GetSuggestions(string searchText)
            {
                if (actb.IsLoading)
                    return;

                filter = searchText;
                actb.IsLoading = true;

                var th = new Thread(GetSuggestionsAsync);
                th.Start(new object[] {
                    searchText,
                    actb.FilterTextChangedCommand
                });
            }

            private void DisplaySuggestions(IEnumerable suggestions, string filter)
            {
                actb.IsLoading = false;

                if (actb.textEditor.Text != filter)
                    return;
                
                actb.fetchDispatcherTimer.IsEnabled = false;
                actb.fetchDispatcherTimer.Stop();

                if (actb.IsDropDownOpen)
                {
                    actb.itemsSelector.ItemsSource = suggestions;
                    actb.IsDropDownOpen = actb.itemsSelector.HasItems;
                }
            }

            private void GetSuggestionsAsync(object param)
            {
                var args = param as object[];
                var searchText = Convert.ToString(args[0]);
                var filterCommand = args[1] as FilterCommand;
                if (filterCommand != null)
                {
                    filterCommand.UpdateAction = list =>
                    {
                        actb.Dispatcher.BeginInvoke(new Action<IEnumerable, string>(DisplaySuggestions), DispatcherPriority.Background, new object[] {
                            list,
                            searchText
                        });
                    };
                }
                filterCommand?.Execute(actb.filter);
            }

            #endregion

        }

        #endregion

        #endregion
    }
}
