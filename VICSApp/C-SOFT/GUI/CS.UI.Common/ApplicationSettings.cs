using CS.Common.Contract.Models;
using Serilog;
using System;
using System.Configuration;
using System.Linq;

namespace CS.UI.Common
{
    public class ApplicationSettings
    {
        private readonly ILogger logger;
        public static ApplicationSettings Instance { get; private set; }
        public static void Init(ILogger logger)
        {
            Instance = new ApplicationSettings(logger);
        }

        ApplicationSettings(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private SettingModel settings;
        public SettingModel Settings => settings ?? (settings = Load());

        private static SettingModel Load()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var settingModel = new SettingModel
            {
                Api = new ApiConfig()
                {
                    BaseUri = appSettings["api:baseUri"],
                    Version = appSettings["api:version"],
                    BufferSize = appSettings["api:bufferSize"],
                    TimeoutInSecond = appSettings["api:timeoutInSecond"],
                    ContentType = appSettings["api:contentType"],
                },
                CsvTempDirectory = appSettings["csvTempDirectory"],
                PageSize = int.TryParse(appSettings["list:pageSize"], out var pageSize) ? pageSize : 50
            };

            return settingModel;
        }

        public bool Update(SettingModel model)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                //Set api config
                SetOrAdd(appSettings, "api:baseUri", model.Api.BaseUri);
                SetOrAdd(appSettings, "api:version", model.Api.Version);
                SetOrAdd(appSettings, "api:bufferSize", model.Api.BufferSize);
                SetOrAdd(appSettings, "api:timeoutInSecond", model.Api.TimeoutInSecond);
                SetOrAdd(appSettings, "api:contentType", model.Api.ContentType);

                //set other config
                SetOrAdd(appSettings, "csvTempDirectory", model.CsvTempDirectory);
                SetOrAdd(appSettings, "list:pageSize", model.PageSize.ToString());

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                settings = model;
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Update settingconfig error:");
                return false;
            }
        }

        private static void SetOrAdd(KeyValueConfigurationCollection settings, string key, string value)
        {
            if (!settings.AllKeys.Contains(key))
                settings.Add(key, value);
            else
                settings[key].Value = value;
        }
    }
}