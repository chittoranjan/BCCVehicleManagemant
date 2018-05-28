using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCCRequisitionSystem.Startup))]
namespace BCCRequisitionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
