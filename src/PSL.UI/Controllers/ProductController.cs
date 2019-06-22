using System;
using System.Linq;
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
            var products = DbContext.Products.OrderByDescending(a=>a.Id).ToPagedList(page, 20);

            return View(products);
        }

    }
}