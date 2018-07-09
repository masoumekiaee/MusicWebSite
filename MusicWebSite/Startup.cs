using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicWebSite.Startup))]
namespace MusicWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
