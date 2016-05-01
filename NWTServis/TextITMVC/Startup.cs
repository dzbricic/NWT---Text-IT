using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TextITMVC.Startup))]
namespace TextITMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
