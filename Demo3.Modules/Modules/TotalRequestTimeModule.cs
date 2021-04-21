using System.Diagnostics;
using System.Web;
using Demo3.Modules.Events;

namespace Demo3.Modules.Modules
{
    public class TotalRequestTimeModule : IHttpModule
    {
        private static long totalRequestTimeMilliSeconds;
        private static int totalRequestCount;

        public void Init(HttpApplication application)
        {
            /* All registered module classes are instantiated before their Init methods are invoked. The order in which modules are registered
               determines the order on which request life cycle events are sent to modules, but doesn't have an impact on locating other modules through
               the HttpApplication.Modules property
            */

            //Get the TimerModule by the registered name in the web.config and subscribe for its event "RequestTimed"
            if (application.Modules[Constants.TimerModule] is TimerModule timerModule)
            {
                timerModule.RequestTimed += OnRequestTimed;
            }

            //Subscribe for and handle EndRequest to log information
            application.EndRequest += (src, args) =>
            {
                string msg = $"TotalRequests: {totalRequestCount}  TotalRequestTime: {totalRequestTimeMilliSeconds / 1000m} s";
                Debug.WriteLine(msg);
                HttpContext.Current.Response.Write(msg);
            };
        }

        private void OnRequestTimed(object src, RequestTimeEventArgs eventArgs)
        {
            totalRequestCount++;
            totalRequestTimeMilliSeconds += eventArgs.DurationMilliseconds;
        }

        public void Dispose()
        {
        }
    }
}