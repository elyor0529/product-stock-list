using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var result = controller.Index(0) as ViewResult;

            // Assert
            Assert.AreEqual("Product Stock Listing", result.ViewBag.Title);
        }

    }
}
