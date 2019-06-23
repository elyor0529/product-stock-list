using System.Linq;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using PSL.UI.Core.Data;

namespace PSL.UI.Core.Caching
{
    public static class ProductCache
    {

        private const string ProductListingKey = "_product_listing_key";
        private const string OrderListingKey = "_order_{0}_listing_key";

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

        public static void ClearOrders(string userId)
        {
            var cacheKey = string.Format(OrderListingKey, userId);

            WebCache.Remove(cacheKey);
        }

    }
}