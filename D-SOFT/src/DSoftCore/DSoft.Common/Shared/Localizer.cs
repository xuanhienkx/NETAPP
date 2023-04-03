using DSoft.Common.Localize;
using DSoft.Common.Shared.Interfaces;
using Microsoft.Extensions.Localization;

namespace DSoft.Common.Shared;

public class Localizer : ILocalizer
{
    private readonly IStringLocalizer<Resource> localizer;

    public Localizer(IStringLocalizer<Resource> localizer)
    {
        this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
    }

    public string Get(string key)
    {
        return localizer[key] ?? $"{key}_{Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant()}";
    }

    public string Get(string key, params object[] arguments)
    {
        return localizer.GetString(key, arguments).Value;
    }
}
