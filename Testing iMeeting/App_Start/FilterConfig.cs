using System.Web;
using System.Web.Mvc;

namespace Testing_iMeeting
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

        }
    }
}
