using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeilaoWeb.Startup))]
namespace LeilaoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
