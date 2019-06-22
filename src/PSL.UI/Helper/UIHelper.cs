using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.AspNet.Identity.Owin;
using PSL.UI.Core.Data;

namespace PSL.UI.Helper
{
    public static class UIHelper
    {

        private const string ProductListingKey = "_product_listing_key";

        public static MvcHtmlString ActionProductListingLink(this HtmlHelper helper)
        {
            var count = (int?)WebCache.Get(ProductListingKey);

            if (count > 0)
            {
                return helper.ActionLink($"Products({count})", "Index", "Product");
            }
            else
            {
                using (var db = helper.ViewContext.RequestContext.HttpContext.GetOwinContext().Get<ApplicationDbContext>())
                {
                    count = db.Products.Count(a => a.Inventory > 0);

                    WebCache.Set(ProductListingKey, count);

                    return helper.ActionLink($"Products({count})", "Index", "Product");
                }
            }
        }

    }
}