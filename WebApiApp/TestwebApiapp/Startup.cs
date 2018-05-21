using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestwebApiapp.Startup))]
namespace TestwebApiapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
