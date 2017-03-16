using MVC.RBAC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC.RBAC.Extensions
{
    public static class HtmlHelperExtensions
    {
        static IPermissionService permissionService = new PermissionService();
        public static MvcHtmlString ActionPermissionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            string controllerName = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            return ActionPermissionLink(htmlHelper, linkText, controllerName + actionName);
        }

        public static MvcHtmlString ActionPermissionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string permissionName)
        {
            if (permissionService.Authorize(permissionName))
            {
                return htmlHelper.ActionLink(linkText, actionName);
            }
            return MvcHtmlString.Empty;
        }
    }
}