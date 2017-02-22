using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Elmah.Contrib.WebApi;
using Microsoft.Owin.Security.OAuth;

namespace Finance.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Require authorisation on all controllers unless the controller or action is decorated with AllowAnonymous 
            //config.Filters.Add(new AuthorizeAttribute());

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            //We want to log using Elmah in the Web API controllers
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            
            //Enable CORS because we are an API used by many things
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
