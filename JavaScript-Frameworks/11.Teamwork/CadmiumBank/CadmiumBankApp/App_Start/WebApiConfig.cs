using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CadmiumBankApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "RegisterUsersApi",
                routeTemplate: "api/users/register",
                defaults: new
                {
                    controller = "users",
                    action = "register"
                }
            );

            config.Routes.MapHttpRoute(
                name: "LoginUsersApi",
                routeTemplate: "api/users/login",
                defaults: new
                {
                    controller = "users",
                    action = "login"
                }
            );

            config.Routes.MapHttpRoute(
                name: "LogoutUsersApi",
                routeTemplate: "api/users/logout",
                defaults: new
                {
                    controller = "users",
                    action = "logout"
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersAdministrationApi",
                routeTemplate: "api/users/{id}",
                defaults: new
                {
                    controller = "users",
                    id = RouteParameter.Optional
                }
            );

            config.Routes.MapHttpRoute(
                name: "UsersUpdateAdministrationApi",
                routeTemplate: "api/users/{id}/update",
                defaults: new
                {
                    controller = "users",
                    action = "update"
                }
            );

            config.Routes.MapHttpRoute(
                name: "AccountsApi",
                routeTemplate: "api/accounts/{id}/transactionlogs",
                defaults: new
                {
                    controller = "accounts",
                    action = "transactionlogs"
                }
            );

            config.Routes.MapHttpRoute(
                name: "SingleAccountApi",
                routeTemplate: "api/accounts/{id}",
                defaults: new
                {
                    controller = "accounts"
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
