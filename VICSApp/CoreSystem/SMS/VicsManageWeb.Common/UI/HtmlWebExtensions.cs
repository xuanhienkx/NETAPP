using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using VicsManageWeb.Common.UI.Models;

namespace VicsManageWeb.Common.UI
{
    public static class HtmlWebExtensions
    {
        public static IHtmlString FrameHeader(this HtmlHelper html, string title)
        {
            return html.Raw(string.Format("<div class=\"news-header\"><span id=\"frameTitle\">{0}</span></div>", title));
        }

        public static IHtmlString TitleContent(this HtmlHelper html, string title)
        {
            return html.Raw(string.Format("<div class='content-header-1'> <span >{0}</span>  </div>", title.ToUpper()));
        }

        public static IHtmlString NavigationHeader(this HtmlHelper html, string title)
        {
            var htmlBuilder = new StringBuilder();
            var url = html.ViewContext.RouteData.DataTokens["area"];
            htmlBuilder.AppendFormat("<div class=\"nav-panel\"><a href=\"/{0}\" class=\"home\"><img style=\"border-width: 0px;\" src=\"/Images/home.png\" alt=\"Trang chủ\"></a>", url);
            htmlBuilder.AppendFormat("<span class=\"current-page\">{0}</span>", title);
            htmlBuilder.Append("</div>");
            return html.Raw(htmlBuilder.ToString());
        }
        /// <summary>
        /// AdminNavigationHeader
        /// </summary>
        /// <param name="html">HtmlHelper</param>
        /// <param name="header">Header title</param>
        /// <param name="subNav">Sub navigator</param>
        /// <param name="iconClass">class by fa-icon</param>
        /// <returns>HtmlHelper</returns>
        public static IHtmlString AdminNavigationHeader(this HtmlHelper html, string header, string subNav = "", string iconClass = "")
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendFormat("<div class='row'> <div class='col-lg-12'> <h1 class='page-header'>{0}</h1> ", header);
            htmlBuilder.AppendFormat("<ol class='breadcrumb'> <li> <i class='fa fa-dashboard'></i>{0} </li>", html.ActionLink("Trang chủ", "Index", "Home"));
            var nav = string.Empty;
            var icon = string.Empty;
            RouteData rd = html.ViewContext.RouteData;
            string currentController = rd.GetRequiredString("controller");
            string currentAction = rd.GetRequiredString("action");
            switch (currentAction)
            {
                case "Index":
                    htmlBuilder.AppendFormat("<li class='active'> <i class='fa {0}'></i> {1}</li></ol> </div> </div>", "fa-list-alt", "Danh sách");
                    break;
                case "Create":
                    icon = "fa-file-text-o";
                    nav = "Tạo mới";
                    htmlBuilder.AppendFormat("<li> <i class='fa fa-list-alt'></i>{0} </li>", html.ActionLink("Danh sách", "Index", currentController));
                    htmlBuilder.AppendFormat("<li class='active'> <i class='fa {0}'></i> {1}</li></ol> </div> </div>", icon, nav);
                    break;
                case "Edit":
                    icon = "fa-pencil-square-o";
                    nav = "Sửa";
                    htmlBuilder.AppendFormat("<li> <i class='fa fa-list-alt'></i>{0} </li>", html.ActionLink("Danh sách", "Index", currentController));
                    htmlBuilder.AppendFormat("<li class='active'> <i class='fa {0}'></i> {1}</li></ol> </div> </div>", icon, nav);

                    break;
                default:
                    icon = iconClass;
                    nav = subNav;
                    htmlBuilder.AppendFormat("<li> <i class='fa fa-list-alt'></i>{0} </li>", html.ActionLink("Danh sách", "Index", currentController));
                    htmlBuilder.AppendFormat("<li class='active'> <i class='fa {0}'></i> {1}</li></ol> </div> </div>", icon, nav);
                    break;
            }

            return html.Raw(htmlBuilder.ToString());
        }

