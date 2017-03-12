using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BJAT.Web.Startup))]
namespace BJAT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
