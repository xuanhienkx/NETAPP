using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Principal;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;

namespace CS.Common.Contract
{
    public static class Helper
    {
        public static string EmailRegex = @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        public static string NotEmpty = @"^(?=\s*\S).*$";
        public static string NumberOnly = @"^[0-9]*$";
        public static string PhoneNumber = @"^[0-9()-\.\s]*$";
        public static string BranchCode = @"^[0-9]{3}$";

        public static string GetPropertyName(this LambdaExpression expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new InvalidOperationException();
            }

            return memberExpression.Member.Name;
        }

        public static T Clone<T>(T obj) where T : class
        {
            var result = ProtoBuf.Serializer.DeepClone(obj);
            return result;
        }


        #region ClaimPrincipal

        public static bool IsInRole(this IPrincipal principal, params UserRoleType[] roles)
        {
            return roles.Any(r => principal.IsInRole(r.ToString()));
        }

        public static IList<T> EnumToList<T>()
        {
            var enums = Enum.GetValues(typeof(T)).OfType<T>().ToList();
            return enums;
        }

        #endregion

        #region UserLogin

        public static bool Is(this IUserLogin user, params UserType[] types)
        {
            return types.Any(r => user.UserType.Equals(r));
        }

        public static bool Has(this IUserLogin user, params PermissionAccess[] permissions)
        {
            return permissions.All(p => user.Has(p.Name, p.Type));
        }

        public static bool Has(this IUserLogin user, AccessRight right, AccessType type = AccessType.Allow)
        {
            return right != AccessRight.None &&
                   user?.Rights != null && 
                   user.Rights.Any(r => r.Name.Equals(right) && r.Type >= type);
        }

        public static bool Has(this IUserLogin user, string right, string type)
        {
            var hasRight = Enum.TryParse(right, out AccessRight accessRight);
            var hastype = Enum.TryParse(type, out AccessType rightType);
            if (!hasRight || !hastype)
                return true;

            return user.Has(accessRight, rightType);
        }
        
        public static bool HasOnly(this IUserLogin user, AccessRight right, AccessType type)
        {
            return user.Rights != null && user.Rights.All(r => r.Name.Equals(right) && r.Type < type);
        }

        #endregion
    }
}
