using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSL.UI.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Product Stock Listing";

            return View();
        } 
    }
}