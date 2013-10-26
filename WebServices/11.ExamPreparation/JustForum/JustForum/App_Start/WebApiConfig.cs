namespace JustForum
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ThreadsApi",
                routeTemplate: "api/threads/{sessionKey}",
                defaults: new
                {
                    controller = "threads",
                    sessionKey = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultUsersApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new {  }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
