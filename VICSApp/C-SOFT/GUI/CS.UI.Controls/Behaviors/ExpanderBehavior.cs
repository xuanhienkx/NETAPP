using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro.SimpleChildWindow.Utils;

namespace CS.UI.Controls.Behaviors
{
    public static class ExpanderBehavior
    {
        #region BindToggleButtonVisibility

        public static DependencyProperty BindToggleButtonVisibilityProperty =
            DependencyProperty.RegisterAttached("BindToggleButtonVisibility",
                typeof(bool),
                typeof(ExpanderBehavior),
                new PropertyMetadata(false, OnBindToggleButtonVisibilityChanged));

        public static bool GetBindToggleButtonVisibility(Expander expander)
        {
            return (bool)expander.GetValue(BindToggleButtonVisibilityProperty);
        }
        public static void SetBindToggleButtonVisibility(Expander expander, bool value)
        {
            expander.SetValue(BindToggleButtonVisibilityProperty, value);
        }

        #region ToggleButtonVisibilityProperty

        public static DependencyProperty ToggleButtonVisibilityProperty =
            DependencyProperty.RegisterAttached("ToggleButtonVisibility",
                typeof(Visibility),
                typeof(ExpanderBehavior),
                new PropertyMetadata(Visibility.Visible));

        public static Visibility GetToggleButtonVisibility(Expander expander)
        {
            return (Visibility)expander.GetValue(ToggleButtonVisibilityProperty);
        }
        public static void SetToggleButtonVisibility(Expander expander, Visibility value)
        {
            expander.SetValue(ToggleButtonVisibilityProperty, value);
        }

        private static void OnBindToggleButtonVisibilityChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var expander = target as Expander;
            if (expander == null)
                return;

            if (expander.IsLoaded == true)
            {
                BindToggleButtonVisibility(expander);
            }
            else
            {
                RoutedEventHandler loadedEventHandler = null;
                loadedEventHandler = new RoutedEventHandler(delegate
                {
                    BindToggleButtonVisibility(expander);
                    expander.Loaded -= loadedEventHandler;
                });
                expander.Loaded += loadedEventHandler;
            }
        }

        private static void BindToggleButtonVisibility(Expander expander)
        {
            var headerSite = expander.Template.FindName("HeaderSite", expander) as ToggleButton;
            if (headerSite == null)
                return;

            var visibilityBinding = new Binding
            {
                Source = expander,
                Path = new PropertyPath(ToggleButtonVisibilityProperty)
            };
            headerSite.SetBinding(UIElement.VisibilityProperty, visibilityBinding);
        }
        #endregion // ToggleButtonVisibilityProperty

        #endregion

        #region ToggleButton Border Margin

        public static DependencyProperty ToggleButtonBorderPaddingProperty =
            DependencyProperty.RegisterAttached("ToggleButtonBorderPadding",
                typeof(Thickness),
                typeof(ExpanderBehavior),
                new PropertyMetadata(default(Thickness), OnToggleButtonBorderPaddingChanged));

        public static Thickness GetToggleButtonBorderPadding(Expander expander)
        {
            return (Thickness)expander.GetValue(ToggleButtonBorderPaddingProperty);
        }
        public static void SetToggleButtonBorderPadding(Expander expander, Thickness value)
        {
            expander.SetValue(ToggleButtonBorderPaddingProperty, value);
        }

        private static void OnToggleButtonBorderPaddingChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var expander = target as Expander;
            RoutedEventHandler loadedEventHandler = null;
            if (expander.IsLoaded == true)
            {
                BindToggleButtonBorderMargin(expander);
            }
            else
            {
                loadedEventHandler = delegate
                {
                    BindToggleButtonBorderMargin(expander);
                    expander.Loaded -= loadedEventHandler;
                };
                expander.Loaded += loadedEventHandler;
            }
        }

        private static void BindToggleButtonBorderMargin(Expander expander)
        {
            var headerSite = expander.Template.FindName("HeaderSite", expander) as ToggleButton;
            if (headerSite != null)
            {
                var padding = GetToggleButtonBorderPadding(expander);
                var border = VisualTreeHelper.GetChild(headerSite, 0) as Border;
                border.Padding = padding;
            }
        }

        #endregion

    }
}
