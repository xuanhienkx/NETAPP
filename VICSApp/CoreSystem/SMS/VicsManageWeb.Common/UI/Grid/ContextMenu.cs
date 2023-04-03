using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace VicsManageWeb.Common.UI.Grid
{
    public class MenuItem<T>
    {
        public IHtmlString Element { get; set; }
        public string Constraint { get; set; }

        public void EnableWhen(Expression<Func<T, object>> constraint, string operatorSymbol, object value)
        {
            var body = constraint.Body;
            var unaryExp = body as UnaryExpression;

            var name = unaryExp != null ? unaryExp.Operand.Type.Name : ((MemberExpression) constraint.Body).Member.Name;
            Constraint = JsonConvert.SerializeObject(new {name, opr = operatorSymbol, value = value.ToString() });
        }
    }

    public class MenuItemCollection<T>
    {
        private readonly List<MenuItem<T>> menuItems = new List<MenuItem<T>>();

        public MenuItem<T> Add(IHtmlString element)
        {
            var menu = new MenuItem<T>
            {
                Element = element
            };
            menuItems.Add(menu);
            return menu;
        }

        public List<MenuItem<T>> GetAllItems()
        {
            return menuItems;
        }
    }

    public class ContextMenu<T>
    {
        private readonly string name;
        private readonly MenuItemCollection<T> menuCollection;

        public ContextMenu(string name)
        {
            this.name = name;
            this.menuCollection = new MenuItemCollection<T>();
        }

        public string SelectorName { get; private set; }

        public void Build(Action<MenuItemCollection<T>> menuBuilder)
        {
            menuBuilder(menuCollection);
        }

        public string Render()
        {
            var menuItems = menuCollection.GetAllItems();
            if (menuItems.Any() == false)
                return string.Empty;

            // render menu item
            var div= new TagBuilder("div");
            var ulTag = new TagBuilder("ul");
            ulTag.GenerateId(name);

            SelectorName = "#" + ulTag.Attributes["id"];

            ulTag.AddCssClass("dropdown-menu");
            ulTag.Attributes["role"] = "menu";
            ulTag.Attributes["style"] = "display:none";

            var htmlBuilder = new StringBuilder();
            menuItems.ForEach(item =>
            {
                var liTag = new TagBuilder("li");

                var html = item.Element.ToHtmlString();
                if (string.IsNullOrEmpty(html))
                {
                    liTag.AddCssClass("nav-divider");
                }
                else
                {
                    liTag.Attributes["ew"] = item.Constraint;
                    liTag.InnerHtml = html;
                }

                htmlBuilder.Append(liTag.ToString(TagRenderMode.Normal));
            });

            ulTag.InnerHtml = htmlBuilder.ToString();
            div.InnerHtml = ulTag.ToString();
            return ulTag.ToString(TagRenderMode.Normal);
        }
    }
}
