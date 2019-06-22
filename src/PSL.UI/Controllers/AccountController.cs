using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PSL.UI.Core.Data;
using PSL.UI.Core.Data.Entities;
using PSL.UI.Core.Identity;
using PSL.UI.Core.Mvc;
using PSL.UI.Models;

namespace PSL.UI.Controllers
{
    public class AccountController : AuthController
    {
        private ApplicationSignInManager _signInManager;


        public AccountController()
        {
        }

        public AccountController(ApplicationDbContext dbContext, ApplicationUserManager userManager, ApplicationSignInManager signInManager) : base(dbContext, userManager)
        {
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set => _signInManager = value;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal();

                default:
                    ModelState.AddModelError("", @"Invalid login attempt.");
                    return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false, false);

                    return RedirectToLocal();
                }

                AddErrors(result);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToLocal();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

    }
}