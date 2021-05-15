using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Demo2.AppAndRequestLifecycles.Models;

namespace Demo2.AppAndRequestLifecycles
{
    //Instantiated by the ASP.NET framework, called the Global Application class
    //Used to track ApplicationLifecycle events
    public class MvcApplication : System.Web.HttpApplication
    {

        /* The technique can be used for events up to PreRequestHandlerExecute. This is because the action method
           in the controller is called between PreRequestHandlerExecute and PostRequestHandlerExecute and so 
           subsequent events are triggered after the response has been produced
        */
        #region Request Lifecycle Events Subscription
        //Added a constructor in order to be able to subscribe for events
        public MvcApplication()
        {
            //Way 1. Classic event subscription
            PostAuthenticateRequest += (src, args) => RecordEvent("PostAuthenticateRequest");
            AuthorizeRequest += (src, args) => RecordEvent("AuthorizeRequest");
        }
        #endregion

        //Way 2. Subscribe to events by using special methods -> Appplication_EventName
        public void Application_BeginRequest(object sender, EventArgs args)
        {
            Application[Constants.Events] = new List<EventModel>();
            RecordEvent("BeginRequest");
        }

        public void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            RecordEvent("AuthenticateRequest");
        }

        #region Application Lifecycle Special Mehtods
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
        #endregion

        //Supplementary method used for storing an event in a list
        private void RecordEvent(string name)
        {
            List<EventModel> eventsList = Application[Constants.Events] as List<EventModel>;
            eventsList.Add(new EventModel
            {
                Name = name,
                TimestampOccured = DateTime.Now
            });
        }
    }
}
