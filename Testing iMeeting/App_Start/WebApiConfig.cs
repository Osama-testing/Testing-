using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Testing_iMeeting
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}/{Param}",
            defaults: new
            {
                id = RouteParameter.Optional,
                Param = RouteParameter.Optional
            }
                          );
            
        }
    }
}
