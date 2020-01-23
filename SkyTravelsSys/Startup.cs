using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyTravelsSys.Startup))]
namespace SkyTravelsSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
