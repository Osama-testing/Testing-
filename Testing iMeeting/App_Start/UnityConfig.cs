using iMeeting.BAL;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Testing_iMeeting
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IVenueRepository, VenueRepository>();
            container.RegisterType<IUserpanelRespository, UserpanelRepository>();
            container.RegisterType<IAdminMeetingRepository, AdminMeetingRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}