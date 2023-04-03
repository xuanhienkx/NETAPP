using CS.Application.Controllers;
using CS.Application.Framework;
using CS.Application.Views;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Common.Localization;
using Serilog;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CS.Common.Contract;
using CS.Common.Std;
using CS.Common.Std.Extensions;
using MainWindow = CS.Application.Views.MainWindow;
using SplashScreenWindow = CS.Application.Views.SplashScreenWindow;

namespace CS.Application
{
    internal class App : System.Windows.Application, ISingleInstanceApp
    {
        private const string Unique = "C-Soft.Application";
        private readonly Container container;
        private readonly ILogger logger;

        [STAThread]
        static void Main()
        {
            if (!SingleInstance<App>.InitializeAsFirstInstance(Unique))
                return;

            // show the splash
            Splasher.Splash = new SplashScreenWindow() {DataContext = new SplashScreenWindowViewModel()};
            Splasher.ShowSplash();

            // setup the application
            var logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();

            MessageListener.Instance.SetMessage("Starting the application...");
            logger.Debug("Starting the application...");

            var config = ConfigurationManager.AppSettings;

            // setup localization
            Bootstrapper.SetupLocalization(config);
            var assembly = Assembly.GetExecutingAssembly();
            // setup navigation configuration settings
            NavigationManager.UseConfig("CS.Application.Themes.Default.NavigationSettings.json", assembly);
            VsdMemberList.UseConfig("CS.Application.Themes.Default.VSDMemberList.json", assembly);
            VsdReportList.UseConfig("CS.Application.Themes.Default.VSDRerportStructData.json", assembly);

            // start up api provider
            var baseUrl = config["api:baseUri"].TrimEnd('/');
            var version = config["api:version"].Trim('/');
            version = string.IsNullOrEmpty(version) ? version : $"/{version}";

            ApiProvider.Initialize(
                $"{baseUrl}/api{version}/",
                long.Parse(config["api:bufferSize"]),
                double.Parse(config["api:timeoutInSecond"]),
                config["api:contentType"],
                s => LocalizationManager.Instance.Translator.Translate(s));

            // start app
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            container.RegisterSingleton<ILogger>(logger);

            // initialize all components
            Bootstrapper.InitializeComponent(container, MessageListener.Instance.SetMessage, Splasher.CloseSplash);

            try
            {
                // init the application service manager
                ApplicationServiceLocator.Init(new MainWindow(), container.Get<IShell>(), container.Get<IApplicationService>());
                ApplicationSettings.Init(logger);

                // run the application
                new App(container, logger).Run(ApplicationServiceLocator.Instance.MainWindow);
            }
            catch (Exception e)
            {
                logger.Error(e, "ApplicationRun");
            }
            finally
            {
                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }

        public App(Container container, ILogger logger)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Dispatcher.UnhandledException += DispatcherOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var applicationService = container.Get<IApplicationService>();
            applicationService.ShowNotification(NotificationType.Error, e.Exception.Message);

            logger.Error(e.Exception, "TaskSchedulerOnUnobservedTaskException");

            e.SetObserved();
        }

        private void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var applicationService = container.Get<IApplicationService>();
            applicationService.ShowNotification(NotificationType.Error, e.Exception.Message);

            logger.Error(e.Exception, "DispatcherOnUnhandledException");

            e.Handled = true;
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var applicationService = container.Get<IApplicationService>();
            applicationService.ShowNotification(NotificationType.Error, $"Unexpected exception: {e.ExceptionObject}");

            logger.Error($"CurrentDomainOnUnhandledException: {e.ExceptionObject}");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                // do the first login
                ApplicationServiceLocator.Instance.Service.Invoke<CustodyController>(controller =>
                    controller.IndexReportInfo());
            }
            catch (Exception ex)
            {
                MessageListener.Instance.SetMessage(ex.Message);
                Debug.WriteLine(ex);
            }
        }


        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            if (Current.MainWindow != null)
            {
                Current.MainWindow.WindowState = WindowState.Maximized;
                Current.MainWindow.Activate();
            }

            return true;
        }
    }
}