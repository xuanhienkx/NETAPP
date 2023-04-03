using CS.Application.Controllers;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Admin
{
    internal class AdminViewModel : ViewModelBase
    {
        private const string AdminNavigationKey = "adminsetting";

        public AdminViewModel()
        {
            Shell.NavigationItems?.Clear();
            
            var adminSetting = NavigationManager.Instance.Items.FirstOrDefault(x => x.Id.Equals(AdminNavigationKey));
            Commands = adminSetting?.SubItems ?? new List<NavigationItem>();

            AdminCommandClicked = new RelayCommand<NavigationItem>(item => Invoke<HomeController>(c => c.Navigate(item)));
        }

        public override string Title => Translate("Admin_Title");
        public override string SubTitle => Translate("Admin_SubTitle");
        public ICommand AdminCommandClicked { get; }
        public IList<NavigationItem> Commands { get; }
    }
}