using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PSL.UI.Core.Caching;
using PSL.UI.Core.Data;

namespace PSL.UI.Helper
{
    public static class UIHelper
    {

        public static MvcHtmlString ProductListingActionLink(this HtmlHelper helper)
        {
            var count = ProductCache.ProductListingCount();

            return helper.ActionLink($"Products({count})", "Index", "Product");
        }

        public static MvcHtmlString OrderListingActionLink(this HtmlHelper helper)
        {
            var request = helper.ViewContext.RequestContext.HttpContext;
            var userId = request.User.Identity.GetUserId();
            var count = ProductCache.OrderListingCount(userId);

            return helper.ActionLink($"Orders({count})", "Index", "Order");
        }

    }
}