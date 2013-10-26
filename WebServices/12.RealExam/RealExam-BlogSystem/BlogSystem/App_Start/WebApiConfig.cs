using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BlogSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultUsersApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { }
            );

            config.Routes.MapHttpRoute(
                name: "CustomPostApi",
                routeTemplate: "api/posts/{postId}/comment",
                defaults: new
                {
                    controller = "posts",
                    action = "comment"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
