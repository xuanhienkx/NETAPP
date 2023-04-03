using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace CS.Common.Contract
{
    public abstract class ModelBase : INotifyPropertyChanged, IDisposable
    {
        #region Fields

        /// <summary>
        /// On model, it is not need to raise property changed, but in UI, we must enable this guard to 
        /// enable the property change feature 
        /// </summary>
        public bool EnablePropertyChange { get; set; }

        protected readonly Dictionary<string, Expression<Func<string>>> ExtendValidators = new Dictionary<string, Expression<Func<string>>>();
        private readonly Dictionary<string, object> values = new Dictionary<string, object>();
        private readonly Dictionary<string, Expression<Action>> changeHandlers = new Dictionary<string, Expression<Action>>();

        #endregion

        #region Protected Get/Set methods

        public void ResetPropertyChangeListener() => changeHandlers.Clear();
        public void ResetExtendedValidator() => ExtendValidators.Clear();

        public void AddOnPropertyChangeListener<TProperty>(Expression<Func<TProperty>> property, Expression<Action> onChanged)
        {
            if (!EnablePropertyChange) return;

            if (property.Body is MemberExpression memberExpression)
            {
                changeHandlers[memberExpression.Member.Name] = onChanged;
            }
        }

        public void AddOnPropertyChangeValidator<TProperty>(Expression<Func<TProperty>> property, Expression<Func<string>> onChangeValidate)
        {
            if (!EnablePropertyChange) return;

            if (property.Body is MemberExpression memberExpression)
            {
                ExtendValidators[memberExpression.Member.Name] = onChangeValidate;
            }
        }

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <param name="value">The property value.</param>
        /// <param name="alsoNotifiers"></param>
        protected bool Set<T>(T value, Expression<Func<T>> propertySelector, params Expression<Func<object>>[] alsoNotifiers)
        {
            if (propertySelector.Body is MemberExpression property)
                return Set(value, property.Member.Name, alsoNotifiers);
            return false;
        }

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The property value.</param>
        /// <param name="alsoNotifiers"></param>
        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null, params Expression<Func<object>>[] alsoNotifiers)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"Invalid property name", propertyName);

            if (values.TryGetValue(propertyName, out var refValue))
            {
                T oldValue;
                if (refValue is WeakReference weakReference)
                    oldValue = (T) weakReference.Target;
                else
                    oldValue = (T)refValue;

                if (oldValue != null && oldValue.Equals(value))
                    return false;

                if (oldValue is IDisposable disposable)
                    disposable.Dispose();
            }

            if (typeof(T).IsByRef)
                values[propertyName] = new WeakReference(value);
            else
                values[propertyName] = value;

            if (EnablePropertyChange)
            {
                NotifyPropertyChanged(propertyName);
                foreach (var alsoNotifier in alsoNotifiers)
                    NotifyPropertyChanged(alsoNotifier);
            }

            return true;
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T Get<T>(Expression<Func<T>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression property)
                return Get<T>(property.Member.Name);
            return default(T);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException(@"Invalid property name", propertyName);

            if (values.TryGetValue(propertyName, out var value))
            {
                if (value is WeakReference weakReference)
                    return (T)weakReference.Target;
                return (T)value;
            }

            return default(T);
        }

        #endregion

        #region Change Notification

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            if (propertySelector.Body is MemberExpression property)
                NotifyPropertyChanged(property.Member.Name);
            else if (propertySelector.Body is UnaryExpression unary && unary.Operand is MemberExpression operand)
                NotifyPropertyChanged(operand.Member.Name);
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
#if DEBUG
            Console.WriteLine($"------------->OnPropertyChanged: {this.GetType().Name}.{propertyName} has changed!");
#endif
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (!string.IsNullOrEmpty(propertyName)
                && changeHandlers.TryGetValue(propertyName, out var value))
            {
#if DEBUG
                Console.WriteLine($"------------->OnPropertyChanged: invoke action changed");
#endif
                value.Compile().Invoke();
            }
        }

        #endregion // INotifyPropertyChanged Members

        public void Dispose()
        {
#if DEBUG
            Console.WriteLine($"DISPOSE OBJECT: {this.GetType().Name}");
#endif

            values.Clear();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}