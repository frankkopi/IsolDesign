using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IsolDesign.WebUI.Startup))]
namespace IsolDesign.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
