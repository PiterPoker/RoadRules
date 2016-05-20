using Microsoft.Owin;
using Owin;
using RoadRules;

[assembly: OwinStartup(typeof (Startup))]

namespace RoadRules
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}