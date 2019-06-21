using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyProductListWebApp.Startup))]
namespace MyProductListWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {

        }
    }
}
