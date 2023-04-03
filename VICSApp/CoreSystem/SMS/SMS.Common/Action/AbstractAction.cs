using System;
using System.Threading.Tasks;
using System.Xml;

namespace SMS.Common.Action
{
    /// <summary>
    /// Represents a simple action that can be triggered
    /// from other systems. Is mostly used by the state machine
    /// mechanism
    /// </summary>
    public abstract class AbstractAction
    {
        /// <summary>
        /// Executes the action. Override this to perform
        /// the custom action
        /// </summary>
        abstract public void Execute(object sender, EventArgs e);

        /// <summary>
        /// Initializes the action object. Override to
        /// provide initialization.
        /// </summary>
        abstract public void Init(string actionName, string initializedValue, XmlElement settings);



        public virtual string ExecuteResult(object sender, EventArgs arg)
        {
           return null;
        }
    } 
   
}
