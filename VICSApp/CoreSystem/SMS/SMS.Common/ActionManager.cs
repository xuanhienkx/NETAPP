using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using SMS.Common.Action;
using SMS.Common.Configuration;

namespace SMS.Common
{
    [Serializable]
    public class ActionManagerException : Exception
    {
        public ActionManagerException() { }
        public ActionManagerException(string msg, Exception innerException) : base(msg, innerException) { }
        public ActionManagerException(string msg) : base(msg) { }
        protected ActionManagerException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// This class manages actions. All actions are to be
    /// registered with this class.
    /// </summary>
    public class ActionManager
    {
        public const string ListActionName = "SMS.Common.Action.ActionList";
        public const string ConditionalActionName = "SMS.Common.Action.ConditionalAction";
        public const string ListConditionName = "SMS.Common.Action.ConditionList";
        public const string StandardConditionName = "SMS.Common.Action.StandardCondition";

        /// <summary>
        /// Removes all registered actions
        /// </summary>
        public static void Clear()
        {
             ActionConfiguration.Current.Actions.Clear();
        }

        /// <summary>
        /// Returns an action with a given name
        /// </summary>
        /// <param name="name">Name of action to return</param>
        /// <returns>Action object</returns>
        public static AbstractAction GetAction(string name)
        {
            return ActionConfiguration.Current.Actions[name];
        }

        public static AbstractAction CreateAction(string name, string className, string initializedValue, string assemblyName, XmlElement settings)
        {
            if (string.IsNullOrEmpty(assemblyName))
                assemblyName = "Mbq.Common";
            AbstractAction action = null;
            if (className == ListActionName)
            {
                action = new ActionList();
            }
            else if (className == ConditionalActionName)
            {
                action = new ConditionalAction();
            }
            if (action == null)
            {
                var ctor = Assembly.Load(assemblyName).GetType(className).GetConstructors().First();
                var createdActivator = ExtensionMethods.GetActivator<AbstractAction>(ctor);
                action = createdActivator();
            }
            action.Init(name, initializedValue, settings);
            return action;
        }

        internal static void AddAction(string name, AbstractAction item)
        {
            ActionConfiguration.Current.Actions.Add(name, item);
        }

        internal static bool IsActionAdded(string name)
        {
            return ActionConfiguration.Current.Actions.ContainsKey(name);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode")]
        public static AbstractCondition CreateCondition(string name, string className, string initializedValue, string assemblyName, XmlElement settings)
        {
            AbstractCondition abstractCondition;
            switch (className)
            {
                case ListConditionName:
                    abstractCondition = new ConditionList();
                    break;
                case StandardConditionName:
                    abstractCondition = new StandardCondition();
                    break;
                default:
                    if (!string.IsNullOrEmpty(assemblyName))
                    {
                        var ctor = Assembly.Load(assemblyName).GetType(className).GetConstructors().First();
                        var createdActivator = ExtensionMethods.GetActivator<AbstractCondition>(ctor);
                        abstractCondition = createdActivator();
                    }
                    else
                    {
                        var ctor = Assembly.Load("Mbq.Common").GetType(className).GetConstructors().First();
                        var createdActivator = ExtensionMethods.GetActivator<AbstractCondition>(ctor);
                        abstractCondition = createdActivator();
                    }
                    break;
            }
            if (abstractCondition != null)
            {
                abstractCondition.Init(name, initializedValue, settings);
                return abstractCondition;
            }
            return null;
        }
    }
}
