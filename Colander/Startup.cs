using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Colander.Startup))]
namespace Colander
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
