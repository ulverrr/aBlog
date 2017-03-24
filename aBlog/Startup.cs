using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aBlog.Startup))]
namespace aBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
