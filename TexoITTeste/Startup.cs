using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TexoITTeste.Startup))]
namespace TexoITTeste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
