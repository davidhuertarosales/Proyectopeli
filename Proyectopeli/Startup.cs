using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyectopeli.Startup))]
namespace Proyectopeli
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
