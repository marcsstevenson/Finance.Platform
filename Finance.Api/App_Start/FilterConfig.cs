using System.Web;
using System.Web.Mvc;
using Finance.Api.Attributes;

namespace Finance.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogonAuthorize());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
