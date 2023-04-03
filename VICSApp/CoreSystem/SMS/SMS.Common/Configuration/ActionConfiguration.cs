using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using System.Xml;
using SMS.Common.Action;

namespace SMS.Common.Configuration
{
    public class ActionConfiguration
    {
        private static ILogger _logger;

        #region ICanLoadConfiguration Members
        private static ActionConfiguration configuration;

        private const string SectionName = "ActionConfiguration";

        #region Member variables
        private readonly Dictionary<string, AbstractAction> actions;
        private readonly Dictionary<string, ActionCommonEvent> eventListeners;

        #endregion

        #region Constructor

        public ActionConfiguration()
        { 
            _logger = new Logger();
            eventListeners = new Dictionary<string, ActionCommonEvent>();
            actions = new Dictionary<string, AbstractAction>();
        }

        #endregion

        #region Properties

        public Dictionary<string, AbstractAction> Actions
        {
            get { return actions; }
        }

        public Dictionary<string, ActionCommonEvent> Events
        {
            get { return eventListeners; }
        }

        #endregion

        #region Public

        public static ActionConfiguration Current
        {
            get { return configuration ?? (configuration = LoadConfiguration()); }
        }

        private static ActionConfiguration LoadConfiguration()
        {
            var configFileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "settings", "action.config");
            if (!File.Exists(configFileName))
            {
                configFileName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, ConfigurationManager.AppSettings["actionConfigFile"]);
            }
            if (string.IsNullOrEmpty(configFileName))
                throw new ApplicationException("configuration file not found: ActionConfiguration");

            var doc = new XmlDocument();
            doc.Load(configFileName);
            var config = new ActionConfiguration();
            config.LoadFromSection(doc.DocumentElement);
            config.fileName = new FileInfo(configFileName);

            return config;
        }

        private FileInfo fileName;

        private void LoadFromSection(XmlNode section)
        {
            var actionConfig = (XmlElement)section.SelectSingleNode("Actions");
            var eventConfig = (XmlElement)section.SelectSingleNode("EventListeners");

            if (actionConfig != null)
            {
                var actionNodes = actionConfig.SelectNodes("Action");

                if (actionNodes == null)
                {
                    throw new ActionManagerException("Configuration file does not contain any nodes named Action, at least one must exist!");
                }

                foreach (XmlElement actionElement in actionNodes)
                {
                    try
                    {
                        var name = actionElement.GetAttribute("name");
                        if (Actions.ContainsKey(name))
                        {
                            throw new ActionManagerException("Duplicate entries of action with name " + name + " is not allowed. The Action name must be unique");
                        }
                        var assemblyName = "SMS.Common";

                        if (actionElement.Attributes["assembly"] != null)
                            assemblyName = actionElement.GetAttribute("assembly");
                        var className = actionElement.GetAttribute("actionClass");
                        var actionInitData = actionElement.GetAttribute("actionInitData");
                        if (className == "ActionList")
                            className = typeof(ActionList).FullName;
                        if (className == "ConditionalAction")
                            className = ActionManager.ConditionalActionName;
                        var cs = Assembly.Load(assemblyName).GetType(className);
                        var ctor = cs.GetConstructors();
                        var ctr = ctor.FirstOrDefault();
                        var createdActivator = ExtensionMethods.GetActivator<AbstractAction>(ctr);
                        var instance = createdActivator(_logger);
                        instance.Init(name, actionInitData, actionElement);

                        Actions.Add(name, instance);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex); 
                    }
                }
            }
            if (eventConfig != null)
            {
                var eventNodes = eventConfig.SelectNodes("Listener");
                if (eventNodes == null)
                {
                    throw new ActionManagerException("There is not Listener nodes in the Action configuration, at least one is expected!");
                }

                foreach (XmlElement eventElement in eventNodes)
                {
                    var eventName = eventElement.GetAttribute("event");
                    if (eventListeners.ContainsKey(eventName))
                    {
                        throw new ActionManagerException("Duplicate entries of action with Event Listener: " + eventName + " is not allowed. The EventListners name must be unique");
                    }
                    var actionName = eventElement.GetAttribute("action");
                    if (!Actions.ContainsKey(actionName))
                    {
                        throw new ActionManagerException("Event Listener: " + eventName + " is configured to trigger a NON existing action " + actionName);
                    }
                    var evnt = new ActionCommonEvent();
                    var action = Actions[actionName];
                    evnt.Triggered += action.Execute;
                    evnt.ResultTriggered += action.ExecuteResult;
                    eventListeners.Add(eventName, evnt);

                }
            }
        }

        #endregion

        #endregion
    }

    public class EventListenerConfiguration : ICanLoadConfiguration
    {
        private string name;
        private string errorMessage;
        private string expression;
        private string helpText;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public string HelpText
        {
            get { return helpText; }
            set { helpText = value; }
        }

        public void LoadConfiguration(XmlNode section)
        {
            if (section.Attributes != null)
            {
                if (section.Attributes["name"] == null) return;
                name = section.Attributes["name"].Value;
                if (section.Attributes["expression"] == null) return;
                expression = section.Attributes["expression"].Value;

                if (section.Attributes["helpText"] != null)
                    helpText = section.Attributes["helpText"].Value;

                if (section.Attributes["errorMessage"] != null)
                    errorMessage = section.Attributes["errorMessage"].Value;
            }

        }
    }

}
