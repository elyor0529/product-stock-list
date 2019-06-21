using Newtonsoft.Json;
using System.Web.Http;

namespace MyProductListWebApp.Controllers
{
    /// <summary>
    /// Controller for hnadling products.
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// Returns the list of products.
        /// </summary>
        public string GetProductList()
        {
            var productList = ProductList.Create();
            return JsonConvert.SerializeObject(productList.List);
        }
    }
}
