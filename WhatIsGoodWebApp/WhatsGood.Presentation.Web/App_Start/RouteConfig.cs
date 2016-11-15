using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WhatsGood.Presentation.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Whatsgood Admin Genres",
                url: "Admin/Genres",
                defaults: new { controller = "Admin", action = "Index" }
            );


            routes.MapRoute(
                name: "Whatsgood Admin Events",
                url: "Admin/Events",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Whatsgood Admin Artists",
                url: "Admin/Artists",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
                name: "Whatsgood Admin Establishments",
                url: "Admin/Establishments",
                defaults: new { controller = "Admin", action = "Index" }
            );

            routes.MapRoute(
               name: "Whatsgood Admin Establishment Types",
               url: "Admin/EstablishmentTypes",
               defaults: new { controller = "Admin", action = "Index" }
           );


            routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "Home", action = "Index" },
                new[] { "WhatsGood.Presentation.Web.Controllers" }
            );
        }
    }
}
