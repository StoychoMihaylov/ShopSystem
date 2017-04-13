using ShopSystem.Data;
using ShopSystem.Data.Migrations;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;
using AutoMapper;
using ShopSystem.Models.EntityModels;
using ShopSystem.Models.ViewModels.Laptop;
using ShopSystem.Models.ViewModels.Monitor;


namespace ShopSystem.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ShopSystemContext, Configuration>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Laptop, LaptopsVm>();
                expression.CreateMap<Laptop, DetailsLaptopVm>();
                expression.CreateMap<Monitor, MonitorsVm>();
                expression.CreateMap<Monitor, DetailsMonitorVm>();
            });
        }
    }
}
