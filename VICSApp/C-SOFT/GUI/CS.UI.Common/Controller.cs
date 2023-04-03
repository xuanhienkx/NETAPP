using System.Threading.Tasks;
using CS.Common.Contract;
using CS.UI.Common.Interfaces;
using CS.UI.Common.ViewBase;

namespace CS.UI.Common
{
    public abstract class Controller
    {
        protected IShell Shell => ApplicationServiceLocator.Instance.Shell;

        protected void ShowMessage(string message, NotificationType type = NotificationType.Inform)
        {
            Shell.ShowMessage(new NotificationMessage
            {
                Type = type,
                Content = message
            });
        }

        protected ActionResult Path(string path)
        {
            return new PathResult(path);
        }

        protected ActionResult View<T>(string viewName, T viewModel) where T : IViewModel
        {
            return new ViewResult(viewName, viewModel);
        }

        protected ActionResult ChildView<T>(string viewName, T viewModel) where T : IViewModel
        {
            return new ChildViewResult(viewName, viewModel);
        }

        protected ActionResult Dialog<T>(string dialogName, T viewModel) where T : IDialogViewModel
        {
            return new DialogResult(dialogName, viewModel);
        }

	    protected ActionResult End()
	    {
		    return null;
	    }

        protected Result<T> Result<T>(T result = default(T))
        {
            return new Result<T>(result);
        }
    }
}
