using CS.Application.Views.Group;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CS.Application.Framework
{
    public static class PermissionFactory
    {
        public static IEnumerable<PermissionItemViewModel> BuildAllAccessRights(IList<PermissionAccess> currentAccesses)
        {
            var values = Enum.GetValues(typeof(AccessRight));
            foreach (var value in values.Cast<AccessRight>())
            {
                if (value == AccessRight.None)
                    continue;

                var type = value.GetType().GetTypeInfo()
                    .GetDeclaredField(value.ToString())
                    .GetCustomAttribute<AccessRightTypeAttribute>();
                var accessTypes = type?.Types ?? new List<AccessType> { AccessType.Deny, AccessType.Allow };
                var groupTypeName = type?.Group;
                yield return currentAccesses.Build(value, accessTypes, groupTypeName);
            }
        }

        private static PermissionItemViewModel Build(this IList<PermissionAccess> currentAccesses, AccessRight right, IEnumerable<AccessType> accessTypes, string groupTypeName)
        {
            var types = new EnumCollection<AccessType>(accessTypes.ToArray());
            var rightType = currentAccesses?.FirstOrDefault(r => r.Name.Equals(right))?.Type ?? AccessType.Deny;
            return new PermissionItemViewModel(new PermissionAccess(right, rightType))
            {
                AccessTypes = types,
                GroupTypeName = UI.Common.Localization.LocalizationManager.Instance.Translate($"RightGroup_{groupTypeName}_Title"),
                IsAllowDeny = types.Count == 2 && types.Any(x => x.Value.Equals(AccessType.Allow)),
                Title = UI.Common.Localization.LocalizationManager.Instance.Translate($"Right_{right}_Title"),
                Description = UI.Common.Localization.LocalizationManager.Instance.Translate($"Right_{right}_Desc"),
            };
        }
    }
}
