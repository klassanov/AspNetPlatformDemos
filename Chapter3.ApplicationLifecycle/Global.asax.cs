using System.Web.Mvc;
using System.Web.Routing;

namespace Chapter3.ApplicationLifecycle
{
    //Instantiated by the ASP.NET framework, called the Global Application class
    //Used to track ApplicationLifecycle events
    public class MvcApplication : System.Web.HttpApplication
    {
        //Called when the application is started - key moment
        //Allows for one-off configuration tasks that affect the entire application
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            System.Diagnostics.Debugger.Break();
        }

        //Called when the application is about to be terminated - key moment
        //Called only when the application is shut down in an ORDERLY manner not in case of server crash or power outage for ex.
        //Allows for any resources that the application maintains to be released, for ex. persistent db connections
        //Rarely needed to be implemented
        protected void Application_End()
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
