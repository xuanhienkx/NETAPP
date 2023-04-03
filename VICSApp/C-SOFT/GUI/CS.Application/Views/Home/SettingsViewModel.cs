using System.Windows.Input;
using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.UI.Common;
using CS.UI.Common.ViewBase;

namespace CS.Application.Views.Home
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            SendMessage = new RelayCommand<string>(s => Invoke<HomeController>(c => c.SendMessage(s)));
            UpdateConfigCommand = new RelayCommand(() => Invoke<HomeController>(c => c.SaveSettings(Model)));
        }

        public string LogMessage { get => Get<string>(); set => Set(value); }
        public SettingModel Model => ApplicationSettings.Instance.Settings;
        public ICommand SendMessage { get; }
        public ICommand UpdateConfigCommand { get; }
        public override string Title { get; }
        public override string SubTitle { get; }
    }
}
