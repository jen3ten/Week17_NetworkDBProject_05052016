using System.Web;
using System.Web.Mvc;

namespace Week17_NetworkDBProject_05052016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
