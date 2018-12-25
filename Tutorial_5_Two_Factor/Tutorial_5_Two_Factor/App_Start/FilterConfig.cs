using System.Web;
using System.Web.Mvc;

namespace Tutorial_5_Two_Factor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
