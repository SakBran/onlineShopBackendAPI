using System.Web.Http;
using System.Web.Http.Cors;

namespace onlineShopBackend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("https://sakbran.github.io,http://localhost:4200,http://localhost,http://localhost:8080,http://localhost:3000,http://172.16.108.77:8080", "*", "*");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors(cors);
        }
    }
}
