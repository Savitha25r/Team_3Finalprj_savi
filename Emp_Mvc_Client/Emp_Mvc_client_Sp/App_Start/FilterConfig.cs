using System.Web;
using System.Web.Mvc;

namespace Emp_Mvc_client_Sp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
