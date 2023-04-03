using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Application.Services.Interfaces;
using CS.Application.Views;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using CS.UI.Common.Service;
using CS.UI.Common.Service.Interface;
using MahApps.Metro.Controls.Dialogs;
using SimpleInjector;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;
using CS.Common.Contract;

namespace CS.Application
{
    internal static class Bootstrapper
    {
        /// <summary>
        /// The method to register all components to IoC container
        /// </summary>
        /// <param name="container"></param>
        /// <param name="notify"></param>
        /// <param name="finished"></param>
        internal static void InitializeComponent(Container container, Action<string> notify, Action finished)
        {
            notify?.Invoke(LocalizationManager.Instance.Translate("Start_RegisterComponent"));
            container.RegisterSingleton(() => LocalizationManager.Instance.Translator);

			container.RegisterSingleton<IDialogCoordinator, DialogCoordinator>();
            container.RegisterSingleton<IDialogService, DialogService>();
            container.RegisterSingleton<IShell, MainWindowViewModel>();
            container.RegisterSingleton<IApplicationService, ApplicationService>();
            container.RegisterSingleton<IServiceProvider>(() => new ServicelocatorProvider(container.GetInstance));
            container.RegisterSingleton<INotificator, MessageNotificator>();
            
            container.RegisterSingleton<ISecurityService, SecurityService>();
            container.RegisterSingleton<IDataProvider, DataProvider>();
            container.Register<ICustodyBusinessHandler, CustodyBusinessHandler>();

            container.RegisterCollection<Controller>(new[] { typeof(HomeController).Assembly });

            container.Verify(VerificationOption.VerifyAndDiagnose);

            notify?.Invoke(LocalizationManager.Instance.Translate("End_RegisterComponent"));

            Thread.Sleep(200);
            finished?.Invoke();
        }

        public static void SetupLocalization(NameValueCollection config)
        {
            // start localize manager
            var defaultLanguage = config["defaultLang"];
            LocalizationManager.Instance.CurrentLanguage = string.IsNullOrEmpty(defaultLanguage)
                ? CultureInfo.CurrentUICulture
                : CultureInfo.GetCultureInfo(defaultLanguage);

            // setup data contract localization resource
            var resourceAssembly = typeof(LocalizationManager).Assembly;
            LocalizationManager.Instance.Translator = new ResxTranslationProvider("CS.UI.Common.Resources.LocalizedText", resourceAssembly);
            DataContractResourceManager.Current.UseResource("CS.UI.Common.Resources.DataContractResources", resourceAssembly);
        }
    }
}
