using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace CS.UI.Common.Localization
{
    public class LocalizationManager
    {
        LocalizationManager()
        {
        }

        private static LocalizationManager translationManager;

        public event EventHandler LanguageChanged;

        public CultureInfo CurrentLanguage
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set
            {
                if (Equals(value, Thread.CurrentThread.CurrentUICulture))
                    return;

                Thread.CurrentThread.CurrentUICulture =
                    Thread.CurrentThread.CurrentCulture = value;
                OnLanguageChanged();
            }
        }

        public IEnumerable<CultureInfo> Languages
        {
            get
            {
                if (Translator != null)
                {
                    return Translator.Languages;
                }
                return Enumerable.Empty<CultureInfo>();
            }
        }

        public static LocalizationManager Instance => translationManager ?? (translationManager = new LocalizationManager());

        public ITranslator Translator { get; set; }

        private void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        public string Translate(string key)
        {
            var translatedValue = Translator?.Translate(key);
            return translatedValue ?? $"[{key}]";
        }
    }
}
