using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CS.UI.Common.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public class ResxTranslationProvider : ITranslator
    {
        #region Private Members

        private readonly System.Resources.ResourceManager resourceManager;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ResxTranslationProvider"/> class.
        /// </summary>
        /// <param name="baseName">Name of the base.</param>
        /// <param name="assembly">The assembly.</param>
        public ResxTranslationProvider(string baseName, Assembly assembly)
        {
            resourceManager = new System.Resources.ResourceManager(baseName, assembly);
        }

        #endregion

        #region ITranslationProvider Members

        /// <summary>
        /// See <see cref="ITranslator.Translate" />
        /// </summary>
        public string Translate(string key)
        {
            var translated = resourceManager.GetString(key);
            return string.IsNullOrEmpty(translated) ? $"[{key}]" : translated;
        }

        #endregion

        #region ITranslationProvider Members

        /// <summary>
        /// See <see cref="ITranslator.AvailableLanguages" />
        /// </summary>
        public IEnumerable<CultureInfo> Languages
        {
            get
            {
                // TODO: Resolve the available languages
                yield return new CultureInfo("en"); // default
                yield return new CultureInfo("vi");
            }
        }

        #endregion
    }
}
