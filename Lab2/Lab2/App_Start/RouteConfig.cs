﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Lab2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "{controller}/{action}/{id}",
                new {controller = "Store", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(null, "{controller}/{action}/{id}",
                new {controller = "Store", action = "Cart", id = UrlParameter.Optional}
                );
        }
    }
}