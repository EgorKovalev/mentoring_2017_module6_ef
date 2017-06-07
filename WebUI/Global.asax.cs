using ServerSideTimer;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.App_Start;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            MappingConfig.RegisterMaps();

            HostingEnvironment.RegisterObject(new BackgroundUptimeServerTimer());
        }
    }
}
