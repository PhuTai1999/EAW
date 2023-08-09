using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Admin_Page.Startup))]
namespace Admin_Page
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
