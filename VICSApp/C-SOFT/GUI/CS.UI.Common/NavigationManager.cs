using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using CS.Common.Contract;
using CS.Common.Contract.Enums;
using CS.UI.Common.Extensions;
using CS.UI.Common.Localization;
using MaterialDesignThemes.Wpf;

namespace CS.UI.Common
{
    public class NavigationManager
    {
        private readonly string configPath;
        private readonly Assembly assembly;
        NavigationManager(string configPath, Assembly assembly)
        {
            this.configPath = configPath;
            this.assembly = assembly;
        }

        public static NavigationManager Instance { get; private set; }

        public static void UseConfig(string configPath, Assembly assembly)
        {
            Instance = new NavigationManager(configPath, assembly);
        }

        public ObservableCollection<NavigationItem> Items { get; } = new ObservableCollection<NavigationItem>();

        public void Reset()
        {
            ApplicationServiceLocator.Instance.RunOnUiThread(() =>
            {
                Items.Clear();

                if (!CurrentPrincipal.Instance.IsAuthenticated)
                    return;

                var items = Helper.SortOut(assembly.LoadFromSource<IList<NavigationItem>>(configPath));
                foreach (var item in items)
                { 
                    item.Path = item.Path?.ToLowerInvariant();
                    item.Id = item.Id?.ToLowerInvariant();
                    Items.Add(item);
                }
            }, 100);
        }

        public NavigationItem Find(string id)
        {
            return Items.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public NavigationItem FindSelected(string path)
        {
            if (Items == null || string.IsNullOrEmpty(path))
                return null;

            var selectedItems = new List<NavigationItem>();
            foreach (var item in Items)
            {
                if (Helper.SelectNavigationItem(item, $"{path.Trim('/')}/", selectedItems))
                    break;
            }

            var fistSelected = selectedItems.FirstOrDefault();
            if (fistSelected == null)
                return null;

            var selectedItem = new NavigationItem
            {
                Id = fistSelected.Id,
                Title = fistSelected.Title,
                Description = fistSelected.Description,
                Icon = fistSelected.Icon
            };

            if (fistSelected.Icon == PackIconKind.EmoticonPoop && selectedItems.Count > 1)
                selectedItem.Icon = selectedItems[1].Icon;
            return selectedItem;
        }

        #region Helper class

        private static class Helper
        {
            internal static IList<NavigationItem> SortOut(IList<NavigationItem> navigationItems, string prefix = null, int level = 0)
            {
                var result = new List<NavigationItem>();
                var userLogin = ApplicationServiceLocator.Instance.Shell.User;
                foreach (var item in navigationItems)
                {
                    var validedItem = DefineNavigationItemLevel(item, prefix, level);
                    if (validedItem != null)
                    {
                        if (!CurrentPrincipal.Instance.IsInRole(UserRoleType.Admin) && userLogin != null)
                        {
                            var isAllAccess = item.AccessRights.Count == 0 || item.AccessRights.All(it => userLogin.Has(it.Key, it.Value));
                            if (!isAllAccess)
                                continue;
                        }
                        result.Add(validedItem);
                    }
                }
                return result;
            }

            internal static bool SelectNavigationItem(NavigationItem navigationItem, string path, IList<NavigationItem> selectedItems)
            {
                if (!string.IsNullOrEmpty(navigationItem.Path))
                {
                    var currentPath = navigationItem.Path.Trim('/');
                    if (path.Equals($"{currentPath}/", StringComparison.OrdinalIgnoreCase))
                    {
                        selectedItems.Add(navigationItem);
                        navigationItem.IsSelected = true;
                        return true;
                    }
                }

                if (navigationItem.SubItems.Any())
                {
                    foreach (var item in navigationItem.SubItems)
                    {
                        if (SelectNavigationItem(item, path, selectedItems))
                        {
                            selectedItems.Add(navigationItem);
                            navigationItem.IsExpanded = true;
                            return true;
                        }
                    }
                }

                navigationItem.IsExpanded = false;
                navigationItem.IsSelected = false;

                return false;
            }

            static NavigationItem DefineNavigationItemLevel(NavigationItem item, string prefix, int level)
            {
                if (item.SubItems.Count == 0)
                {
                    if (string.IsNullOrEmpty(item.Path))
                        return null;

                    Localized(item);
                    item.Group = "NavigationItem";
                    return item;
                }

                if (item.SubItems.Count == 1)
                    item = DefineNavigationItemLevel(item.SubItems[0], prefix, level);
                else if (item.SubItems.Count > 1)
                {
                    var subLevel = level + 1;
                    item.SubItems = SortOut(item.SubItems, item.Id, subLevel);
                }

                Localized(item);
                item.Group = $"{prefix}{level}";
                return item;
            }

            static void Localized(NavigationItem item)
            {
                item.Title = LocalizationManager.Instance.Translate($"Navigation_{item.Id}_Title");
                item.Description = LocalizationManager.Instance.Translate($"Navigation_{item.Id}_Desc");
            }
        }

        #endregion


    }
}
