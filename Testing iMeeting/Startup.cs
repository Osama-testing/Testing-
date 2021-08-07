using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testing_iMeeting.Startup))]
namespace Testing_iMeeting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
