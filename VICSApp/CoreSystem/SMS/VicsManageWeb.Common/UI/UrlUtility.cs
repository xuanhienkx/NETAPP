using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace VicsManageWeb.Common.UI
{
    public class UrlUtility
    {
        /// <summary>
        /// Generate paging url
        /// </summary>
        /// <returns>Navigated url for pager item</returns>
        public static string GenerateUrl(string actionName, string controller, string routeName, string hiddenId, RouteValueDictionary routes, ViewContext viewContext)
        {

            var currentRouteValues = GetCurrentRouteValues(hiddenId, routes, viewContext);
            // action
            currentRouteValues["action"] = actionName;
            // controller
            currentRouteValues["controller"] = controller;
            // hidden id
            if (string.IsNullOrEmpty(hiddenId) == false) currentRouteValues[hiddenId] = "#";

            // Return link
            var urlHelper = new UrlHelper(viewContext.RequestContext);
            return !string.IsNullOrEmpty(routeName) ? urlHelper.RouteUrl(routeName, currentRouteValues) : urlHelper.RouteUrl(currentRouteValues);
        }

        private static RouteValueDictionary GetCurrentRouteValues(string hiddenId, RouteValueDictionary routes, ViewContext viewContext)
        {
            var currentRouteValues = routes ?? new RouteValueDictionary();
            var rq = viewContext.HttpContext.Request.QueryString;
            if (rq != null && rq.Count > 0)
            {
                var invalidParams = new[] { "x-requested-with", "xmlhttprequest", hiddenId.ToLower() };
                foreach (string key in rq.Keys)
                {
                    // add other url query string parameters (exclude PageIndexParameterName parameter value and X-Requested-With=XMLHttpRequest ajax parameter) to route value collection
                    if (!string.IsNullOrEmpty(key) && Array.IndexOf(invalidParams, key.ToLower()) < 0)
                    {
                        currentRouteValues[key] = rq[key];
                    }
                }
            }
            
            return currentRouteValues;
        }
    }
}
