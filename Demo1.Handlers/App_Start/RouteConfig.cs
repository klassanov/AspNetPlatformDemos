using System.Web.Mvc;
using System.Web.Routing;

namespace Demo1.Handlers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //By default in MVC for all routes a handler is selected, so we need to ignore this special route
            //in order to make our custom handler selectable
            routes.IgnoreRoute("handlers/{*path}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
