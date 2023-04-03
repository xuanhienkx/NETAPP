using System;
using System.Collections;
using System.Xml;

namespace SMS.Common.Action
{
    /// <summary>
    /// Summary description for ActionList.
    /// </summary>
    public class ActionList : AbstractAction
    {

        private readonly SortedList actions = new SortedList();
        //private string _actionName;

        /// <summary>
        /// Returns a dictionary containing actions 
        /// paired with a name
        /// </summary>
        public SortedList Actions
        {
            get { return actions; }
        }

        public override void Execute(object sender, EventArgs e)
        {
            foreach (AbstractAction a in actions.Values)
            {
                a.Execute(sender, e);
            }
        }

        /// <summary>
        /// Adds an action to the list of actions
        /// </summary>
        /// <param name="action">Action object</param>
        /// <param name="name">Name used to access the action object</param>
        public void AddAction(AbstractAction action, string name)
        {
            actions.Add(name, action);
            if (!ActionManager.IsActionAdded(name))
            {
                ActionManager.AddAction(name, action);
            }
        }

        public override void Init(string actionName, string initializedValue, XmlElement settings)
        {
            //_actionName = actionName;
            if (settings == null) return;
            var actionNodes = settings.SelectNodes("Action");
            if (actionNodes != null)
            {
                foreach (XmlElement actionElement in actionNodes)
                {
                    var name = actionElement.GetAttribute("name");
                    var className = actionElement.GetAttribute("actionClass");
                    var actionInitData = actionElement.GetAttribute("actionInitData");
                    var assemblyName = actionElement.GetAttribute("assembly");
                    if (className == "ActionList")
                        className = typeof (ActionList).FullName;
                    if (className == "ConditionalAction")
                        className = typeof(ConditionalAction).FullName;
                    AddAction(name, ActionManager.CreateAction(name, className, actionInitData, assemblyName, actionElement));
                }
            }
        }

        /// <summary>
        /// This method creates a new action with the specified
        /// class name and initializes it with the
        /// initialization string. The newly created action is
        /// added to the list of available actions
        /// </summary>
        /// <param name="name">Name of the action to create</param>
        /// <param name="a">Action to add</param>
        internal void AddAction(string name, AbstractAction a)
        {
            actions[name] = a;
        }
    }
}
