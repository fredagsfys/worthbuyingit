using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WBI.Startup))]
namespace WBI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}