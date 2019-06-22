using System.Web.Optimization;

namespace PSL.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/assets/js/jquery.validate*"));
             
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/js/bootstrap.js", "~/assets/js/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/bootstrap.css", "~/assets/css/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
