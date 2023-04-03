using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using CS.UI.Common.Converters;

namespace CS.UI.Common.Localization
{
    /// <summary>
    /// The Translate Markup extension returns a binding to a TranslationData
    /// that provides a translated resource of the specified key
    /// </summary>
    public class TranslateExtension : MarkupExtension
    {
        #region Private Members

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslateExtension"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public TranslateExtension(string key)
        {
            this.Key = key;
            CharacterCasing = CharacterCasing.Normal;
        }

        #endregion

        [ConstructorArgument("key")]
        public string Key { get; set; }
        [ConstructorArgument("characterCasing")]
        public CharacterCasing CharacterCasing { get; set; }

        /// <summary>
        /// See <see cref="MarkupExtension.ProvideValue" />
        /// </summary>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding("Value")
            {
                Source = new TranslationData(Key),
                Converter = new CharacterCasingConverter(),
                ConverterParameter = CharacterCasing
            };
            return binding.ProvideValue(serviceProvider);
        }
    }

    public class TranslatePatternExtension : MarkupExtension
    {
        [ConstructorArgument("key")]
        public string Key { get; set; }
        [ConstructorArgument("stringFormat")]
        public string StringFormat{ get; set; }
        [ConstructorArgument("binding")]
        public Binding Binding { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var multipalBinding = new MultiBinding()
            {
                Bindings =
                {
                    new Binding("Value")
                    {
                        Source = new TranslationData(Key)
                    },
                    Binding
                },
                StringFormat = StringFormat
            };
            return multipalBinding.ProvideValue(serviceProvider);
        }
    }
}
