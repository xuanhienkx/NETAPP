using System;
using System.ComponentModel;
using System.Windows;

namespace CS.UI.Common.Localization
{
    public class TranslationData : IWeakEventListener, INotifyPropertyChanged
    {
        #region Private Members

        private readonly string key;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationData"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public TranslationData( string key)
        {
            this.key = key;
            LanguageChangedEventManager.AddListener(LocalizationManager.Instance, this);
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="TranslationData"/> is reclaimed by garbage collection.
        /// </summary>
        ~TranslationData()
        {
            LanguageChangedEventManager.RemoveListener(LocalizationManager.Instance, this);
        }

        public object Value => LocalizationManager.Instance.Translate(key);

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(LanguageChangedEventManager))
            {
                OnLanguageChanged(sender, e);
                return true;
            }
            return false;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs("Value"));
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
