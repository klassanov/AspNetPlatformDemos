using System;
using System.Diagnostics;
using System.Reflection;
using System.Web;

namespace Demo3.Modules.Modules
{
    public class EventsListModule : IHttpModule
    {
        private int eventNum;

        private readonly string[] events =
        {
            "BeginRequest",
            "AuthenticateRequest",
            "PostAuthenticateRequest",
            "AuthorizeRequest",
            "PostAuthorizeRequest",
            "ResolveRequestCache",
            "PostResolveRequestCache",
            "MapRequestHandler",
            "PostMapRequestHandler",
            "AcquireRequestState",
            "PostAcquireRequestState",
            "PreRequestHandlerExecute",
            "PostRequestHandlerExecute",
            "ReleaseRequestState",
            "PostReleaseRequestState",
            "UpdateRequestCache",
            "PostUpdateRequestCache",
            "LogRequest",
            "PostLogRequest",
            "EndRequest",
            //"PreSendRequestHeaders",
            //"PreSendRequestContent",
        };

        public void Init(HttpApplication application)
        {
            //Subscribe for all of the events in the array, execute "HandleEvent" event handler for each event
            MethodInfo methodInfo = GetType().GetMethod("HandleEvent");
            foreach (string eventName in this.events)
            {
                EventInfo eventInfo = application.GetType().GetEvent(eventName);
                Delegate eventDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
                eventInfo.AddEventHandler(application, eventDelegate);
            }

            //Subscribe for error event
            application.Error += (src, args) =>
            {
                this.LogEvent("Error");
            };

            // Subscribe for these 2 events like this because the HttpContext.Current.CurrentNotification enum
            // does not have these 2 values
            application.PreSendRequestHeaders += (src, args) => this.LogEvent("PreSendRequestHeaders");
            application.PreSendRequestContent += (src, args) => this.LogEvent("PreSendRequestContent");
        }

        public void HandleEvent(object src, EventArgs args)
        {
            //Post notification events name tweak
            string name = HttpContext.Current.CurrentNotification.ToString();
            if (HttpContext.Current.IsPostNotification)
            {
                name = "Post" + name;
            }

            if (name == "BeginRequest")
            {
                this.eventNum = 0;
                Debug.WriteLine("--------------------------");
            }

            this.LogEvent(name);
        }

        private void LogEvent(string name)
        {
            string msg = $"{++this.eventNum}. {name}";
            Debug.WriteLine(msg);
            HttpContext.Current.Response.Write(msg + "<br />");
        }

        public void Dispose()
        {
        }
    }
}