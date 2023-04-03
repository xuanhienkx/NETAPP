using CS.Application.Controllers;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System.Windows.Input;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Home
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            Shell.NavigationItems?.Clear();
            
            Model = new CredentialLoginModel();
            Model.AddOnPropertyChangeListener(() => Model.Password, () => RefreshErrorMessage());
            Model.AddOnPropertyChangeListener(() => Model.Username, () => RefreshErrorMessage());

            LoginCommand = new RelayCommand(Login, () => Model != null && Model.IsValid && !Shell.IsBusy);
        }

        private void RefreshErrorMessage()
        {
            ErrorMessage = null;
        }

        public string NavigationId { get; } = null;
        public override string SubTitle => Translate("LoginView_LoginSubTitle");
        public override string Title => Translate("LoginView_LoginTitle");
        public CredentialLoginModel Model { get; set; }

        public ICommand LoginCommand { get; }
        public string ReturnUri { get; set; }

        private void Login()
        {
           Invoke<HomeController>(controller => controller.SignIn(this));
        }
    }
}
