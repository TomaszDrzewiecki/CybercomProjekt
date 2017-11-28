using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TomaszDrzewieckiCybercom2017.Startup))]
namespace TomaszDrzewieckiCybercom2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
