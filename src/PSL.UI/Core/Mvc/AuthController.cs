using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PSL.UI.Core.Data;
using PSL.UI.Core.Identity;

namespace PSL.UI.Core.Mvc
{
    [Authorize]
    public abstract class AuthController : BaseController
    {
        private ApplicationUserManager _userManager;

        protected AuthController()
        {
        }

        protected AuthController(ApplicationDbContext dbContext,ApplicationUserManager userManager):base(dbContext)
        {
            UserManager = userManager;
        }
        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        protected ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                } 
            }

            base.Dispose(disposing);
        }


    }
}