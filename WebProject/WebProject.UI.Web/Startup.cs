using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebProject.UI.Web.Startup))]
namespace WebProject.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
