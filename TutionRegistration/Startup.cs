using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TutionRegistration.Startup))]
namespace TutionRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
