using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSL.UI.Startup))]
namespace PSL.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureServices(app);
            ConfigureAuth(app);
        }
    }
}
