using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());     // Authorize attribute 
            filters.Add(new RequireHttpsAttribute());  // Enable HTTPS
        }
    }
}
