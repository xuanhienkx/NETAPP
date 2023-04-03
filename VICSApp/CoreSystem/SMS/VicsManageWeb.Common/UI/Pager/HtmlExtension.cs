using System;
using System.Web;
using System.Web.Mvc;

namespace VicsManageWeb.Common.UI.Pager
{
    public static class HtmlExtension
    {
        public static IHtmlString Pager(this HtmlHelper html, string actionName, int totalPageCount, int page, int pageSize, string updateTargetId, PagerType viewType = PagerType.Numbers)
        {
            return Pager(html, actionName, totalPageCount, page, pageSize, updateTargetId, string.Empty, viewType);
        }

        public static IHtmlString Pager(this HtmlHelper html, string actionName, int totalPageCount, int page, int pageSize, string updateTargetId, string dependencyTargetId, PagerType viewType = PagerType.Numbers)
        {
            var pagerOption = new PagerOptions
            {
                AjaxUpdateTargetId = updateTargetId,
                ViewType = viewType,
                ShowFirstLast = viewType == PagerType.Numbers,
                DependencySelector = dependencyTargetId
            };

            return Pager(html, actionName, totalPageCount, page, pageSize, pagerOption);
        }

        public static IHtmlString Pager(this HtmlHelper html, string actionName, int totalPageCount, int page, int pageSize, PagerOptions pagerOption)
        {
            if (pagerOption.ViewType == PagerType.Hidden) 
                return new HtmlString(string.Empty);

            if (totalPageCount == 0)
                return new HtmlString("Nội dung cần hiển thị không có dữ liệu");

            var totalOfPage = (int)Math.Ceiling((decimal)totalPageCount / pageSize);
            if (totalOfPage < pagerOption.NumericPagerItemCount)
                pagerOption.NumericPagerItemCount = totalOfPage;

            var papgerBuilder = new PagerBuilder(html, actionName, null, totalOfPage, page, pagerOption, null, null, null);
            return papgerBuilder.RenderPager();
        }
    }
}
