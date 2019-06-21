using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace MyProductListWebApp.Models
{
    /// <summary>
    /// Model which describes a product.
    /// </summary>
    [Serializable]
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [XmlElement]
        public decimal Price { get; set; }
    }
}