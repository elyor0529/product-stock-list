using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PSL.UI.Core.Data;

namespace PSL.UI.Core.Mvc
{
    public abstract class BaseController : Controller
    {
        private ApplicationDbContext _dbContext;

        protected BaseController()
        {
        }

        protected BaseController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        } 

        protected ApplicationDbContext DbContext
        {
            get => _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            private set => _dbContext = value;
        }

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl="/")
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}