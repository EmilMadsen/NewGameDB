using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameDB.Startup))]
namespace GameDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
