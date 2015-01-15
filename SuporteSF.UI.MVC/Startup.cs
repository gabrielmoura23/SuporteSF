using Microsoft.Owin;
using Owin;
using SuporteSF.UI.MVC;

[assembly: OwinStartup(typeof(Startup))]
namespace SuporteSF.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}