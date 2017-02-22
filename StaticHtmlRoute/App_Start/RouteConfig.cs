using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StaticHtmlRoute.Models;

namespace StaticHtmlRoute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*fileType}", new { fileType = @".*\.(gif|js|jpg|css|png|xml|ico|swf|jpeg|bmp|asp|rar)(/.*)?" });

            routes.Add("StaticFileRoute",
                 new Route("StaticHtml/{filename}", new StaticFileRouteHandler()));
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}