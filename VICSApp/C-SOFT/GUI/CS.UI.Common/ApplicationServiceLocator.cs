using CS.UI.Common.Interfaces;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace CS.UI.Common
{
    public class ApplicationServiceLocator
    {
        public Window MainWindow { get; }
        public IShell Shell { get; }
        public IApplicationService Service { get; }

        ApplicationServiceLocator(Window mainWindow, IShell shell, IApplicationService applicationService)
        {
            MainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
            Service = applicationService ?? throw new ArgumentNullException(nameof(applicationService));

            MainWindow.DataContext = Shell;
        }

        public static ApplicationServiceLocator Instance { get; private set; }

        public static void Init(Window mainWindow, IShell shell, IApplicationService applicationService)
        {
           Instance = new ApplicationServiceLocator(mainWindow, shell, applicationService);
        }

        public void RunOnUiThread(Action act, int waitInMiliseconds = 0)
        {
            var thread = new Thread(
                delegate ()
                {
                    MainWindow.Dispatcher.Invoke(DispatcherPriority.Background, act);
                });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            if (waitInMiliseconds > 0)
                thread.Join(TimeSpan.FromMilliseconds(waitInMiliseconds));
        }
    }
}
