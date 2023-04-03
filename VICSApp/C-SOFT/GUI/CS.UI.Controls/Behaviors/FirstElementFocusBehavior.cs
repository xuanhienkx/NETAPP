using System.Linq;
using MahApps.Metro.SimpleChildWindow.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TreeHelper = MahApps.Metro.Controls.TreeHelper;

namespace CS.UI.Controls.Behaviors
{
    public static class FirstElementFocusBehavior
    {
        public static readonly DependencyProperty FocusFirstProperty =
            DependencyProperty.RegisterAttached(
                "FocusFirst",
                typeof(bool),
                typeof(FirstElementFocusBehavior),
                new PropertyMetadata(false, OnFocusFirstPropertyChanged));

        public static bool GetFocusFirst(Control control)
        {
            return (bool)control.GetValue(FocusFirstProperty);
        }

        public static void SetFocusFirst(Control control, bool value)
        {
            control.SetValue(FocusFirstProperty, value);
        }

        static void OnFocusFirstPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (!(obj is Control control) || !(args.NewValue is bool))
                return;

            control.Loaded += (sender, e) =>
            {
                control.Focusable = true;
                control.Focus();

                if (!control.MoveFocus(new TraversalRequest(FocusNavigationDirection.First)))
                {
                    while (control.IsLoaded && !control.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next)))
                    {
                    }
                }

                //if (Keyboard.FocusedElement is UIElement element)
                //{
                //    if (!Equals(element.GetParentObject(), control))
                //    {
                //        var first = control.FindChildren<UIElement>().FirstOrDefault();
                //        first?.Focus();
                //    }
                //}
            };
        }
    }
}
