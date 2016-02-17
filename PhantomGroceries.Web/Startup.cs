using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhantomGroceries.Web.Startup))]
namespace PhantomGroceries.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
