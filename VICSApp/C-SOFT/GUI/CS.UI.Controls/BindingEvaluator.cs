using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CS.UI.Controls
{
    public class BindingEvaluator : FrameworkElement
    {

        #region "Fields"


        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(BindingEvaluator), new FrameworkPropertyMetadata(string.Empty));

        #endregion

        #region "Constructors"

        public BindingEvaluator(Binding binding)
        {
            ValueBinding = binding;
        }

        #endregion

        #region "Properties"

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public Binding ValueBinding { get; set; }

        #endregion

        #region "Methods"

        public string Evaluate(object dataItem)
        {
            this.DataContext = dataItem;
            SetBinding(ValueProperty, ValueBinding);
            return Value;
        }

        #endregion

    }
}
