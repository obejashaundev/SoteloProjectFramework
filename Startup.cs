using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoteloProjectFramework.Startup))]
namespace SoteloProjectFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
