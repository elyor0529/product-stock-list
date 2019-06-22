using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSL.UI;
using PSL.UI.Controllers;

namespace PSL.UI.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new ProductController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Product Stock Listing", result.ViewBag.Title);
        }

    }
}
