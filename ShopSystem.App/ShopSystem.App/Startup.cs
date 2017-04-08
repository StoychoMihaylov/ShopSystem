using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopSystem.App.Startup))]
namespace ShopSystem.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
