using System;
using System.Windows;

namespace CS.UI.Common.Interfaces
{
    public interface IWindowView
    {
        object DataContext { set; }
        event EventHandler Closed;
        event RoutedEventHandler Loaded;

        void Close();
        void Show();
    }
}