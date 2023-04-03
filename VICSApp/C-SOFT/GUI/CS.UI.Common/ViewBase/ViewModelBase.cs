using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CS.Common.Contract;
using CS.UI.Common.Interfaces;

namespace CS.UI.Common.ViewBase
{
    public abstract class ViewModelBase : ValidableModel, IViewModel
    {
        protected ViewModelBase()
        {
            BackCommand = new RelayCommand(BackExecute);
            EnablePropertyChange = true;
            AddOnPropertyChangeListener(() => ErrorMessage, () => NotifyPropertyChanged(nameof(HasError)));
        }

        public ICommand BackCommand { get; }
        public string ErrorMessage
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public IShell Shell => ApplicationServiceLocator.Instance.Shell;

        protected void ShowMessage(string message, NotificationType type = NotificationType.Inform)
        {
            if (type == NotificationType.Error)
                ErrorMessage = message;

            Shell.ShowMessage(new NotificationMessage
            {
                Type = type,
                Content = message
            });
        }

        protected string Translate(string key)
            => UI.Common.Localization.LocalizationManager.Instance.Translate(key);

        public virtual string ParentNavigationId { get; set; }

        protected void Invoke<T>(Expression<Func<T, ActionResult>> actionSelector = null) 
            where T : Controller
        {
            try
            {
                ApplicationServiceLocator.Instance.Service.Invoke(actionSelector);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected void Invoke<T>(Expression<Func<T, Task<ActionResult>>> actionSelector = null) 
            where T : Controller
        {
            try
            {
                ApplicationServiceLocator.Instance.Service.Invoke(actionSelector);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected Task<TResult> Invoke<T, TResult>(Func<T, Task<Result<TResult>>> actionSelector = null)
            where T : Controller
        {
            try
            {
                return ApplicationServiceLocator.Instance.Service.Invoke(actionSelector);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Task.FromException<TResult>(ex);
            }
        }

        public bool IsRootView { get; set; }
        public abstract string Title { get; }
        public abstract string SubTitle { get; }

        public virtual void OnBinding()
        {
            // do nothing
        }

        private void BackExecute()
        {
            var lastNav = Shell.NavigationItems.LastOrDefault(x => x.IsSelected == false);
            Shell.Navigate(lastNav);
        }
    }
}
