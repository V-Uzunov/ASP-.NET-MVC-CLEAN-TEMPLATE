namespace Web
{
    using Data;
    using Data.Migrations;
    using Web.App_Start;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngineConfiguration.RegisterViewEngine(ViewEngines.Engines);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            AutoMapperConfig.ConfigureAutomapper();
        }
    }
}
