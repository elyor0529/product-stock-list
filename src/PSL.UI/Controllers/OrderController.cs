using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PSL.UI.Core.Data;
using PSL.UI.Core.Identity;
using PSL.UI.Core.Mvc;
using X.PagedList;

namespace PSL.UI.Controllers
{
    public class OrderController : AuthController
    {
        public OrderController()
        {
        }

        public OrderController(ApplicationDbContext dbContext, ApplicationUserManager userManager) : base(dbContext, userManager)
        {
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var orders = DbContext.Orders.Where(w => w.ClientId == userId).OrderByDescending(a => a.Date);

            return View(orders);
        }

        public ActionResult Add(int id, int quality)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}