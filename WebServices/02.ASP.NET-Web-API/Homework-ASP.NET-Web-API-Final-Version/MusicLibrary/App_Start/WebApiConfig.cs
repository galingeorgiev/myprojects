using System;
using System.Linq;
using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;

namespace MusicLibrary
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
