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
        private Guid instanceId;

        /* The technique can be used for events up to PreRequestHandlerExecute. This is because the action method
           in the controller is called between PreRequestHandlerExecute and PostRequestHandlerExecute and so 
           subsequent events are triggered after the response has been produced
        */
        #region Request Lifecycle Events Subscription
        //Added a constructor in order to be able to subscribe for events
        public MvcApplication()
        {
            //Way 2. Handling Request Lifecycle events using event subscription
            PostAuthenticateRequest += (src, args) => RecordEvent("PostAuthenticateRequest");
            AuthorizeRequest += (src, args) => RecordEvent("AuthorizeRequest");

            this.instanceId = Guid.NewGuid();
        }
        #endregion



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
            if (eventsList == null)
            {
                Application[Constants.Events] = eventsList = new List<EventModel>();
            }

            eventsList.Add(new EventModel
            {
                Name = name,
                TimestampOccured = DateTime.Now
            });
        }
    }
}
