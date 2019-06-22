using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PSL.UI.Core.Data;

namespace PSL.UI.Helper
{
    public static class UIHelper
    {

        private const string ProductListingKey = "_product_listing_key";
        private const string OrderListingKey = "_order_{0}_listing_key";

        public static MvcHtmlString ActionProductListingLink(this HtmlHelper helper)
        {
            var count = (int?)WebCache.Get(ProductListingKey);

            if (count > 0)
            {
                return helper.ActionLink($"Products({count})", "Index", "Product");
            }
            else
            {
                var request = helper.ViewContext.RequestContext.HttpContext;

                using (var db = request.GetOwinContext().Get<ApplicationDbContext>())
                {
                    count = db.Products.Count(a => a.Inventory > 0);

                    WebCache.Set(ProductListingKey, count);

                    return helper.ActionLink($"Products({count})", "Index", "Product");
                }
            }
        }

        public static MvcHtmlString ActionOrderListingLink(this HtmlHelper helper)
        {
            var request = helper.ViewContext.RequestContext.HttpContext;
            var userId = request.User.Identity.GetUserId();
            var cacheKey = string.Format(OrderListingKey, userId);
            var count = (int?)WebCache.Get(cacheKey);

            if (count > 0)
            {
                return helper.ActionLink($"Orders({count})", "Index", "Order");
            }
            else
            {
                using (var db = request.GetOwinContext().Get<ApplicationDbContext>())
                {
                    count = db.Orders.Count(a => a.ClientId == userId);

                    WebCache.Set(ProductListingKey, count);

                    return helper.ActionLink($"Orders({count})", "Index", "Order");
                }
            }
        }

    }
}