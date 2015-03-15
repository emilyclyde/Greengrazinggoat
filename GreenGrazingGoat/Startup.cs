using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenGrazingGoat.Startup))]
namespace GreenGrazingGoat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
