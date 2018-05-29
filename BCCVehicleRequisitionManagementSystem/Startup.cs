using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCCVehicleRequisitionManagementSystem.Startup))]
namespace BCCVehicleRequisitionManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
