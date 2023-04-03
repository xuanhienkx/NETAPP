using DSoft.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Security.Claims;

namespace DSoft.Common.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
            => httpContextAccessor?.HttpContext?.User?.GetClaim<string>(ClaimTypes.NameIdentifier);
        public static bool IsAuthenticated(this IHttpContextAccessor httpContextAccessor) =>
           Executor.TryOrThrows(() => httpContextAccessor.HttpContext.User.Identity.IsAuthenticated,
                                    (s, e) => new NotAuthenticationException(s, e, "Not Authen User is null"));

        public static TId GetClaim<TId>(this ClaimsPrincipal principal, string type)
        {
            if (principal == null || principal.Identity == null ||
                !principal.Identity.IsAuthenticated)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var loggedInUserId = principal.FindFirst(type)?.Value;

            if (typeof(TId) == typeof(string) ||
                typeof(TId) == typeof(int) ||
                typeof(TId) == typeof(long) ||
                typeof(TId) == typeof(Guid))
            {
                var converter = TypeDescriptor.GetConverter(typeof(TId));

                return (TId)converter.ConvertFromInvariantString(loggedInUserId);
            }

            throw new InvalidOperationException("The user id type is invalid.");
        }
    }
}