        public static IHtmlString RateFor(this HtmlHelper html, int rate, int topRate = 5)
        {
            var htmlBuilder = new StringBuilder();
            for (int i = 0; i < topRate; i++)
            {
                htmlBuilder.AppendFormat("<span class=\"glyphicon glyphicon-star{0}\" aria-hidden=\"true\" rate=\"{1}\"></span>",
                    i < rate ? string.Empty : "-empty", i + 1);
            }
            return html.Raw(htmlBuilder.ToString());
        }

        public static IHtmlString Action(this AjaxHelper ajax, string text, string actionName,
            object routeData, string updateTargetId)
        {
            return ajax.ActionLink(text, actionName, routeData, new AjaxOptions()
            {
                UpdateTargetId = updateTargetId
            });
        }
        public static string RenderPartialView(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public static IHtmlString Image(this HtmlHelper html, string type, string id, int height, int width)
        {
            return html.Raw(string.Format("/media/{0}/{1}?h={2}&w={3}", type, id, height, width));
        }


        public static IHtmlString Link(this AjaxHelper ajax, string title, string action, string controller, object routeValues)
        {
            return ajax.Link(title, action, controller, routeValues, null);
        }

        public static IHtmlString Link(this AjaxHelper ajax, string title, string action, string controller,
            AjaxOptions ajaxOptions)
        {
            return ajax.Link(title, action, controller, null, ajaxOptions);
        }

        public static IHtmlString Link(this AjaxHelper ajax, string title, string action, string controller, object routeValues,
            AjaxOptions ajaxOptions, object htmlAttributes = null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) ?? new RouteValueDictionary();
            var routes = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            var targetUrl = UrlHelper.GenerateUrl(null, action, controller, routes, ajax.RouteCollection, ajax.ViewContext.RequestContext, true);

            var builder = new TagBuilder("a")
            {
                InnerHtml = HttpUtility.HtmlEncode(title)
            };
            builder.MergeAttributes(attributes);
            // builder.MergeAttribute("href", targetUrl);
            builder.MergeAttribute("data-ajax-url", targetUrl);
            if (ajax.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                var options = ajaxOptions ?? new AjaxOptions();
                var optionAttributes = options.ToUnobtrusiveHtmlAttributes();
                optionAttributes.Remove("data-ajax");
                builder.MergeAttributes(optionAttributes);
            }
            builder.MergeAttribute("onclick", "return $(this).mbqAjax();");

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Autocomplete(this HtmlHelper html, string name, string actionName, string controllerName, string placeHolder, string onSelected = "", string cssClass = "", string style = "")
        {
            string autocompleteUrl = UrlHelper.GenerateUrl(null, actionName, controllerName,
                null,
                html.RouteCollection,
                html.ViewContext.RequestContext,
                includeImplicitMvcValues: true);

            // hack the url
            var index = autocompleteUrl.IndexOf("/Admin/", StringComparison.Ordinal);
            if (index != -1)
                autocompleteUrl = autocompleteUrl.Substring(index + 6);

            return html.TextBox(name, null,
                new
                {
                    data_autocomplete_url = autocompleteUrl,
                    placeholder = placeHolder,
                    onSelected = onSelected,
                    @class = cssClass,
                    @style = style
                });
        }

        public static MvcHtmlString MenuItem(this HtmlHelper html, string title, string actionName,
            string controllerName, object routeValues = null)
        {
            RouteData rd = html.ViewContext.RouteData;
            string currentController = rd.GetRequiredString("controller");
            string currentAction = rd.GetRequiredString("action");
            if (currentAction == "Index") currentAction = string.Empty;
            var current = HttpContext.Current.Request.ApplicationPath;
            var activeClass = currentAction.Equals(actionName, StringComparison.OrdinalIgnoreCase)
                              && currentController.Equals(controllerName, StringComparison.OrdinalIgnoreCase)
                ? new { @class = "active" }
                : null;

            if (activeClass == null)
            {
                var prevUrl = HttpContext.Current.Request.UrlReferrer;
                if (prevUrl != null)
                {
                    var urlPath = prevUrl.OriginalString;
                    if (urlPath.Contains(string.Format("{0}/{1}", controllerName, actionName)) ||
                        urlPath.EndsWith(controllerName))
                        activeClass = new { @class = "active" };
                }
            }

            return html.ActionLink(title, actionName, controllerName, routeValues, activeClass);
        }
        public static IHtmlString Menu(this HtmlHelper html, List<Menu> menus)
        {

            var ulRoot = new TagBuilder("ul");
            ulRoot.AddCssClass("nav nav-sidebar");
            ulRoot.MergeAttribute("id", "side-menu");
            RouteData rd = html.ViewContext.RouteData;
            string currentController = rd.GetRequiredString("controller");
            string currentAction = rd.GetRequiredString("action");
            var current = HttpContext.Current.Request.Path;
            const string icon = "<span class=\"fa arrow\"></span>";
            const string activeSpan="<span class=\"sr-only\">(current)</span>";
            if (current.Equals("/", StringComparison.CurrentCultureIgnoreCase))
            {
                current = current + currentController + "/" + currentAction;
            }
            else 
            if (currentAction.Equals("index", StringComparison.CurrentCultureIgnoreCase))
            {
                current = current + "/" + currentAction;
            }
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var activeThis = false;
            var liTag = new StringBuilder();
            foreach (var m in menus)
            {
                var li = new TagBuilder("li");
                var sub = string.Empty;
                if (m.SubMenus != null && m.SubMenus.Any())
                {
                    var subUl = new TagBuilder("ul");
                    var subTagLi = new StringBuilder();
                    subUl.AddCssClass("nav");
                    foreach (var it in m.SubMenus)
                    {
                         if (it.ExtenMenu != null && it.ExtenMenu.ExtenAction.Contains(currentAction))
                         {
                             current = string.Format("/{0}/{1}", currentController, it.ExtenMenu.RefAction);
                         }
                        var suba = new TagBuilder("a");
                        suba.Attributes.Add("href", urlHelper.Action(it.Action, it.Controller));
                        suba.InnerHtml =
                            !string.IsNullOrEmpty(it.IconClass)
                            ? string.Format("<i class=\"fa fa-fw {0}\"></i>{1} ", it.IconClass, it.Title)
                            : it.Title;
                        var sbli = new TagBuilder("li");
                        if (m.ExtenMenu != null && m.ExtenMenu.ExtenAction.Contains(currentAction))
                        {
                            current = string.Format("/{0}/{1}", currentController, m.ExtenMenu.RefAction);
                        }
                        if (string.Format("/{0}/{1}", it.Controller, it.Action).Contains(current))
                        {
                            activeThis = true;
                            suba.Attributes.Add("currentActive", "active");
                            suba.AddCssClass("active");
                            subUl.AddCssClass("in");
                        }
                        sbli.InnerHtml = suba.ToString(TagRenderMode.Normal);
                        subTagLi.Append(sbli.ToString(TagRenderMode.Normal));
                    }
                    subUl.InnerHtml = subTagLi.ToString();
                    sub = subUl.ToString(TagRenderMode.Normal);

                }
                var a = new TagBuilder("a");
                string href = m.Action == m.Controller ? "#" : urlHelper.Action(m.Action, m.Controller);

                a.Attributes.Add("href", href);
                var title = !string.IsNullOrEmpty(m.IconClass)
                       ? string.Format("<i class=\"fa {0}\"></i>{1} ", m.IconClass, m.Title)
                       : m.Title;

                a.InnerHtml = href == "#" ? title + icon : title;

                if (string.Format("/{0}/{1}", m.Controller, m.Action).Equals(current, StringComparison.CurrentCultureIgnoreCase))
                {
                    li.AddCssClass("active");
                    a.AddCssClass("active");
                    a.InnerHtml += activeSpan;
                }
                if (activeThis)
                {
                    li.AddCssClass("active");
                    a.InnerHtml += activeSpan;
                }

                li.InnerHtml = a.ToString(TagRenderMode.Normal) + sub;
                liTag.Append(li.ToString(TagRenderMode.Normal));

                activeThis = false;
            }
            ulRoot.InnerHtml = liTag.ToString();
            return MvcHtmlString.Create(ulRoot.ToString(TagRenderMode.Normal));
        }
    }
}
