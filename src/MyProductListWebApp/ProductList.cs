using MyProductListWebApp.Models;
using System.Collections.Generic;
using System.Xml;

namespace MyProductListWebApp
{
    /// <summary>
    /// This class represents a list of products.
    /// </summary>
    public class ProductList
    {
        /// <summary>
        /// Gets the list of products.
        /// </summary>
        public List<ProductModel> List
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new ProductList object with data and returns it.
        /// </summary>
        public static ProductList Create()
        {
            XmlDocument doc = ProductDataSource.GetProductXml();
            var list = XmlUtils.DeserializeXml(doc, typeof(List<ProductModel>)) as List<ProductModel>;

            var productList = new ProductList();
            productList.List = list;
            return productList;
        }
    }
}