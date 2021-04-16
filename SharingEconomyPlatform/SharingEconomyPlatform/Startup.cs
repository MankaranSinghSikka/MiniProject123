using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharingEconomyPlatform.Startup))]
namespace SharingEconomyPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
