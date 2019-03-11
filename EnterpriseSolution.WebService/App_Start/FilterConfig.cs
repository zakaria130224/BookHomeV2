using EnterpriseSolution.WebService;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSolution.WebService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CompressOutputAttribute());
        }
    }
}
