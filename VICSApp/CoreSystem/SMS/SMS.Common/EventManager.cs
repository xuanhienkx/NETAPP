using System;
using System.Collections.Generic;
using SMS.Common.Action;
using SMS.Common.Configuration;

namespace SMS.Common
{

    /// <summary>
    /// Represents an event that can occur in the system.
    /// Typical events are state changes.
    /// </summary> 
    public class ActionCommonEvent
    {
        public event EventHandler Triggered; 
        public Func<object,Action.ActionEventArgs, string> ResultTriggered;

        public void Trigger(dynamic sender, EventArgs e)
        { 
            if (Triggered != null)
            {
                Triggered(sender, new ActionEventArgs(e, false));
            }
        }

        public string ResultTrigger(dynamic sender, EventArgs e)
        {
            if (ResultTriggered != null)
            {
                return ResultTriggered(sender,new ActionEventArgs(e, false));
            }
            return string.Empty;
        }
    } 

    /// <summary>
    /// Provides functionality for containment of events
    /// </summary>
    public class EventManager
    {
        public static string ResultTaget { get; private set; }
        public static ActionCommonEvent GetEvent(string name)
        {
            return ActionConfiguration.Current.Events.ContainsKey(name) ? ActionConfiguration.Current.Events[name] : null;
        }

        public static void Trigger(string name, IDictionary<string, object> sender, EventArgs e)
        {
            var changeEvent = GetEvent(name);
            if (changeEvent == null) return;
            changeEvent.Trigger(sender, EventArgs.Empty);
            ResultTaget = changeEvent.ResultTrigger(sender, EventArgs.Empty);
        }

        public static void Trigger(string name, IDictionary<string, object> sender)
        {
            var changeEvent = GetEvent(name);
            if (changeEvent == null) return;
            changeEvent.Trigger(sender, EventArgs.Empty);
            ResultTaget = changeEvent.ResultTrigger(sender, EventArgs.Empty);
        }

        public static void Trigger(string name)
        {
            var changeEvent = GetEvent(name);
            if (changeEvent == null) return;
            changeEvent.Trigger(null, EventArgs.Empty);
            ResultTaget = changeEvent.ResultTrigger(null, EventArgs.Empty);
        }
    }
}

