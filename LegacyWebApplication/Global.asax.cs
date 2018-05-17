using LegacyFramework;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace LegacyWebApplication
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

            var serviceLocator = new AppServiceLocator();
            serviceLocator.RegisterInstance<ILogger>(new Logger());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
    }
}