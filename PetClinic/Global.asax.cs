using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PetClinic.BLL.Infrastructure;
using PetClinic.Util;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PetClinic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();


            var model = WebConfigurationManager.ConnectionStrings;
            string connectionString = model[2].ConnectionString;
            
            NinjectModule serviceModule = new ServiceModule(connectionString);

            var kernel = new StandardKernel(registrations, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
