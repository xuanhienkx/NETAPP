using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CS.Common.Contract;

namespace CS.UI.Common.Interfaces
{
    public interface IViewModel 
    {
        bool IsRootView { get; set; }
        string Title { get; }
        string SubTitle { get; }
        void OnBinding();
    }

    public interface IDialogViewModel : IViewModel
    {
        ExecuteType ViewType { get; }
        ICommand SaveCommand { get; }
        string SaveButtonTitle { get; }
        string CloseButtonTitle { get; }
    }

    public interface IObservableListViewModel
    {
        string ViewId { get; }
        object ParseModel(string messageContent);
        void UpdateModel(object model);
    }

    public enum ExecuteType
    {
        View,
        Edit,
        Delete,
        New
    }
}
