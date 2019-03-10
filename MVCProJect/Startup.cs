using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProJect.Startup))]
namespace MVCProJect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
