using System;
using System.Collections.Generic;
using System.Xml;

namespace SMS.Common.Action
{
    public class NotifyAction : AbstractAction
    {
        private string name = string.Empty;
        private string initString = string.Empty;

        public override void Execute(object sender, EventArgs e)
        {
            #region Sanity check
            if (sender is Dictionary<string,object>)
            {
                throw new ActionException(name + ":" + initString);
            }
            #endregion
        }

        public override void Init(string actionName, string initializedValue, XmlElement settings)
        {
            name = actionName;
            initString = initializedValue;
        }
    }
}
