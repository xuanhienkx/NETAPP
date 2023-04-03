using CS.UI.Common;
using CS.UI.Common.Localization;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.ComponentModel;
using System.Windows;
using CS.Common.Std;

namespace CS.Application.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool shutdown;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (e.Cancel || shutdown) return;
            e.Cancel = !shutdown;

            var dictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/CS.UI.Controls;component/Themes/Dialogs.xaml")
            };
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = LocalizationManager.Instance.Translate("Command_Quit"),
                NegativeButtonText = LocalizationManager.Instance.Translate("LoginView_Cancel"),
                AnimateShow = true,
                AnimateHide = false,
                SuppressDefaultResources = true,
                CustomResourceDictionary = dictionary
            };

            var result = await this.ShowMessageAsync(
                LocalizationManager.Instance.Translate("Application_QuitTitle"),
                LocalizationManager.Instance.Translate("Application_QuitMessage"),
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            shutdown = result == MessageDialogResult.Affirmative;

            if (shutdown)
            {
                if (CurrentPrincipal.Instance.IsAuthenticated)
                    await ApiProvider.Instance.GetAsync(api => api.GetAsync<bool>("security/logout"), null);
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
