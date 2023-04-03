using api.common.Shared.Interfaces;
using api.resources.Localize;
using Microsoft.Extensions.Localization;
using System;
using System.Threading;

namespace api.resources.Services
{
    public class Localizer : ILocalizer
    {
        private readonly IStringLocalizer<Resource> localizer;

        public Localizer(IStringLocalizer<Resource> localizer)
        {
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        public string Get(string key)
        {
            return localizer[key]?? $"{key}_{Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant()}";
        }

        public string Get(string key, params object[] arguments)
        {
            return localizer.GetString(key, arguments).Value;
        }
    }
}
