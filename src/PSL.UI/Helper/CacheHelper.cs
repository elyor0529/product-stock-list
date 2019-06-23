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
    public static class CacheHelper
    {

        public const string ProductListingKey = "_product_listing_key";
        public const string OrderListingKey = "_order_{0}_listing_key";

        public static int? ProductListingCount()
        {
            var count = (int?)WebCache.Get(ProductListingKey);

            if (count == null)
            {
                using (var db = ApplicationDbContext.Create())
                {
                    count = db.Products.Count();

                    WebCache.Set(ProductListingKey, count);
                }
            }

            return count;
        }

        public static int? OrderListingCount(string userId)
        {
            var cacheKey = string.Format(OrderListingKey, userId);
            var count = (int?)WebCache.Get(cacheKey);

            if (count == null)
            {
                using (var db = ApplicationDbContext.Create())
                {
                    count = db.Orders.Count(a => a.ClientId == userId);

                    WebCache.Set(ProductListingKey, count);
                }
            }

            return count;
        }

    }
}