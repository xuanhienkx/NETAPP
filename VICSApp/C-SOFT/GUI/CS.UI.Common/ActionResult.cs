using CS.UI.Common.Interfaces;

namespace CS.UI.Common
{
    public enum ResultType
    {
        Result,
        Dialog,
        View,
        ChildView
    }

    /// <summary>
    /// Represents the typical result of invoking an action on a controller.
    /// </summary>
    public abstract class ActionResult
    {
        public string DialogName { get; }
        public IViewModel ViewModel { get; }
        public ResultType Type { get; }

        protected ActionResult(string dialogName, IViewModel viewModel, ResultType type)
        {
            DialogName = dialogName;
            ViewModel = viewModel;
            Type = type;
        }
    }

    public class Result<T> : ActionResult
    {
        public Result(T value = default(T))
            : base(null, null, ResultType.Result)
        {
            Value = value;
        }

        public T Value { get; set; }
    }

    public class PathResult : ActionResult
    {
        public string Path { get; }

        public PathResult(string path)
            : base(null, null, ResultType.View)
        {
            Path = path;
        }
    }

    public class DialogResult : ActionResult
    {
        public DialogResult(string dialogName, IDialogViewModel viewModel)
            : base(dialogName, viewModel, ResultType.Dialog)
        {
        }
    }

    public class ViewResult : ActionResult
    {
        public ViewResult(string viewName, IViewModel viewModel)
            : base(viewName, viewModel, ResultType.View)
        {
        }
    }

    public class ChildViewResult : ActionResult
    {
        public ChildViewResult(string viewName, IViewModel viewModel)
            : base(viewName, viewModel, ResultType.ChildView)
        {
        }
    }
}
