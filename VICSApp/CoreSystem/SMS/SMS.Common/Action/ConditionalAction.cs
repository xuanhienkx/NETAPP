using System;
using System.Xml;

namespace SMS.Common.Action
{
    public class ConditionalAction : AbstractAction
    {
        private AbstractAction action;
        private AbstractAction antiAction;
        private AbstractCondition condition;

        public override void Execute(object sender, EventArgs e)
        {
            if (condition != null)
            {
                if (condition.Validate(sender, e))
                {
                    if (action != null)
                    {
                        action.Execute(sender, e);
                    }
                }
                else if (antiAction != null)
                {
                    antiAction.Execute(sender, e);
                }
            }
        }

        public override void Init(string actionName, string initializedValue, XmlElement settings)
        {
            if (settings != null)
            {
                var actionElement = (XmlElement)settings.SelectSingleNode("Action");
                var antiActionElement = (XmlElement)settings.SelectSingleNode("AntiAction");
                var conditionElement = (XmlElement)settings.SelectSingleNode("Condition");

                if (actionElement != null)
                {
                    var name = actionElement.GetAttribute("name");
                    var className = actionElement.GetAttribute("actionClass");
                    var initData = actionElement.GetAttribute("actionInitData");
                    var assemblyName = actionElement.GetAttribute("assembly");
                    if (className == "ConditionList")
                        className = ActionManager.ListConditionName;
                    if (className == "StandardCondition")
                        className = ActionManager.StandardConditionName;
                    if (className == "ActionList")
                        className = ActionManager.ListActionName;
                    if (className == "ConditionalAction")
                        className = ActionManager.ConditionalActionName;
                    action = ActionManager.CreateAction(name, className, initData, assemblyName, actionElement);

                    if (antiActionElement != null)
                    {
                        name = antiActionElement.GetAttribute("name");
                        className = antiActionElement.GetAttribute("actionClass");
                        initData = antiActionElement.GetAttribute("actionInitData");
                        assemblyName = antiActionElement.GetAttribute("assembly");
                        if (className == "ConditionList")
                            className = ActionManager.ListConditionName;
                        if (className == "StandardCondition")
                            className = ActionManager.StandardConditionName;
                        if (className == "ActionList")
                            className = ActionManager.ListActionName;
                        if (className == "ConditionalAction")
                            className = ActionManager.ConditionalActionName;
                        antiAction = ActionManager.CreateAction(name, className, initData, assemblyName, actionElement);
                    }

                    if (conditionElement != null)
                    {
                        name = conditionElement.GetAttribute("name");
                        className = conditionElement.GetAttribute("conditionClass");
                        initData = conditionElement.GetAttribute("conditionInitData");
                        assemblyName = conditionElement.GetAttribute("assembly");
                        if (className == "ConditionList")
                            className = ActionManager.ListConditionName;
                        if (className == "StandardCondition")
                            className = ActionManager.StandardConditionName;
                        if (className == "ActionList")
                            className = ActionManager.ListActionName;
                        if (className == "ConditionalAction")
                            className = ActionManager.ConditionalActionName;
                        condition = ActionManager.CreateCondition(name, className, initData, assemblyName, conditionElement);
                    }
                }
            }
        }
    }
}
