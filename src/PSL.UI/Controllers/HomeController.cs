using System.Web.Mvc;
using PSL.UI.Core.Mvc;

namespace PSL.UI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        } 
    }
}