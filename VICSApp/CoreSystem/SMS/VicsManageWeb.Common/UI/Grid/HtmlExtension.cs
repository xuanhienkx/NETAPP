using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GridMvc.Columns;
using GridMvc.Html;
using Newtonsoft.Json;
using VicsManageWeb.Common.UI.Models;
using VicsManageWeb.Common.UI.Pager;

namespace VicsManageWeb.Common.UI.Grid
{
     public static class HtmlExtension
    {
        public static IHtmlString PagedGrid<T>(this HtmlHelper html, string name,
            PagedList<T> model,
            Action<IGridColumnCollection<T>> columnsBuilder,
            Func<T, string> setRowsCss) where T : class
        {
            return PagedGrid(html, name, model, columnsBuilder, null, true, setRowsCss);
        }

        public static IHtmlString PagedGrid<T>(this HtmlHelper html, string name,
            PagedList<T> model,
            Action<IGridColumnCollection<T>> columnsBuilder,
            Action<MenuItemCollection<T>> menuBuilder = null,
            bool includePager = true,
            Func<T, string> setRowsCss = null) where T : class
        {
            var grid = html.Grid(model.Items)
                .Named(name)
                .Selectable(false)
                .SetLanguage("vi");

            if (columnsBuilder != null) grid.Columns(columnsBuilder);
            if (setRowsCss != null) grid.SetRowCssClasses(setRowsCss);

            var htmlBuilder = new StringBuilder(grid.Render());
            
            // render context menu
            string contextMenuName = string.Empty;
            if (menuBuilder != null)
            { 
                var contextMenu = new ContextMenu<T>(name);
                
                contextMenu.Build(menuBuilder);
                htmlBuilder.Append(contextMenu.Render());
                contextMenuName = contextMenu.SelectorName;
            }

            // render pager
            if (includePager)
            {
                var pagerOption = new PagerOptions()
                {
                    AjaxUpdateTargetId = model.UpdateTargetId,
                    ViewType = PagerType.Numbers
                };
                htmlBuilder.Append(html.Pager(model.ActionName, model.TotalItemsCount, model.CurrentPage, model.PageSize, pagerOption).ToHtmlString());
            }

            // render script for grid
            var sTag = new TagBuilder("script")
            {
                InnerHtml = string.Format("$(\"div[data-gridname='{0}']\").mbqGrid({1});", name, 
                JsonConvert.SerializeObject(new
                {
                    url = UrlUtility.GenerateUrl(model.ActionName, model.ControllerName, string.Empty, PagerOptions.DefaultPageIndexParameterName, null, html.ViewContext),
                    hasPager = includePager,
                    currentIndex = model.CurrentPage,
                    updateTargetId = model.UpdateTargetId,
                    contextMenu = contextMenuName
                }))
            };
            htmlBuilder.Append(sTag.ToString(TagRenderMode.Normal));

            return new HtmlString(htmlBuilder.ToString());
        } 
        
    } 
} 