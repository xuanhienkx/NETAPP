using CS.Application.Controllers;
using CS.Application.Views.Home;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CS.Application.Views
{
    public class MainWindowViewModel : ViewModelBase, IShell
    {
        public MainWindowViewModel()
        {
            ElementView = new ContentControl();
            Settings = new SettingsViewModel();

            SignOutCommand = new RelayCommand(SignOut);
            UserProfileCommand = new RelayCommand(EditUserProfile);
            NavigationItemSelectedCommand = new RelayCommand<NavigationItem>(Navigate);
            IsEnabledNavigationMenu = true;
            MessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(2));
        }

        public bool ShowFlyoutMessage
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool IsBusy
        {
            get => Get<bool>();
            set => Set(value);
        }

        public ISnackbarMessageQueue MessageQueue { get; }

        public string CurrentPath { get; set; }
        public NavigationItem CurrentNavigationItem { get; set; }

        public IUserLogin User
        {
            get => Get<IUserLogin>();
            set
            {
                Set(value);
                NotifyPropertyChanged(() => IsAuthenticated);
                NotifyPropertyChanged(() => IsVisibleNavigationMenu);
            }
        }

        public bool IsAuthenticated => CurrentPrincipal.Instance.IsAuthenticated;

        public bool IsVisibleNavigationMenu => IsAuthenticated
                                               && CurrentPrincipal.Instance.IsInRole(UserRoleType.User);

        public bool IsShowNavigationMenu
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool IsEnabledNavigationMenu
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool IsDialogOpened
        {
            get => Get<bool>();
            set => Set(value);
        }

        public IList<NavigationItem> NavigationItems
        {
            get => Get<IList<NavigationItem>>();
            set => Set(value);
        }

        public FrameworkElement ElementView
        {
            get => Get<FrameworkElement>();
            set => Set(value);
        }

        public ICommand SignOutCommand { get; }
        public ICommand UserProfileCommand { get; }
        public ICommand NavigationItemSelectedCommand { get; }

        public void ShowMessage(NotificationMessage message)
        {
            if (message.Type == NotificationType.Content &&
                ElementView.DataContext is IObservableListViewModel listView)
            {
                var model = listView.ParseModel(message.Content);
                if (listView.ViewId.Equals(message.RequestId))
                    listView.UpdateModel(model);
                else
                    MessageQueue.Enqueue(model);
            }
            else
            {
                MessageQueue.Enqueue(message);
            }

        }

        public SettingsViewModel Settings { get; }
        public string Description { get => Get<string>(); set => Set(value); }

        public void Log(string message = null)
        {
            if (string.IsNullOrEmpty(message))
                Settings.LogMessage = null;
            else
                Settings.LogMessage += $"{Environment.NewLine}{message}";
        }

        #region Methods

        private void EditUserProfile()
        {
            if (CurrentPath.Equals("user/userprofile"))
                return;

            Invoke<UserController>(c => c.UserProfile());
        }

        private void SignOut() => Invoke<HomeController>(controller => controller.SignOut(CurrentPath));

        public void Navigate(NavigationItem navigationItem)
        {
            if (string.IsNullOrEmpty(navigationItem.Path) || navigationItem.Path.Equals(CurrentPath))
                return;
            CurrentNavigationItem = navigationItem;
            CurrentPath = navigationItem.Path;
            IsShowNavigationMenu = false;

            Invoke<HomeController>(c => c.Navigate(navigationItem));
        }

        #endregion

        public override string Title { get; }
        public override string SubTitle { get; }
    }
}