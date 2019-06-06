using System.Net.Http.Headers;
using System.Web.Http;

namespace censusApp.API
{
    /// <summary>
    /// WebApiConfig.cs is for configuring any Web API related configuration,
    /// including Web-API-specific routes, Web API services, and other Web API settings.
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); 
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
