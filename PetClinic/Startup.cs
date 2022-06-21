using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetClinic.Startup))]
namespace PetClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
