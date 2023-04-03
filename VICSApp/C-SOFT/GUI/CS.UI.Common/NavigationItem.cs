using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace CS.UI.Common
{
    public class NavigationItem : CS.Common.Contract.ModelBase
    {
        public NavigationItem()
        {
            Roles = new List<string>();
            SubItems = new List<NavigationItem>();
            AccessRights = new Dictionary<string, string>();
            EnablePropertyChange = true;
        }

        public NavigationItem(PackIconKind icon, string title, string description, string path)
            : this()
        {
            Icon = icon;
            Id = path;
            Path = path;
            Title = title;
            Description = description;
        }

        public string Id { get; set; }
        public string Description { get => Get<string>(); set => Set(value); }
        public string Title { get => Get<string>(); set => Set(value); }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(typeof(PackIconKind), "EmoticonPoop")]
        public PackIconKind Icon { get; set; }
        public string Path { get; set; }
        public string Group { get; set; }

        public IList<string> Roles { get; set; }
        public NavigationItem Parent { get; set; }
        public IList<NavigationItem> SubItems { get; set; }
        public IDictionary<string, string> AccessRights { get; set; }

        public bool IsSelected { get => Get<bool>(); set => Set(value); }
        public bool IsExpanded { get => Get<bool>(); set => Set(value); }
    }
}
