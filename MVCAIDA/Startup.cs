using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAIDA.Startup))]
namespace MVCAIDA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
