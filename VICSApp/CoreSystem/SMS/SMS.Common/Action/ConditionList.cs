using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SMS.Common.Action
{
    public class ConditionList : AbstractCondition {

        private readonly Dictionary<string, AbstractCondition> conditions = new Dictionary<string, AbstractCondition>();

		/// <summary>
		/// Returns a dictionary containing Conditions 
		/// paired with a name
		/// </summary>
        public Dictionary<string, AbstractCondition> Conditions
        {
			get { return conditions; }
		}

		public override bool Validate(object sender, EventArgs e)
		{
		    return conditions.Values.All(a => a.Validate(sender, e));
		}

        public void AddCondition( AbstractCondition condition, string name ) {
			conditions.Add( name, condition ); 
		}

		public void RemoveCondition( string name ) {
			conditions.Remove( name );
		}

		public override void  Init(string conditionName, string initializedValue, XmlElement settings) {
			if ( settings  != null)
			{
			    var conditionNodes = settings.SelectNodes("Condition");
                if (conditionNodes != null)
                {
                    foreach (XmlElement conditionElement in conditionNodes)
                    {
                        var name = conditionElement.GetAttribute("name");
                        var className = conditionElement.GetAttribute("conditionClass");
                        var conditionInitData = conditionElement.GetAttribute("conditionInitData");
                        var assemblyName = conditionElement.GetAttribute("assembly");
                        if (className == "StandardCondition")
                            className = ActionManager.StandardConditionName;

                        AddCondition(name, ActionManager.CreateCondition(name, className, conditionInitData, assemblyName, conditionElement));
                    }
                }
			}
		}

		public void Clear() {
			conditions.Clear();
		}

		public AbstractCondition GetCondition(string name) {

            if (!conditions.ContainsKey(name))
                throw new ActionManagerException("Could not find Condition: " + name);

		    return conditions[name];
		}

		internal void AddCondition(string name, AbstractCondition a) {
			conditions[name] = a;
		}
	}
}
