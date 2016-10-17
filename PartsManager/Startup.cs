using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartsManager.Startup))]
namespace PartsManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
