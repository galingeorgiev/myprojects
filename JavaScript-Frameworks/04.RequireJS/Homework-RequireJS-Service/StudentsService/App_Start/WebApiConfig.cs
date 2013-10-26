using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentsService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{studentId}",
                defaults: new { studentId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultMarksApi",
                routeTemplate: "api/{controller}/{studentId}/marks",
                defaults: new
                {
                    studentId = RouteParameter.Optional,
                    action = "marks"
                    //marks = RouteParameter.Optional
                }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
