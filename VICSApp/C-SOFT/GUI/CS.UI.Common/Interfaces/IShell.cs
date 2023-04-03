using System;
using System.Collections.Generic;
using CS.Common.Contract;
using System.Windows;
using System.Windows.Input;

namespace CS.UI.Common.Interfaces
{
    public interface IShell
    {
        string CurrentPath { get; set; }
        IUserLogin User { get; set; }
        ICommand SignOutCommand { get; }
        bool IsBusy { get; set; }
        bool IsEnabledNavigationMenu { get; set; }
        bool IsDialogOpened { get; set; }
        bool IsShowNavigationMenu { get; set; }
        FrameworkElement ElementView { get; set; }
        IList<NavigationItem> NavigationItems { get; set; }
        string Description { get; set; }
        void Navigate(NavigationItem navigationItem);

        void ShowMessage(NotificationMessage message);
        void Log(string message = null);
    }
}