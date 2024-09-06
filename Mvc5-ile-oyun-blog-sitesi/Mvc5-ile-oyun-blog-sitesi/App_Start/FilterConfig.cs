using System.Web;
using System.Web.Mvc;

namespace Mvc5_ile_oyun_blog_sitesi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
