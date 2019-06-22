using System.Web.Mvc;

namespace PSL.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //global errors
            filters.Add(new HandleErrorAttribute());
        }
    }
}
