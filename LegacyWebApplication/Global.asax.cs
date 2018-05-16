using LegacyFramework;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
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

        public class AppServiceLocator : IServiceLocator
        {
            private readonly Dictionary<Type, object> _instances;

            public AppServiceLocator()
            {
                _instances = new Dictionary<Type, object>();
            }

            public void RegisterInstance<TService>(object instance)
            {
                _instances.Add(typeof(TService), instance);
            }

            public IEnumerable<object> GetAllInstances(Type serviceType)
            {
                if (serviceType == null)
                {
                    return _instances.Values;
                }

                throw new NotImplementedException();
            }

            public IEnumerable<TService> GetAllInstances<TService>()
            {
                throw new NotImplementedException();
            }

            public object GetInstance(Type serviceType)
            {
                throw new NotImplementedException();
            }

            public object GetInstance(Type serviceType, string key)
            {
                throw new NotImplementedException();
            }

            public TService GetInstance<TService>()
            {
                var type = typeof(TService);
                if (_instances[type] == null)
                {
                    throw new InvalidOperationException(string.Format("Type {0} is not registered.", type));
                }
                
                return (TService)_instances[type];
            }

            public TService GetInstance<TService>(string key)
            {
                throw new NotImplementedException();
            }

            public object GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
    }
}