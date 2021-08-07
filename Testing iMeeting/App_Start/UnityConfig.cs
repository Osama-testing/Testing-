using iMeeting.BAL;
using System.Web.Mvc;
using Testing_iMeeting.Controllers;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

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
            container.RegisterType<AccountController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}