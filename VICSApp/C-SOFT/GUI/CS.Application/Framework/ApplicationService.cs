using CS.Common.Contract;
using CS.Common.Std.Extensions;
using CS.UI.Common;
using CS.UI.Common.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CS.Application.Framework
{
    public class ApplicationService : IApplicationService
    {
        private readonly ILogger logger;
        private readonly IEnumerable<Controller> controllers;

        public ApplicationService(IEnumerable<Controller> controllers, ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.controllers = controllers ?? throw new ArgumentNullException(nameof(controllers));
        }

        public async void Invoke<T>(Expression<Func<T, ActionResult>> actionSelector)
            where T : Controller
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    if (actionSelector != null)
                    {
                        // show progressing
                        ApplicationServiceLocator.Instance.Shell.IsBusy = true;
                        ApplicationServiceLocator.Instance.Shell.Log();
                        logger.Debug("Starting invoke result...");

                        var controllerType = typeof(T);
                        if (GetController(controllerType, actionSelector.Body, out var controller, out var actionPath))
                        {
                            var actionResult = actionSelector.Compile().Invoke((T)controller);
                            if (actionResult != null)
                                PortActionResult(controller, actionResult, actionPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Try execute action result");
                    ApplicationServiceLocator.Instance.Shell.Log($"{ex}");
                    ShowNotification(NotificationType.Error, ex.Message);
                }
                finally
                {
                    // hide progressing
                    ApplicationServiceLocator.Instance.Shell.IsBusy = false;
                    logger.Debug("End invoke");
                }
            });
        }

        public async void Invoke<T>(Expression<Func<T, Task<ActionResult>>> actionSelector)
            where T : Controller
        {
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    if (actionSelector != null)
                    {
                        // show progressing
                        ApplicationServiceLocator.Instance.Shell.IsBusy = true;
                        ApplicationServiceLocator.Instance.Shell.Log();
                        logger.Debug("Starting invoke result...");

                        var controllerType = typeof(T);
                        if (GetController(controllerType, actionSelector.Body, out var controller, out var actionPath))
                        {
                            var actionResult = await actionSelector.Compile().Invoke((T)controller);
                            if (actionResult != null)
                                PortActionResult(controller, actionResult, actionPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Try execute async action result");
                    ApplicationServiceLocator.Instance.Shell.Log($"{ex}{Environment.NewLine}{ex.InnerException}");
                    ShowNotification(NotificationType.Error, ex.Message);
                }
                finally
                {
                    // hide progressing
                    ApplicationServiceLocator.Instance.Shell.IsBusy = false;
                    logger.Debug("End invoke");
                }
            });
        }

        public async Task<TResult> Invoke<T, TResult>(Func<T, Task<Result<TResult>>> actionSelector)
            where T : Controller
        {
            var result = default(TResult);
            try
            {
                ApplicationServiceLocator.Instance.Shell.IsBusy = true;
                ApplicationServiceLocator.Instance.Shell.Log();
                logger.Debug("Starting invoke result...");

                if (GetController(typeof(T), null, out var controller, out var actionPath))
                {
                    var actionResult = await actionSelector((T)controller);
                    result = actionResult.Value;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Try execute async action result");
                ApplicationServiceLocator.Instance.Shell.Log($"{ex}");
                ShowNotification(NotificationType.Error, ex.Message);
            }
            finally
            {
                // hide progressing
                ApplicationServiceLocator.Instance.Shell.IsBusy = false;
                logger.Debug("End invoke");
            }

            return result;
        }

        public void ShowNotification(NotificationType notificationType, params string[] notifications)
        {
            var message = string.Join(". ", notifications);
            ApplicationServiceLocator.Instance.Shell.ShowMessage(new NotificationMessage()
            {
                Type = notificationType,
                Content = message
            });
        }

        private void PortActionResult(Controller controller, ActionResult actionResult, string actionPath)
        {
            if (actionResult is PathResult pathResult)
            {
                logger.Debug("PathResult reached");

                var path = pathResult.Path;
                logger.Debug("Navigate to {0}...", path);
                Navigate(path);

                return;
            }

            var context = new ControllerContext(ApplicationServiceLocator.Instance.Shell)
            {
                ControllerName = controller.GetType().Name.Replace("Controller", string.Empty),
            };
            context.Path = $"{context.ControllerName}/{actionPath}";
            
            logger.Debug("Execute on controller: {0} - action result: {1}", context.ControllerName, actionResult);
            ApplicationServiceLocator.Instance.Shell.Log($"Execute on controller: {context.ControllerName} - action result: {actionResult}");

            actionResult.Execute(context, logger);
        }

        private bool GetController(Type controllerType, Expression method, out Controller controller, out string actionPath)
        {
            actionPath = "Index";
            if (method is MemberExpression memberExpression)
                actionPath = memberExpression.Member.Name;
            else if (method is MethodCallExpression methodCallExpression)
                actionPath = methodCallExpression.Method.Name;

            if (!CurrentPrincipal.Instance.IsAuthenticated && !controllerType.Name.StartsWith("HomeController") && actionPath != "Login")
            {
                var returnUrl = $"{controllerType.Name.Replace("Controller", string.Empty)}/{actionPath}";
                logger.Debug("Current user is not login. Requires to login view then redirect to path {0}", returnUrl);

                Navigate("Home", "Login", returnUrl);
                controller = null;
                return false;
            }

            controller = controllers.FirstOrDefault(x => x.GetType() == controllerType);
            if (controller == null)
            {
                logger.Debug("No controller found as type {0}. Request End", controllerType.Name);
                return false;
            }
            return true;
        }

        private void Navigate(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                Navigate("Home", "Index");
                return;
            }

            var uriParts = uri.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            switch (uriParts.Length)
            {
                case 0:
                    Navigate("Home", "Index");
                    return;
                case 1:
                    Navigate(uriParts[0], "Index");
                    return;
                default:
                    Navigate(uriParts[0], uriParts[1], uriParts.Skip(2).Take(uriParts.Length - 2).ToArray<object>());
                    return;
            }
        }

        private void Navigate(string controller, string action, params object[] arguments)
        {
            var controllerName = $"{controller}Controller";
            var selectedController = controllers.FirstOrDefault(x => x.GetType().Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase));
            if (selectedController == null)
                throw new ArgumentNullException(nameof(selectedController));

            var methodInfo = selectedController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.IsPublic && x.Name.Equals(action, StringComparison.OrdinalIgnoreCase) &&
                                     x.GetParameters().Length == arguments.Length &&
                                     (x.ReturnType == typeof(ActionResult) || x.ReturnType == typeof(Task<ActionResult>)));

            if (methodInfo == null)
                throw new MissingMethodException($"Action {action} does not find on controller {controller}");

            var paraValues = new List<object>();
            var methods = methodInfo.GetParameters();
            for (var i = 0; i < methods.Length; i++)
            {
                var value = (i >= arguments.Length)
                    ? methods[i].DefaultValue
                    : Convert.ChangeType(arguments[i], methods[i].ParameterType);
                paraValues.Add(value);
            }

            var actionResult = methodInfo.Invoke(selectedController, paraValues.ToArray());
            var args = string.Join("/", arguments);

            var context = new ControllerContext(ApplicationServiceLocator.Instance.Shell)
            {
                ControllerName = controller,
                Path = $"{controller}/{action}/{args}"
            };


            if (actionResult is Task<ActionResult> taskResult)
            {
                logger.Debug("Execute on controller: {0}, action: {1}", controller, taskResult.Result);
                taskResult.Result.Execute(context, logger);
                return;
            }

            if (actionResult is ActionResult result)
            {
                logger.Debug("Execute on controller: {0}, action: {1}", controller, result);
                result.Execute(context, logger);
                return;
            }

            throw new InvalidOperationException($"Invalid action result type: {actionResult.GetType().FullName}");
        }
    }
}
