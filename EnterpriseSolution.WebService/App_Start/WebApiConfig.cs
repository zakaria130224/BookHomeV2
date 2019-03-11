using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace EnterpriseSolution.WebService
{
    public static class WebApiConfig
    {
        //The UrlPrefix and UrlPrefixRelative has the added that we can fetch the base URL in javascript for making the AJAX calls
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //To enable a cross-domain request
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
