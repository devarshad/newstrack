using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsTrack
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Group",
                url: "Group/{id}",
                defaults: new { controller = "Group", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Category",
                url: "Category/{id}",
                defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Story",
                url: "Story/{id}",
                defaults: new { controller = "Story", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Account",
                url: "Account",
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "signin-google",
                url: "signin-google",
                defaults: new { controller = "Account", action = "ExternalLoginCallback" }
            );
        }
    }
}
