using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IQMetrix.Beertap.Web.Startup))]
namespace IQMetrix.Beertap.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
