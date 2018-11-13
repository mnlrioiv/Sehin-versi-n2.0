using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sehin_versión2._0.Startup))]
namespace Sehin_versión2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
