using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SMS.Common;
using SMS.Comon.IOC;

namespace VICS.Manager.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger logger;

        protected void Application_Start()
        {
            //Server.ClearError();
            RegisterContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception == null) return;


            logger.LogError(exception);

            // maybe clean the exception then redirect to error page
            // Server.ClearError();

            // redirec to error page
            // Response.Redirect("errorpage");
        }
        private void RegisterContainer()
        {
            var container = StartupContainer.Initialize();

            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            logger = container.GetInstance<ILogger>();
        } 
    }
}
