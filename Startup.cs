using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPAajax.Startup))]
namespace SPAajax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
