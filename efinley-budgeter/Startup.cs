using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(efinley_budgeter.Startup))]
namespace efinley_budgeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
