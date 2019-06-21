using System.Web;
using System.Xml;

namespace MyProductListWebApp
{
    /// <summary>
    /// This class manages the data source for products.
    /// </summary>
    public class ProductDataSource
    {
        /// <summary>
        /// Creates a new product list object and returns it.
        /// </summary>
        public static XmlDocument GetProductXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/products.xml"));
            return doc;
        }
    }
}