using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnterpriseSolution.WebApp.Startup))]
namespace EnterpriseSolution.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
