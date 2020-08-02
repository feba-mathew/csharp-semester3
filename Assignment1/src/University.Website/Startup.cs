using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(University.Website.Startup))]
namespace University.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
