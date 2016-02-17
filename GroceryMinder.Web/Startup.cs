using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroceryMinder.Web.Startup))]
namespace GroceryMinder.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
