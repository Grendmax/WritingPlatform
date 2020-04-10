using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.Helpers;


namespace WritingPlatform
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule Module = new NinjectHelper();
            NinjectModule serviceModule = new ServiceModule("Model1");
            var kernel = new StandardKernel(serviceModule, Module);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
