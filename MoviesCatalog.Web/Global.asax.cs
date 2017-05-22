using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MoviesCatalog.Web.App_Start;
using WebMatrix.WebData;

namespace MoviesCatalog.Web
{
   

    public class MvcApplication : System.Web.HttpApplication
    {
        private static EntitiesInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        protected void Application_Start()
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);

            Bootstrapper.Run();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }

    public class EntitiesInitializer
    {
        public EntitiesInitializer()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("SimpleMembership", "User", "Id", "Email", true);



            if (!WebSecurity.UserExists("test@mail.ru"))
            {
                WebSecurity.CreateUserAndAccount("test@mail.ru", "test");
            }
            if (!WebSecurity.UserExists("testing@mail.ru"))
            {
                WebSecurity.CreateUserAndAccount("testing@mail.ru", "testing");
            }
        }
    }
}