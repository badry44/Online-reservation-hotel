using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_reservation_hotel.Startup))]
namespace Online_reservation_hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
