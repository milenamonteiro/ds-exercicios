using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppMVCLogin.Startup))]
namespace AppMVCLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
