using System.Web.Http;
using Utilities.Unity;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var register = new DependencyRegister();
            config.DependencyResolver = new UnityResolver(register.ApplyDependencies()); 

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Cors for the Angular app
            var cors = new EnableCorsAttribute("http://localhost:4200", headers: "*", methods: "*");
            config.EnableCors(cors);

            // Set JSON formatter as default one
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            formatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        }
    }
}
