using System.Web;
using System.Web.Mvc;

namespace Tutorial_14_logging_audit_trails
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
