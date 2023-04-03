using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS.UI.Common
{
    public class ExecutedEventArg : EventArgs
    {
        public bool IsCompleted { get; }

        public ExecutedEventArg(bool isCompleted)
        {
            IsCompleted = isCompleted;
        }
    }

    public class ObservedRelayCommand : ICommand
    {
        #region Fields

        readonly Func<Task<bool>> execute;
        readonly Func<bool> canExecute;

        #endregion

        #region Contructor

        public ObservedRelayCommand(Func<Task<bool>> execute)
            : this(execute, null)
        {
        }

        public ObservedRelayCommand(Func<Task<bool>> execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event EventHandler<ExecutedEventArg> ExecuteCompleted;

        public async void Execute(object parameter)
        {
            var result = await execute();
            OnExecuteCompleted(result);
        }

        protected virtual void OnExecuteCompleted(bool isCompleted)
        {
            ExecuteCompleted?.Invoke(this, new ExecutedEventArg(isCompleted));
        }

        #endregion

    }
}