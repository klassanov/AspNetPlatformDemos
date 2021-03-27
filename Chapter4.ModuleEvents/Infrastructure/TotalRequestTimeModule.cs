using System.Diagnostics;
using System.Web;

namespace Chapter4.ModuleEvents.Infrastructure
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
            if (application.Modules["Timer"] is TimerModule timerModule)
            {
                timerModule.RequestTimed += (src, args) =>
                {
                    totalRequestCount++;
                    totalRequestTimeMilliSeconds += args.DurationMilliseconds;
                };
            }

            //Subscribe for and handle EndRequest to log information
            application.EndRequest += (src, args) =>
            {
                string msg = $"TotalRequests: {totalRequestCount}  TotalRequestTime [s]: {totalRequestTimeMilliSeconds / 1000m}";
                Debug.WriteLine(msg);
                HttpContext.Current.Response.Write(msg);
            };
        }
        public void Dispose()
        {
        }

    }
}