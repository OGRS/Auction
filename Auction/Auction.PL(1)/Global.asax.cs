using Auction.BLL.Infrastructure;
using Auction.PL.Ninject;
using Auction.PL.Util;
using Ninject;
using Ninject.Modules;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;

namespace Auction.PL
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

            NinjectModule categoryModule = new CategoryModule();
            NinjectModule lotModule = new LotModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(categoryModule, lotModule, serviceModule);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
        }
    }
}
