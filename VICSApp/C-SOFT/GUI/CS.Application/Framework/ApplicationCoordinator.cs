using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using CS.UI.Controls;
using CS.UI.Controls.Behaviors;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.SimpleChildWindow;
using Serilog;

namespace CS.Application.Framework
{
    public static class ApplicationCoordinator
    {
        public static bool ViewAsChild { get; set; }

        public static void Execute(this ActionResult actionResult, ControllerContext context, ILogger logger)
        {
            ApplicationServiceLocator.Instance.RunOnUiThread(async () =>
            {
                // load the current view and model
                var viewSource = GetViewSource(context.ControllerName, actionResult.DialogName,
                    actionResult.ViewModel.GetType());
                logger.Debug("View source: {0}", viewSource);

                var elementView = LoadView(viewSource, logger);
                elementView.DataContext = actionResult.ViewModel;

                // replace the region content
                await UpdateView(actionResult.Type, actionResult.ViewModel, elementView, context);
                logger.Debug("Bind content {0} to view {1}", actionResult.ViewModel, actionResult.Type);
            });
        }

        private static FrameworkElement LoadView(string viewSource, ILogger logger)
        {
            try
            {
                return (FrameworkElement)System.Windows.Application.LoadComponent(new Uri(viewSource, UriKind.RelativeOrAbsolute));
            }
            catch (Exception e)
            {
                logger.Error(e, "ApplicationCoordinator.Execute");

                var message = e.Message;
                while (e.InnerException != null)
                {
                    message += Environment.NewLine + e.InnerException.Message;
                    e = e.InnerException;
                }
                return new TextBlock { Text = message };
            }
        }

        private static async Task UpdateView(ResultType viewType, IViewModel viewModel, FrameworkElement elementView, ControllerContext context)
        {
            try
            {
                context.Shell.IsShowNavigationMenu = false;
                context.Shell.Log($"View: { context.Shell.ElementView.Uid}");
                viewModel.OnBinding();

                switch (viewType)
                {
                    case ResultType.ChildView:
                    case ResultType.View:
                        SetElementView(viewModel, elementView, context, ViewAsChild || viewType.Equals(ResultType.ChildView));
                        break;
                    case ResultType.Dialog:
                        await SetElementViewDialog(viewModel as IDialogViewModel, elementView, context);
                        break;
                }
            }
            finally
            {
                context.Shell.IsEnabledNavigationMenu = true;
                DispatcherHelper.SetProcessWorkingSize();
            }
        }

        private static async Task SetElementViewDialog(IDialogViewModel dialogViewModel, FrameworkElement elementView, ControllerContext context)
        {
            if (dialogViewModel == null)
                return;

            var dialog = new CommandDialog
            {
                Title = dialogViewModel.Title,
                AcceptTitle = dialogViewModel.SaveButtonTitle,
                CloseTitle = dialogViewModel.CloseButtonTitle,
                AcceptCommand = dialogViewModel.SaveCommand,
                ShowSaveButton = dialogViewModel.ViewType != ExecuteType.View,
                ShowCloseButton = true,
                IsModal = false,
                Content = elementView,
                DataContext = dialogViewModel
            };

            var binding = new Binding("IsDialogOpened") {Source = context.Shell};
            dialog.SetBinding(ChildWindow.IsOpenProperty, binding);
            
            await ApplicationServiceLocator.Instance.MainWindow.ShowChildWindowAsync(dialog);

            BindingOperations.ClearBinding(dialog, ChildWindow.IsOpenProperty);
        }

        private static void SetElementView(IViewModel viewModel, FrameworkElement elementView, ControllerContext context, bool isChildView)
        {
            if (elementView is Control control)
                FirstElementFocusBehavior.SetFocusFirst(control, true);

            viewModel.IsRootView = !isChildView;

            var navigationItems = new List<NavigationItem>();
            if (isChildView)
            {
                foreach (var item in context.Shell.NavigationItems)
                {
                    if (string.IsNullOrEmpty(item.Path))
                        continue;

                    if (item.Path.Equals(context.Path))
                        break;

                    item.IsSelected = false;
                    navigationItems.Add(item);
                }
            }

            navigationItems.Add(new NavigationItem
            {
                Title = viewModel.Title,
                Description = viewModel.SubTitle,
                Path = context.Path,
                IsSelected = true
            });

            context.Shell.ElementView = elementView;
            context.Shell.CurrentPath = context.Path.ToLowerInvariant();
            context.Shell.NavigationItems = navigationItems;
            context.Shell.Description = viewModel.SubTitle;

            NavigationManager.Instance.FindSelected(context.Path);
            DialogParticipation.SetRegister(elementView, context.Shell);
        }

        private static string GetViewSource(string controller, string viewName, Type type)
        {
            return $"/{type.Assembly.GetName().Name};component/Views/{controller}/{viewName}View.xaml";
        }
    }
}
