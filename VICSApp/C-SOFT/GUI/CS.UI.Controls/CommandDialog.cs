using System;
using System.ComponentModel;
using MahApps.Metro.SimpleChildWindow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using CS.UI.Common;

namespace CS.UI.Controls
{

    [TemplatePart(Name = CloseButton)]
    [TemplatePart(Name = AcceptButton)]
    public class CommandDialog : ChildWindow
    {
        public const string CloseButton = "PART_CloseButton";
        public const string AcceptButton = "PART_AcceptButton";
        static CommandDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CommandDialog), new FrameworkPropertyMetadata(typeof(CommandDialog)));
        }

        public static readonly DependencyProperty CommandsProperty = DependencyProperty.Register(nameof(Commands), typeof(FrameworkElement), typeof(CommandDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty AcceptTitleProperty = DependencyProperty.Register(nameof(AcceptTitle), typeof(string), typeof(CommandDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty AcceptCommandProperty = DependencyProperty.Register(nameof(AcceptCommand), typeof(ICommand), typeof(CommandDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty CloseTitleProperty = DependencyProperty.Register(nameof(CloseTitle), typeof(string), typeof(CommandDialog), new PropertyMetadata(null));

        public FrameworkElement Commands
        {
            get => (FrameworkElement)GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }

        public ICommand AcceptCommand
        {
            get => (ICommand)GetValue(AcceptCommandProperty);
            set => SetValue(AcceptCommandProperty, value);
        }

        public string AcceptTitle
        {
            get => (string)GetValue(AcceptTitleProperty);
            set => SetValue(AcceptTitleProperty, value);
        }

        public string CloseTitle
        {
            get => (string)GetValue(CloseTitleProperty);
            set => SetValue(CloseTitleProperty, value);
        }

        public bool ShowSaveButton { get; set; }

        private Button acceptButton;
        private Button closeButton;

        public override void OnApplyTemplate()
        {
            this.acceptButton = Template.FindName(AcceptButton, this) as Button;
            if (acceptButton != null)
            {
                if (!ShowSaveButton ||(AcceptCommand == null && string.IsNullOrEmpty(AcceptTitle)))
                {
                    acceptButton.Visibility = Visibility.Hidden;
                }
                else
                {
                    acceptButton.SetBinding(ButtonBase.CommandProperty, new Binding(nameof(AcceptCommand)) { Source = this });
                    acceptButton.Content = AcceptTitle;

                    if (AcceptCommand is ObservedRelayCommand command)
                        command.ExecuteCompleted += CommandOnExecuteCompleted;
                }
            }

            closeButton = Template.FindName(CloseButton, this) as Button;
            if (closeButton != null)
            {
                closeButton.Content = CloseTitle;
                closeButton.Click += CloseButtonOnClick;
            }

            base.OnApplyTemplate();
        }

        private void CommandOnExecuteCompleted(object sender, ExecutedEventArg e)
        {
            if (e.IsCompleted)
                this.Close();
        }

        private void CloseButtonOnClick(object o, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (closeButton != null)
                closeButton.Click -= CloseButtonOnClick;

            if (acceptButton != null && AcceptCommand is ObservedRelayCommand command)
                command.ExecuteCompleted -= CommandOnExecuteCompleted;

            BindingOperations.ClearAllBindings(this);
            base.OnClosing(e);
        }
    }
}
