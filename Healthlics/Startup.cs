using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Healthlics.Startup))]
namespace Healthlics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
