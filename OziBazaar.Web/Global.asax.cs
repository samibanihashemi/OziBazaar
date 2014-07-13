using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.WebApi;
using OziBazaar.Web.App_Start;
using OziBazaar.Web.Models;
using OziBazaar.Web.Infrastructure.Binder;
namespace OziBazaar.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SecurityConfig.InitializeComponents();
            Bootstrapper.Initialise();
            ModelBinders.Binders.Add(typeof(CaptchaViewModel), new CaptchaModelBinder());
        }
    }
}
