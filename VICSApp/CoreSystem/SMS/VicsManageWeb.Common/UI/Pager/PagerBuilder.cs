using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;

namespace VicsManageWeb.Common.UI.Pager
{
    public class PagerBuilder
    {
        private readonly HtmlHelper html;
        private readonly string actionName;
        private readonly string controllerName;
        private readonly int totalPageCount = 1;
        private readonly int pageIndex;
        private readonly PagerOptions pagerOptions;
        private readonly RouteValueDictionary routeValues;
        private readonly string routeName;
        private readonly int startPageIndex = 1;
        private readonly int endPageIndex = 1;
        private IDictionary<string, object> htmlAttributes;

        /// <summary>
        /// Used when PagedList is null
        /// </summary>
        internal PagerBuilder(HtmlHelper html, PagerOptions pagerOptions, IDictionary<string, object> htmlAttributes)
        {
            if (pagerOptions == null)
                pagerOptions = new PagerOptions();
            this.html = html;
            this.pagerOptions = pagerOptions;
            this.htmlAttributes = htmlAttributes;
        }

        /// <summary>
        /// Pager builder
        /// </summary>
        internal PagerBuilder(HtmlHelper html, string actionName, string controllerName, int totalPageCount, int pageIndex, PagerOptions pagerOptions, string routeName,
                                RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (string.IsNullOrEmpty(actionName))
                actionName = (string)html.ViewContext.RouteData.Values["action"];

            if (string.IsNullOrEmpty(controllerName))
                controllerName = (string)html.ViewContext.RouteData.Values["controller"];

            if (pagerOptions == null)
                pagerOptions = new PagerOptions();

            this.html = html;
            this.actionName = actionName;
            this.controllerName = controllerName;

            if (pagerOptions.MaxPageIndex == 0 || pagerOptions.MaxPageIndex > totalPageCount)
                this.totalPageCount = totalPageCount;
            else
                this.totalPageCount = pagerOptions.MaxPageIndex;

            this.pageIndex = pageIndex;
            this.pagerOptions = pagerOptions;
            this.routeName = routeName;
            this.routeValues = routeValues;
            this.htmlAttributes = htmlAttributes;

            // start page index
            startPageIndex = pageIndex - (pagerOptions.NumericPagerItemCount / 2);
            if (startPageIndex + pagerOptions.NumericPagerItemCount > this.totalPageCount)
                startPageIndex = this.totalPageCount + 1 - pagerOptions.NumericPagerItemCount;
            if (startPageIndex < 1)
                startPageIndex = 1;

            // end page index
            endPageIndex = startPageIndex + this.pagerOptions.NumericPagerItemCount - 1;
            if (endPageIndex > this.totalPageCount)
                endPageIndex = this.totalPageCount;
        }

