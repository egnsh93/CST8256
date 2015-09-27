using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new { 
                    controller = "Pages", 
                    action = "Step1", 
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Pages",
                    action = "Step2",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Pages",
                    action = "Step3",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
