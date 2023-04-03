using Microsoft.AspNetCore.Identity;

namespace DSoft.Common.Shared.Base;

public static class ErrorMessage
{
    public static IList<string> Detail(this Exception exception)
    {
        var result = new List<string>();
        var tmpEx = exception;
        do
        {
            result.Add($"{tmpEx.Message}: {tmpEx.StackTrace}");
            tmpEx = exception.InnerException;
        }
        while (tmpEx != null);

        return result;
    }

    public static string[] ToStringArray(this IEnumerable<IdentityError> errors)
    {
        return errors.Select(e => $"{e.Code} : {e.Description}").ToArray();
    }
}
