using BusinessLogicLayer.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PresentationLayer.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PresentationLayer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule buildingModule = new BuildingModule();
            NinjectModule serviceModule = new ServiceModule("BefaultConnection");

            var kernel = new StandardKernel(buildingModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
