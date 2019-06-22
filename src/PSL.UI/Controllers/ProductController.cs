using System.Web.Mvc;
using PSL.UI.Core.Data;
using PSL.UI.Core.Mvc;

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

        public ActionResult Index()
        {
            return View();
        }
    }
}