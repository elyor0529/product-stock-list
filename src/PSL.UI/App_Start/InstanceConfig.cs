using Owin;
using PSL.UI.Core.Data;
using PSL.UI.Core.Identity;

namespace PSL.UI
{
    public partial class Startup
    {
        public void ConfigureServices(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}