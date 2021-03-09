using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Chapter3.RequestLifecycle.Infrastructure;
using Chapter3.RequestLifecycle.Models;

namespace Chapter3.RequestLifecycle
{
    //Instantiated by the ASP.NET framework, called the Global Application class
    //Used to track Request Lifecycle events as well
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
            //Way 2. Handling Request Lifecycle events using event subscription
            PostAuthenticateRequest += (src, args) => RecordEvent("PostAuthenticateRequest");
            AuthorizeRequest += (src, args) => RecordEvent("AuthorizeRequest");
        }
        #endregion


        #region Application Lifecycle Special Mehtods

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        #endregion


        #region Request Lifecycle Special Methods

        // Way 1. Handling Request Lifecycle events using special methods
        // We define the methods as Application_<event>          
        protected void Application_BeginRequest()
        {
            this.RecordEvent("BeginRequest");
        }

        protected void Application_AuthenticateRequest()
        {
            this.RecordEvent("AuthenticateRequest");
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
