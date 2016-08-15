using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Finance.Api.App_Start;

namespace Finance.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initialise the unity IoC container
            //For some reason, using unity is breaking in the in-built IoC - eg, the account controller constructor. TODO wire this IoC into our interfaces rather than using unity
            //Error is: The current type, Microsoft.AspNet.Identity.IUserStore`1[Finance.Logic.Indentity.PartyIdentityUser], is an interface and cannot be constructed. Are you missing a type mapping?
            Bootstrapper.Initialise(); 
        }
    }
}
