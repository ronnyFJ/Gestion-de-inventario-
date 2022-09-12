using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestion_de_inventario_.Startup))]
namespace Gestion_de_inventario_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
