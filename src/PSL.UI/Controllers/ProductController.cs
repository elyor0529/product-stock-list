using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using PSL.UI.Core.Data;
using PSL.UI.Core.Mvc;
using X.PagedList;

namespace PSL.UI.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController()
        {
        }

        public ProductController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public ActionResult Index(int page = 1)
        {
            var products = DbContext.Products.Where(w => w.Inventory > 0).Include(a => a.Orders).OrderByDescending(a => a.Orders.Count).ToPagedList(page, 20);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Listing", products);
            }

            return View(products);
        }

        [HttpPost]
        public ActionResult Get(int id)
        {
            if (!Request.IsAjaxRequest())
                return Json(null, JsonRequestBehavior.AllowGet);

            var product = DbContext.Products.Find(id);

            return Json(product, JsonRequestBehavior.AllowGet);
        }

    }
}