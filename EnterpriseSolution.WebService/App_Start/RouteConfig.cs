using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnterpriseSolution.WebService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "route1",
                url: "{controller}/{action}/{page}/{id}"
            );
            routes.MapRoute(
                name: "route2",
                url: "{controller}/{action}/{page1}/{page2}/{id}"
            );
            routes.MapRoute(
                name: "route3",
                url: "{controller}/{action}/{page1}/{page2}/{page3}/{id}"
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "login", id = UrlParameter.Optional }
            );
            
        }
    }
}
