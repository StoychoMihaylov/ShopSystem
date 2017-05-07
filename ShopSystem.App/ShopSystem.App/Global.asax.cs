using ShopSystem.Data;
using ShopSystem.Data.Migrations;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using ShopSystem.Models.EntityModels;
using ShopSystem.Models.ViewModels.Laptop;
using ShopSystem.Models.ViewModels.Monitor;
using ShopSystem.Models.ViewModels.Admin;
using ShopSystem.Models.BindingModels;
using ShopSystem.Models.ViewModels.Accessor;

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
                expression.CreateMap<Laptop, AdminLaptopsVm>();
                expression.CreateMap<Laptop, AdminDetailsLaptopsVm>();
                expression.CreateMap<AddLaptopBm, Laptop>();
                expression.CreateMap<Monitor, AdminMonitorsVm>();
                expression.CreateMap<AddMonitorBm, Monitor>();
                expression.CreateMap<Accessor, AccessorVm>();
                expression.CreateMap<Accessor, DetailsAccessorVm>();
                expression.CreateMap<Accessor, AdminAccessoriesVm>();
                expression.CreateMap<Accessor, AdminDetailsAccessorVm>();
                expression.CreateMap<AddAccessorBm, Accessor>();
                expression.CreateMap<Laptop, AdminDeleteLaptopVm>();
                expression.CreateMap<Laptop, AdminEditLaptopVm>();
                expression.CreateMap<AdminEditLaptopVm, Laptop>();
            });
        }
    }
}
