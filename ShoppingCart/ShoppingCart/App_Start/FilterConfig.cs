using ShoppingCart.Filters;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new JsonExceptionFilterAttribute());
        }
    }
}
