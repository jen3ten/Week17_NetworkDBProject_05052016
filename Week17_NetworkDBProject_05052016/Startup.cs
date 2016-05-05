using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week17_NetworkDBProject_05052016.Startup))]
namespace Week17_NetworkDBProject_05052016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
