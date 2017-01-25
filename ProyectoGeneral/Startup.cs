using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoGeneral.Startup))]
namespace ProyectoGeneral
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