        /// <summary>
        /// Render paging control
        /// </summary>
        internal MvcHtmlString RenderPager()
        {
            var tb = new TagBuilder(pagerOptions.ContainerTagName);

            if (!string.IsNullOrEmpty(pagerOptions.Id))
                tb.Attributes.Add("id", pagerOptions.Id);

            if (pagerOptions.ViewType == PagerType.Numbers)
            {
                if (!string.IsNullOrEmpty(pagerOptions.CssClass))
                    tb.AddCssClass(pagerOptions.CssClass);

                if (!string.IsNullOrEmpty(pagerOptions.HorizontalAlign))
                {
                    string strAlign = "text-align:" + pagerOptions.HorizontalAlign.ToLower();
                    if (htmlAttributes == null)
                        htmlAttributes = new RouteValueDictionary { { "style", strAlign } };
                    else
                    {
                        if (htmlAttributes.Keys.Contains("style"))
                            htmlAttributes["style"] += ";" + strAlign;
                    }
                }

                tb.MergeAttributes(htmlAttributes, true);
            }
            else
            {
                tb.AddCssClass("more");
            }

            // script generator
            var ts = new TagBuilder("script")
            {
                InnerHtml = string.Format("$(\"#{0}\").pager({1});",
                pagerOptions.Id,
                JsonConvert.SerializeObject(new
                {
                    url = GenerateUrl(),
                    filterQuery = GenerateFilter(),
                    sortQuery = GenerateSort(),
                    currentIndex = pageIndex,
                    updateTargetId = pagerOptions.AjaxUpdateTargetId,
                    ajaxBegin = pagerOptions.AjaxOnBegin,
                    ajaxComplete = pagerOptions.AjaxOnComplete,
                    ajaxSuccess = pagerOptions.AjaxOnSuccess,
                    ajaxFailure = pagerOptions.AjaxOnFailure
                }))
            };

            var pagerBody = RenderElement() + ts.ToString(TagRenderMode.Normal);
            if (pagerOptions.ViewType == PagerType.Numbers)
            {
                var tagUl = new TagBuilder("ul")
                {
                    InnerHtml = pagerBody
                };
                tagUl.AddCssClass("pagination");
                tb.InnerHtml = tagUl.ToString();
            }
            else
            {
                tb.InnerHtml = pagerBody;
            }
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.Normal));
        }

        private string RenderElement()
        {
            //return null if total page count less than or equal to 1
            if (totalPageCount <= 1 && pagerOptions.AutoHide)
                return string.Empty;

            //Display error message if pageIndex out of range
            if ((pageIndex > totalPageCount && totalPageCount > 0) || pageIndex < 1)
            {
                return string.Format("<div style=\"color:red;font-weight:bold\">{0}</div>", pagerOptions.PageIndexOutOfRangeErrorMessage);
            }

            var pagerItems = new List<PagerItem>();
            //First page
            if (pagerOptions.ShowFirstLast)
                AddFirst(pagerItems);

            // Prev page
            if (pagerOptions.ShowPrevNext)
                AddPrevious(pagerItems);

            if (pagerOptions.ShowNumericPagerItems)
            {
                if (pagerOptions.AlwaysShowFirstLastPageNumber && startPageIndex > 1)
                    pagerItems.Add(new PagerItem("1", 1, false, PagerItemType.NumericPage));

                // more page before numeric page buttons
                if (pagerOptions.ShowMorePagerItems)
                    AddMoreBefore(pagerItems);

                // numeric page
                AddPageNumbers(pagerItems);

                // more page after numeric page buttons
                if (pagerOptions.ShowMorePagerItems)
                    AddMoreAfter(pagerItems);

                if (pagerOptions.AlwaysShowFirstLastPageNumber && endPageIndex < totalPageCount)
                    pagerItems.Add(new PagerItem(totalPageCount.ToString(CultureInfo.InvariantCulture), totalPageCount, false, PagerItemType.NumericPage));
            }

            // Next page
            if (pagerOptions.ShowPrevNext)
                AddNext(pagerItems);

            //Last page
            if (pagerOptions.ShowFirstLast)
                AddLast(pagerItems);

            var sb = new StringBuilder();

            foreach (var item in pagerItems)
            {
                sb.Append(GenerateAnchor(item));
            }

            return sb.ToString();
        }


        private string GenerateSort()
        {
            return string.Empty;
        }

        private object GenerateFilter()
        {
            return string.Empty;
        }

        #region Private members
        private void AddPrevious(ICollection<PagerItem> results)
        {
            var prevIndex = Math.Max(1, pageIndex - 1);
            var item = new PagerItem(pagerOptions.PrevPageText, prevIndex, prevIndex == 1, PagerItemType.PrevPage);
            if (!item.Disabled || (item.Disabled && pagerOptions.ShowDisabledPagerItems))
                results.Add(item);
        }

        private void AddFirst(ICollection<PagerItem> results)
        {
            var item = new PagerItem(pagerOptions.FirstPageText, 1, pageIndex == 1, PagerItemType.FirstPage);
            if (!item.Disabled || (item.Disabled && pagerOptions.ShowDisabledPagerItems))
                results.Add(item);
        }

        private void AddMoreBefore(ICollection<PagerItem> results)
        {
            if (startPageIndex > 1 && pagerOptions.ShowMorePagerItems)
            {
                var index = Math.Max(1, startPageIndex - 1);
                var item = new PagerItem(pagerOptions.MorePageText, index, false, PagerItemType.MorePage);
                results.Add(item);
            }
        }

        private void AddPageNumbers(ICollection<PagerItem> results)
        {
            for (var pageIndex = startPageIndex; pageIndex <= endPageIndex; pageIndex++)
            {
                var text = pageIndex.ToString(CultureInfo.InvariantCulture);
                var item = new PagerItem(text, pageIndex, false, PagerItemType.NumericPage);
                results.Add(item);
            }
        }

        private void AddMoreAfter(ICollection<PagerItem> results)
        {
            if (endPageIndex < totalPageCount)
            {
                var index = startPageIndex + pagerOptions.NumericPagerItemCount;
                if (index > totalPageCount) { index = totalPageCount; }
                var item = new PagerItem(pagerOptions.MorePageText, index, false, PagerItemType.MorePage);
                results.Add(item);
            }
        }

        private void AddNext(ICollection<PagerItem> results)
        {
            var nextIndex = Math.Min(pageIndex + 1, totalPageCount);
            var item = new PagerItem(pagerOptions.NextPageText, nextIndex, nextIndex >= totalPageCount, PagerItemType.NextPage);
            if (!item.Disabled || (item.Disabled && pagerOptions.ShowDisabledPagerItems))
                results.Add(item);
        }

        private void AddLast(ICollection<PagerItem> results)
        {
            var item = new PagerItem(pagerOptions.LastPageText, totalPageCount, pageIndex >= totalPageCount, PagerItemType.LastPage);
            if (!item.Disabled || (item.Disabled && pagerOptions.ShowDisabledPagerItems))
                results.Add(item);
        }

        /// <summary>
        /// Generate paging url
        /// </summary>
        /// <returns>Navigated url for pager item</returns>
        private string GenerateUrl()
        {
            return UrlUtility.GenerateUrl(actionName, controllerName, routeName, pagerOptions.PageIndexParameterName,
                routeValues, html.ViewContext);
        }

        private string GenerateAnchor(PagerItem item)
        {
            string url = GenerateUrl();
            if (pagerOptions.ViewType == PagerType.Numbers)
                return GenerateNumblock(item, url);
            return GenerateBullets(item, url);
        }

        private string GenerateNumblock(PagerItem item, string url)
        {
            var tagRoot = new TagBuilder("li");
            var tagLink = new TagBuilder("a");
            tagLink.SetInnerText(item.Text);
            tagLink.MergeAttribute("data-page", item.PageIndex.ToString(CultureInfo.InvariantCulture));

            if (item.Disabled)
                tagLink.Attributes.Add("disabled", "disabled");

            if (IsActiveItem(item))
            {
                tagRoot.AddCssClass("active");
            }

            tagRoot.InnerHtml = tagLink.ToString(TagRenderMode.Normal);
            return tagRoot.ToString(TagRenderMode.Normal);
        }

        private string GenerateBullets(PagerItem item, string url)
        {
            TagBuilder tagRoot;
            if (item.Type == PagerItemType.PrevPage)
            {
                tagRoot = new TagBuilder("a");
                tagRoot.AddCssClass("glyphicon glyphicon-chevron-left nav-middle");
                tagRoot.MergeAttribute("data-page", item.PageIndex.ToString(CultureInfo.InvariantCulture));

                if (item.Disabled)
                    tagRoot.Attributes.Add("disabled", "disabled");
            }
            else if (item.Type == PagerItemType.NextPage)
            {
                tagRoot = new TagBuilder("a");
                tagRoot.AddCssClass("glyphicon glyphicon-chevron-right nav-middle");
                tagRoot.MergeAttribute("data-page", item.PageIndex.ToString(CultureInfo.InvariantCulture));

                if (item.Disabled)
                    tagRoot.Attributes.Add("disabled", "disabled");
            }
            else
            {
                tagRoot = new TagBuilder("input");
                tagRoot.MergeAttribute("data-page", item.PageIndex.ToString(CultureInfo.InvariantCulture));
                tagRoot.Attributes["type"] = "radio";
                tagRoot.Attributes["name"] = "optradio" + pagerOptions.Id;
                
                if (IsActiveItem(item))
                {
                    tagRoot.Attributes["checked"] = "checked";
                }
            }

            var sb = new StringBuilder(tagRoot.ToString(TagRenderMode.Normal));
            if (item.Type != PagerItemType.FirstPage)
            {
                sb.Append("<span>&nbsp;</span>");
            }
            return sb.ToString();
        }

        private bool IsActiveItem(PagerItem item)
        {
            return item.Type == PagerItemType.NumericPage && item.PageIndex == pageIndex;
        }

        #endregion
    }
}
