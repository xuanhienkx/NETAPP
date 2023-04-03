using System.Collections.Generic;

namespace VicsManageWeb.Common.UI.Models
{
    public class Menu
    {
        public string Title { get; set; }
        public object RouteValues { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public IList<Menu> SubMenus { get; set; }
        public string IconClass { get; set; }
        public bool IsEnabled { get; set; }
        public ExtenMenu ExtenMenu { get; set; }

        public Menu()
        {
            //this.ExtenMenu = new ExtenMenu()
            //{
            //    RefAction = "Index",
            //    ExtenAction = new string[] { "Create", "Edit" }
            //};
        }
        public Menu(string controller, string action, string title)
            :this()
        {
            this.Controller = controller;
            this.Action = action;
            this.Title = title;
            
        }
        public Menu(string controller, string action, string title, List<Menu> subMenu)
            : this()
        {
            this.Controller = controller;
            this.Action = action;
            this.Title = title;
            this.SubMenus = subMenu;
        }
        public Menu(string controller, string action, string title, string iconClass)
            : this()
        {
            this.Controller = controller;
            this.Action = action;
            this.Title = title;
            this.IconClass = iconClass;
        }
        public Menu(string controller, string action, string title, string iconClass, List<Menu> subMenu)
        {
            this.Controller = controller;
            this.Action = action;
            this.Title = title;
            this.IconClass = iconClass;
            this.SubMenus = subMenu;
        }
        public Menu(string controller, string action, string title, string iconClass,ExtenMenu exten)
        {
            this.Controller = controller;
            this.Action = action;
            this.Title = title;
            this.IconClass = iconClass;
            this.ExtenMenu = exten; 
        }
    }

    public class ExtenMenu
    {
        public string[] ExtenAction { get; set; }
        public string RefAction { get; set; }

        public ExtenMenu(string action, string[] exteStrings)
        {
            this.ExtenAction = exteStrings;
            this.RefAction = action;
        }
    }
}