using CS.UI.Common;
using System.Windows;
using System.Windows.Input;

namespace CS.Application.Framework
{
    public static class ApplicationCommands
    {
        public static ICommand CloseCommand => new RelayCommand(() => SystemCommands.CloseWindow(System.Windows.Application.Current.MainWindow));
    }
}
