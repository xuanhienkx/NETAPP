using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace CS.UI.Controls.Behaviors
{
    public class CurrentTimeBehavior : Behavior<ContentControl>
    {
        private DispatcherTimer dispatcherTimer;

        protected override void OnAttached()
        {
            base.OnAttached();
            dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.DataBind,
                (sender, args) => AssociatedObject.Content = DateTime.Now.ToString(AssociatedObject.ContentStringFormat), Dispatcher.CurrentDispatcher);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            dispatcherTimer.Stop();
        }
    }
}
