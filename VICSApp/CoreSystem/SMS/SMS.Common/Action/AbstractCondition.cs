using System;
using System.Xml;

namespace SMS.Common.Action
{
    public abstract class AbstractCondition
	{
        abstract public void Init(string conditionName, string initializedValue, XmlElement settings);

        abstract public bool Validate(object sender,EventArgs e);
	}
}
