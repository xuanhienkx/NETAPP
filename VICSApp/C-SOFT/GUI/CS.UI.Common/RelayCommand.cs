using System;
using System.Management;
using System.Windows.Input;

namespace CS.UI.Common
{
    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action execute;
        readonly Func<bool> canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
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

        public void Execute(object parameter)
        {
            execute();
        }

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Fields

        readonly Action<T> execute;
        readonly Predicate<T> canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Members

        public bool CanExecute(T parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
                return true;

            if (parameter == null && typeof(T).IsValueType)
                return this.canExecute.Invoke(default(T));
            if (parameter == null || parameter is T)
                return this.canExecute.Invoke((T)parameter);

            return false;
        }

        public void Execute(object parameter)
        {
            object parameter1 = parameter;
            if (parameter != null && parameter.GetType() != typeof(T) && parameter is IConvertible)
                parameter1 = Convert.ChangeType(parameter, typeof(T), null);
          
            if (!this.CanExecute(parameter1) || this.execute == null)
                return;

            if (parameter1 == null && typeof(T).IsValueType)
                this.execute.Invoke(default(T));
            else if (parameter1 is T)
                this.execute.Invoke((T)parameter1);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(T parameter)
        {
            execute(parameter);
        }

        #endregion
    }
}
